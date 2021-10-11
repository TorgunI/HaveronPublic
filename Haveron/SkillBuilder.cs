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

        //радномный выбор базовых скиллов бех повторений - НЕ СДЕЛАНО
        public List<string> GetRandomBasicScills()
        {
            List<string> playerBasicSkills = new List<string>();
            List<int> randomIndices = new List<int>();

            while (playerBasicSkills.Count != 5)
            {
                int randomIndex = _random.Next(0, _basicSkills.Count());
                if (randomIndices.Contains(randomIndex))
                    continue;

                randomIndices.Add(randomIndex);
                playerBasicSkills.Add(_basicSkills[randomIndex]);
            }

            return playerBasicSkills;
        }

    }
}
