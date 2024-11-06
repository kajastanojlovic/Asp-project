using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class DailyGoal : Entity
    {
        public int UserId { get; set; }

        //uporedjujemo kalorije iz meals i goals
        //onda postavljamo status true/false
        //da li je user ispunio dailyGoal ili ne
        public bool Status { get; set; }

        public User User { get; set; }
    }
}
