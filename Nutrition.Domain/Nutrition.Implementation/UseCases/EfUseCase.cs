using Nutrition.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        private readonly NutritionContext _context;

        protected EfUseCase(NutritionContext context)
        {
            _context = context;
        }

        protected NutritionContext Context => _context;
    }
}
