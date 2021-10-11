using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Human : ProtoMan
    {
        public Human(int freePoints, List<string> currentBasicSkills) : base()
        {
            SetFreePoints(freePoints);
            GetBasicSkills(currentBasicSkills);
        }

        public Human(string name, float strength, float agility, float intelligent, float endurance, float lucky, 
            List<string> currentBasicSkills)
            : base(name, strength, agility, intelligent, endurance, lucky, currentBasicSkills)
        {
            SetFreePoints(0);
        }

        public Human(string name, float strength, float agility, float intelligent, float endurance, float lucky, 
            int freePoints, List<string> currentBasicSkills) 
            : base(name, strength, agility, intelligent, endurance, lucky, currentBasicSkills)
        {
            SetFreePoints(freePoints);
        }

    }
}
