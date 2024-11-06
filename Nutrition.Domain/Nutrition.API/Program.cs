using FluentAssertions.Common;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Nutrition.API;
using Nutrition.API.Core;
using Nutrition.Application;
using Nutrition.Application.UseCases.Commands.Foods;
using Nutrition.Application.UseCases.Commands.Meals;
using Nutrition.Application.UseCases.Commands.Users;
using Nutrition.Application.UseCases.Queries;
using Nutrition.DataAccess;
using Nutrition.Implementation;
using Nutrition.Implementation.Logging.UseCases;
using Nutrition.Implementation.UseCases.Commands.Foods;
using Nutrition.Implementation.UseCases.Commands.Meals;
using Nutrition.Implementation.UseCases.Commands.Users;
using Nutrition.Implementation.UseCases.Queries;
using Nutrition.Implementation.Validators;
using System.Data;
using System.Text;
using static Dapper.SqlMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var settings = new AppSettings();
builder.Configuration.Bind(settings);
builder.Services.AddSingleton(settings.Jwt);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<NutritionContext>(x => new NutritionContext(settings.ConnectionString));
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(settings.ConnectionString));
builder.Services.AddTransient<JwtTokenCreator>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
builder.Services.AddTransient<ITokenStorage, InMemoryTokenStorage>();

builder.Services.AddTransient<IApplicationActorProvider>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();

    var request = accessor.HttpContext.Request;

    var authHeader = request.Headers.Authorization.ToString();

    var context = x.GetService<NutritionContext>();

    return new JwtApplicationActorProvider(authHeader);
});
builder.Services.AddTransient<IApplicationActor>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>();
    if (accessor.HttpContext == null)
    {
        return new UnauthorizedActor();
    }

    return x.GetService<IApplicationActorProvider>().GetActor();
});


builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<IRegisterUserCommmand, EfRegisterUserCommand>();
builder.Services.AddTransient<RegisterUserValidator>();
builder.Services.AddTransient<IUseCaseLogger, SPUseCaseLogger>();
builder.Services.AddTransient<ICreateMealCommand, EfCreateMealCommand>();
builder.Services.AddTransient<IUpdateMealCommand, EfUpdateMealCommand>();
builder.Services.AddTransient<CreateMealDtoValidator>();
builder.Services.AddTransient<IDeleteMealCommand, EfDeleteMealCommand>();
builder.Services.AddTransient<DeleteMealValidator>();
builder.Services.AddTransient<IGetFoodQuery, EfGetFoodQuery>();
builder.Services.AddTransient<IUpdateUserAccessCommand, EfUpdateUserAccessCommand>();
builder.Services.AddTransient<UpdateUserAccessDtoValidator>();
builder.Services.AddTransient<ICreateFoodCommand, EfCreateFoodCommand>();
builder.Services.AddTransient<CreateFoodDtoValidator>();
builder.Services.AddTransient<IDeleteFoodCommand, EfDeleteFoodCommand>();
builder.Services.AddTransient<DeleteFoodValidator>();
builder.Services.AddTransient<IUpdateFoodCommand, EfUpdateFoodCommand>();
builder.Services.AddTransient<UpdateFoodValidator>();



builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = settings.Jwt.Issuer,
            ValidateIssuer = true,
            ValidAudience = "Any",
            ValidateAudience = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.Jwt.SecretKey)),
            ValidateIssuerSigningKey = true,
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero
        };
        cfg.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                //Token dohvatamo iz Authorization header-a

                Guid tokenId = context.HttpContext.Request.GetTokenId().Value;

                var storage = builder.Services.BuildServiceProvider().GetService<ITokenStorage>();

                if (!storage.Exists(tokenId))
                {
                    context.Fail("Invalid token");
                }


                return Task.CompletedTask;

            }
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
