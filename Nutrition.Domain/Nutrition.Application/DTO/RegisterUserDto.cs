using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Application.DTO
{
    public class RegisterUserDto
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public IFormFile? ImagePath { get; set; }
        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public double Height { get; set; }
        public double StartWeight { get; set; }
        public int TargetValueCaloriesPerDay { get; set; }
    }
}
