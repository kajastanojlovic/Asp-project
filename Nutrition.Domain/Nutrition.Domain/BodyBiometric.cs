using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Domain
{
    public class BodyBiometric : Entity
    {
        public string Name { get; set; }
        public string Units { get; set; }
        public DateTime Time { get; set; }

        public ICollection<Biometric> Biometrics { get; set; } = new HashSet<Biometric>();
    }
}
