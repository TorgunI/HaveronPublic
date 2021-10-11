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
        private List<Race> _races;

        private Random _random;

        public HumanPersona()
        {
            _nationalities = new List<Nationality>()
            {
                new Nationality("Хаверон", NationalityType.Haveron),
                new Nationality("Империя", NationalityType.Empire),
                new Nationality("Инея", NationalityType.Inea)
            };

            _races = new List<Race>()
            {
                new Race("Человек", RaceType.Human),
                new Race("Эльф", RaceType.Elf),
                new Race("Дварф", RaceType.Dwarf)
            };

            _random = new Random();
        }

        public Nationality GetRandomNationality()
        {
            return _nationalities[_random.Next(0, _nationalities.Count)];
        }
        public void GetSpecificNationality()
        {

        }

        public Race GetRandomRace()
        {
            return _races[_random.Next(0, _races.Count)];
        }

    }
}
