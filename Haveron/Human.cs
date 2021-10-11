using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Human : ProtoMan
    {
        //Создание стандартного человека нулевого уровня
        public Human(int freePoints, List<string> currentBasicSkills, Nationality nationality, Race race) : base()
        {
            SetFreePoints(freePoints);
            GetBasicSkills(currentBasicSkills);
        }

        //Создание рандомного человека нулевого уровня
        public Human(string name, float strength, float agility, float intelligent, float endurance, float lucky, 
            List<string> currentBasicSkills, Nationality nationality, Race race)
            : base(name, strength, agility, intelligent, endurance, lucky, currentBasicSkills, nationality, race)
        {
            SetFreePoints(0);
        }

        //Создание собственного человека
        public Human(string name, float strength, float agility, float intelligent, float endurance, float lucky, 
            int freePoints, List<string> currentBasicSkills, Nationality nationality, Race race) 
            : base(name, strength, agility, intelligent, endurance, lucky, currentBasicSkills, nationality, race)
        {
            SetFreePoints(freePoints);
        }

    }
}
