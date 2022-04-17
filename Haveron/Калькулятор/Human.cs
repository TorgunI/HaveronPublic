using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Human : ProtoMan
    {
        ////Создание человека определенного уровня
        //public Human(int freePoints) : base()
        //{
        //    SetFreePoints(freePoints);
        //}

        //Создание рандомного человека нулевого уровня
        public Human(List<string> basicSkills, Nationality nationality, Race race)
            : base(basicSkills, nationality, race)
        {
            SetFreePoints(2);
        }

        //Создание радномного человека определенного уровня
        public Human(List<string> basicSkills, Nationality nationality, Race race, 
            int freePoints) : base(basicSkills, nationality, race)
        {
            SetFreePoints(freePoints);
        }

        //Создание собственного человека с определенным уровнем
        public Human(float strength, float agility, float intelligent, float endurance, float lucky, 
            int freePoints, List<string> basicSkills, Nationality nationality, Race race) 
            : base(strength, agility, intelligent, endurance, lucky, basicSkills, nationality, race)
        {
            SetFreePoints(freePoints);
        }

    }
}
