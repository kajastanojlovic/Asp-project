using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class Biometric 
    {
        public int UserId { get; set; }
        public int BodyId { get; set; }
        public decimal Value { get; set; }
        public User User { get; set; }
        public BodyBiometric BodyBiometric { get; set; }
    }
}
