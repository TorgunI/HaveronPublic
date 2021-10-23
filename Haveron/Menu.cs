using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Menu
    {
        private PlayersListBuilder _playersListBuilder;
        private PlayerBuilder _playerBuilder;

        public Menu()
        {
            _playersListBuilder = new PlayersListBuilder();
            _playerBuilder = new PlayerBuilder(_playersListBuilder.GetChosenPlayer(0));
        }

        public void Run()
        {
            bool isRun = true;
            while (isRun)
            {
                _playerBuilder.ShowCurrentPlayer();

                Console.WriteLine("[1] - Взаимодействие с выбранным персонажем\n" +
                    "[2] - Взаимодействие со списком игроков\n" +
                    "[3] - Выход");

                Console.Write("Ввод: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        RunPlayerMenu();
                        break;
                    case "2":
                        RunPlayersListMenu();
                        break;
                    case "3":
                        isRun = false;
                        break;
                    default:
                        Console.WriteLine("Неправильная команда!");
                        break;
                }

                Console.WriteLine("Для продолжения нажмите любую клавишу");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void RunPlayerMenu()
        {
            Console.WriteLine("\n[1] - Изменить характеристику\n" +
                "[2] - Распределить очки уровня");
            Console.Write("Ввод: ");

            switch (Console.ReadLine())
            {
                case "1":
                    _playerBuilder.ChangeValueStat();
                    break;
                case "2":
                    _playerBuilder.DistributeFreePoints();
                    break;
                default:
                    Console.WriteLine("Неправильная команда!");
                    break;
            }
        }

        private void RunPlayersListMenu()
        {
            Console.WriteLine("\n[1] - Выбрать игрока из списка\n" +
                    "[2] - Создать игрока\n" +
                    "[3] - Вывести список игроков\n" +
                    "[4] - Очистить список персонажей");
            Console.Write("Ввод: ");

            switch (Console.ReadLine())
            {
                case "1":
                    if(_playersListBuilder.IsPlayerChosen(out int playerIndex))
                        _playerBuilder = new PlayerBuilder(_playersListBuilder.GetChosenPlayer(playerIndex));
                    break;
                case "2":
                    _playersListBuilder.CreationPlayerMenu();
                    break;
                case "3":
                    _playersListBuilder.ShowPlayersList();
                    break;
                case "4":
                    _playersListBuilder.ClearPlayersList();
                    break;
                default:
                    Console.WriteLine("Неправильная команда!");
                    break;
            }
        }
    }
}