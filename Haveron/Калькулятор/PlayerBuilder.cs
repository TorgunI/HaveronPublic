using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class PlayerBuilder
    {
        private ProtoMan _player;
        private Orthography _orthography;

        private bool isInfoDisplayed;
        private bool isStatsDisplayed;
        private bool isCharacteristicsDisplayed;
        private bool isBasicSkillsDisplayed;
        private bool IsLimbsHealthDisplayed;

        public PlayerBuilder(ProtoMan player)
        {
            _player = player;
            _orthography = new Orthography();

            isInfoDisplayed = true;
            isStatsDisplayed = true;
            isCharacteristicsDisplayed = true;
            isBasicSkillsDisplayed = false;
            IsLimbsHealthDisplayed = true;
        }

        public void ChangePlayer(ProtoMan newPlayer)
        {
            if (_player == newPlayer && newPlayer != null)
                Console.WriteLine("Ошибка выбора игрока");

            _player = newPlayer;
        }

        public void ChangeValueStat()
        {
            if (IsStatChosed(out int userInput) == false)
            {
                return;
            }

            if (_orthography.IsIntRead(out int userValue))
            {
                _player.GetStatByType((StatType)userInput).SetValue(userValue);
                _player.Update();
            }
        }

        public void DistributeFreePoints()
        {
            if (_player.FreePoints == 0)
            {
                Console.WriteLine("У выбранного игрока нет очков прокачки!");
                return;
            }

            Console.WriteLine($"Доступнные очки: {_player.FreePoints}. " +
                $"Сколько нужно отнять очков прокачки?");
            if (_orthography.IsIntRead(out int userValue) == false || userValue > _player.FreePoints)
            {
                Console.WriteLine("Превышено число очков прокачки!");
                return;
            }

            if (IsStatChosed(out int userInput))
            {
                _player.DistributeFreePointsToCharacteristic(userValue,
                    _player.GetStatByType((StatType)userInput));
                _player.Update();
            }
        }
        
        public void DisplayOutputSelection()
        {
            Console.Clear();

            bool isUserChoses = true;

            while(isUserChoses)
            {
                Console.WriteLine("Настройте вывод информации об игроке:\n" +
                    "[1] - Основная информация о внешности\n" +
                    "[2] - Характеристики\n" +
                    "[3] - Статы\n" +
                    "[4] - Здоровье конечностей\n" +
                    "[5] - Базовые скиллы\n" +
                    "[6] - Выход");
                Console.Write("Ввод: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CustomizeDisplay(out isInfoDisplayed);
                        break;
                    case "2":
                        CustomizeDisplay(out isCharacteristicsDisplayed);
                        break;
                    case "3":
                        CustomizeDisplay(out isStatsDisplayed);
                        break;
                    case "4":
                        CustomizeDisplay(out IsLimbsHealthDisplayed);
                        break;
                    case "5":
                        CustomizeDisplay(out isBasicSkillsDisplayed);
                        break;
                    case "6":
                        isUserChoses = false;
                        break;
                    default:
                        Console.WriteLine("Ошибка!");
                        break;
                }

            }
        }

        private void CustomizeDisplay(out bool isDisplayed)
        {
            Console.Write("Отображать информацию ?\n[1] - Да\n[2] - Нет\nВвод:");

            if (Console.ReadLine() == "1")
                isDisplayed = true;
            else
                isDisplayed = false;
        }

        public void ShowCurrentPlayer()
        {
            if(isInfoDisplayed)
                _player.ShowInfo();

            if(isCharacteristicsDisplayed)
            _player.ShowCharacteristics();

            if(isStatsDisplayed)
                _player.ShowStats();

            if(IsLimbsHealthDisplayed)
            {
                //Работа с курсором для консоли| Вывод HP конечностей
                int ConsoleX = Console.CursorLeft;
                int ConsoleY = Console.CursorTop;

                _player.ShowLimbsHealth();

                Console.SetCursorPosition(ConsoleX, ConsoleY);
            }

            if(isBasicSkillsDisplayed)
                _player.ShowBasicSkills();
        }

        private bool IsStatChosed(out int userInput)
        {
            Console.WriteLine("\nВыберите характеристику:\n" +
                "[1] - Сила\n" +
                "[2] - Ловкость\n" +
                "[3] - Интеллект\n" +
                "[4] - Выносливость\n" +
                "[5] - Удача");

            if (_orthography.IsIntRead(out userInput) == false && userInput > 5) // заглушка 5
            {
                Console.WriteLine("Такого стата нет!");
                return false;
            }

            --userInput;
            return true;
        }
    }
}