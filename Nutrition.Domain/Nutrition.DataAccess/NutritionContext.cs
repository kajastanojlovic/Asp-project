using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nutrition.Domain;

namespace Nutrition.DataAccess
{
    public class NutritionContext : DbContext
    {
        private readonly string _connectionString;

        public NutritionContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NutritionContext()
        {
            _connectionString = "Data Source=DESKTOP-GOT8QHV\\SQLEXPRESS;Initial Catalog=Nutrition;TrustServerCertificate=true;Integrated security = true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            modelBuilder.Entity<UserUseCase>().HasKey(x => new
            {
                x.UserId,
                x.UseCaseId
            });


            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

            foreach (EntityEntry entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.IsActive = true;
                        e.CreatedAt = DateTime.UtcNow;
                    }
                }

                if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is Entity e)
                    {
                        e.UpdatedAt = DateTime.UtcNow;
                    }
                }
            }

            return base.SaveChanges();
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<MealFood> MealsFoods { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodMacronutrient> FoodsMacronutrients { get; set; }
        public DbSet<Macronutrient> Macronutrients { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<GoalStatus> GoalStatuses { get; set; }
        public DbSet<DailyGoal> DailyGoals { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<ServingSize> ServingSizes { get; set; }

    }
}
