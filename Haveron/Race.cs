using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Race
    {
        public string Name;

        private RaceType _raceType;

        public Race(string name, RaceType raceType)
        {
            Name = name;
            _raceType = raceType;
        }
    }

    enum RaceType
    {
        Human,
        Elf,
        Dwarf
    }
}
