using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron.Калькулятор_характеристик
{
    class CharacteristicCalculator
    {
        private Human _human;
        private PlayerBuilder _playerBuilder;

        private SkillBuilder _skillBuilder;
        private LineageGenerator _humanPersona;

        public CharacteristicCalculator()
        {
            _skillBuilder = new SkillBuilder();
            _humanPersona = new LineageGenerator();

            _human = new Human(_skillBuilder.GetRandomBasicScills(),
                _humanPersona.GetRandomNationality(), _humanPersona.GetRandomRace());

            _playerBuilder = new PlayerBuilder(_human);
        }

        public void ChangeHumanStat()
        {
            bool isStatChanged = true;

            Console.Clear();

            while (isStatChanged)
            {
                _playerBuilder.ShowCurrentPlayer();

                Console.Write("[1] - Изменить характеристику\n" +
                    "[0] - Выход\n" +
                    "Ввод:");

                switch (Console.ReadLine())
                {
                    case "1":
                        _playerBuilder.ChangeValueStat();
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("Ошибка!");
                        break;
                }
                Console.Clear();
            }
        }

    }
}
