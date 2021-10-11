using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class HumanPersona
    {
        private List<Nationality> _nationalities;
        private Random _random;

        public HumanPersona()
        {
            _nationalities = new List<Nationality>()
            {
                new Nationality("Хаверон", NationalityType.Haveron),
                new Nationality("Империя", NationalityType.Empire),
                new Nationality("Инея", NationalityType.Inea)
            };

            _random = new Random();
        }

        public Nationality GetRandomNationality()
        {
            return _nationalities[_random.Next(0, _nationalities.Count + 1)];
        }

        public void GetSpecificNationality()
        {

        }
    }
}
