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

        public PlayerBuilder(ProtoMan player)
        {
            _player = player;
            _orthography = new Orthography();
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

        public void ShowCurrentPlayer()
        {
            _player.ShowInfo();

            _player.ShowStats();

            _player.ShowCharacteristics();

            //Работа с курсором для консоли| Вывод HP конечностей
            int ConsoleX = Console.CursorLeft;
            int ConsoleY = Console.CursorTop;

            _player.ShowLimbsHealth();

            Console.SetCursorPosition(ConsoleX, ConsoleY);

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