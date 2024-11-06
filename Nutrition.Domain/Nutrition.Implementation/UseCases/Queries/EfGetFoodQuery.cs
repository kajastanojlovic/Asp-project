using Microsoft.EntityFrameworkCore;
using Nutrition.Application.DTO;
using Nutrition.Application.UseCases.Queries;
using Nutrition.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.UseCases.Queries
{
    public class EfGetFoodQuery : EfUseCase, IGetFoodQuery
    {
        public EfGetFoodQuery(NutritionContext context) : base(context)
        {
        }

        public int Id => 5;

        public string Name => "Search food";

        public PagedResponseDto<FoodDto> Execute(FoodSearch search)
        {
            var query = Context.Foods.AsQueryable();

            query = query.Where(x => x.IsActive);

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.Name.Contains(search.Keyword) ||
                                        x.Brand.Contains(search.Keyword));
            }

            int totalCount = query.Count();
            int perPage = search.PerPage.HasValue ? (int)Math.Abs((double)search.PerPage) : 10;
            int page = search.Page.HasValue ? (int)Math.Abs((double)search.Page) : 1;

            int skip = perPage * (page - 1);


            query = query.Skip(skip).Take(perPage);


            var foodDto = query.Select(x => new FoodDto
            {
                Name = x.Name,
                Brand = x.Brand,
                Macronutrients = x.FoodMacronutrients.Select(y=> new MacronutrientDto
                {
                    AmountMacronutrientsPer100g = y.AmountMacronutrientsPer100g,
                    Name = y.Macronutrient.Name
                })
            }).ToList();

            return new PagedResponseDto<FoodDto>
            {
                CurrentPage = page,
                Data = foodDto,
                PerPage = perPage,
                TotalCount = totalCount,
            };
        }
    }
}
