using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class SkillBuilder
    {
        private List<string> _basicSkills;

        private Random _random;

        public SkillBuilder()
        {
            _basicSkills = new List<string>()
            {
                "Фехтование",
                "Атлетика",
                "Медицина",
                "Борьба",
                "Метание",
                "Стрельба",
                "Выживание",
                "Скрытность"
            };

            _random = new Random();
        }

        public List<string> GetRandomBasicScills()
        {
            List<string> playerBasicSkills = new List<string>()
            {
                _basicSkills[_random.Next(0, _basicSkills.Count())],
                _basicSkills[_random.Next(0, _basicSkills.Count())]
            };

            return playerBasicSkills;
        }

    }
}
