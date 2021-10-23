using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Menu
    {
        PlayerBuilder _playerBuilder;

        public Menu()
        {
            _playerBuilder = new PlayerBuilder();
        }

        public void Run()
        {
            bool isRun = true;
            while (isRun)
            {
                _playerBuilder.ShowCurrentPlayer();

                Console.WriteLine("[1] - Взаимодействие с выбранным персонажем\n" +
                    "[2] - Взаимодействие со списком игроков" +
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
            Console.WriteLine("[1] - Изменить характеристику");
            Console.Write("Ввод: ");

            switch (Console.ReadLine())
            {
                case "1":
                    _playerBuilder.ChangeValueStat();
                    break;
                case "3":
                    _playerBuilder.DistributeFreePoints();
                    break;
                default:
                    Console.WriteLine("Неправильная команда!");
                    break;
            }
        }

        private void RunPlayersListMenu()
        {
            Console.WriteLine("[1] - Выбрать игрока из списка\n" +
                    "[2] - Создать игрока\n" +
                    "[3] - Вывести список игроков\n" +
                    "[4] - Очистить список персонажей");
            Console.Write("Ввод: ");

            switch (Console.ReadLine())
            {
                case "1":
                    _playerBuilder.ChoosePlayer();
                    break;
                case "2":
                    _playerBuilder.CreationPlayerMenu();
                    break;
                case "3":
                    _playerBuilder.ShowPlayersList();
                    break;
                case "4":
                    _playerBuilder.ClearPlayersList();
                    break;
                default:
                    Console.WriteLine("Неправильная команда!");
                    break;
            }
        }
    }
}