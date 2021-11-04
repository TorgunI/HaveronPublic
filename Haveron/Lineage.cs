using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Lineage
    {
        //////////////////////////////////////////////////////////////////////////////////////////
        public Nationality Nationality;
        public Race Race;
        public Individuality Individuality;

        public Lineage(Nationality nationality, Race race, Individuality individuality)
        {
            Nationality = nationality;
            Race = race;
            Individuality = individuality;
        }
    }
}
