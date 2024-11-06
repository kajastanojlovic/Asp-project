using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Application.DTO
{
    public class FoodSearch : PagedSearch
    {
        public string Keyword { get; set; }
        //search po brand i namse
    }
}
