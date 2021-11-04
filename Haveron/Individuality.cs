using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Individuality
    {
        public int Age { get; private set; }
        public int Weight { get; private set; }

        public string Physique { get; private set; }
        public string Trait { get; private set; }
        public string SpecialTrait { get; private set; }

        public Individuality(int age, int weight, string physique, string traits, string specialTraits)
        {
            Age = age;
            Weight = weight;
            Physique = physique;
            Trait = traits;
            SpecialTrait = specialTraits;
        }
    }
}