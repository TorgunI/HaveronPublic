using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class LineageGenerator
    {
        private List<Nationality> _nationalities;
        private List<Race> _races;

        private Individuality _individuality;
        
        private Random _random;

        private List<string> _physiqueList;
        private List<string> _traitsList;
        private List<string> _specialTraitsList;

        public LineageGenerator()
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

            _physiqueList = new List<string>()
            {
                "Полный",
                "Худой",
                "Накаченный"
            };

            _traitsList = new List<string>()
            {
                "Раздражающийся",
                "Веселый",
                "Грубый",
                "Гордливый"
            };

            _specialTraitsList = new List<string>()
            {
                "Осанка",
                "Взгляд",
                "Походка"
            };

            _random = new Random();
            _individuality = GetRandomIndividuality();
        }

        public Nationality GetRandomNationality()
        {
            return _nationalities[_random.Next(0, _nationalities.Count)];
        }

        //public void GetSpecificNationality()
        //{

        //}

        public Race GetRandomRace()
        {
            return _races[_random.Next(0, _races.Count)];
        }

        public Individuality GetRandomIndividuality()
        {
            return new Individuality(GetRandomAge(), GetRandomWeight(),
                GetRandompPhysique(), GetRandomTrait(), GetRandomSpecialTrait());
        }

        public int GetRandomAge()
        {
            return _random.Next(16, 80);
        }

        public int GetRandomWeight()
        {
           return _random.Next(40, 120);
        }

        public string GetRandompPhysique()
        {
            return _physiqueList[_random.Next(0, _physiqueList.Count)];
        }

        public string GetRandomTrait()
        {
           return _traitsList[_random.Next(0, _traitsList.Count)];
        }

        public string GetRandomSpecialTrait()
        {
            return _specialTraitsList[_random.Next(0, _specialTraitsList.Count)];
        }
    }
}
