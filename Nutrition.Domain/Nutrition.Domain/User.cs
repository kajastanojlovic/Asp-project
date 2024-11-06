using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class User : Entity
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string ImagePath { get; set; }

        public ICollection<UserUseCase> UserUseCases { get; set; } = new HashSet<UserUseCase>();
        public ICollection<Goal> Goals { get; set; } = new HashSet<Goal>();
        public ICollection<Meal> Meals { get; set; } = new HashSet<Meal>();
        public ICollection<DailyGoal> DailyGoals { get; set; } = new HashSet<DailyGoal>();
        public ICollection<Biometric> Biometrics { get; set; } = new HashSet<Biometric>();
        
    }
}
