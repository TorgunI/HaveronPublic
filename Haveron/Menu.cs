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

                Console.WriteLine("[1] - Выбрать игрока из списка\n" +
                    "[2] - Изменить характеристику\n" +
                    "[3] - Вывести список игроков\n" +
                    "[4] - Создать игрока\n" +
                    "[5] - Очистить список персонажей");
                Console.Write("Ввод: ");

                string userChoice = Console.ReadLine();

                //Console.Clear();
                switch (userChoice)
                {
                    case "1":
                        _playerBuilder.ChoosePlayer();
                        break;
                    case "2":
                        _playerBuilder.ChangeValueStat();
                        break;
                    //case "3":
                    //    _playerBuilder.Dis
                    //    break;
                    case "4":
                        _playerBuilder.CreationPlayerMenu();
                        break;
                    case "5":
                        _playerBuilder.ShowPlayersList();
                        break;
                    case "6":
                        _playerBuilder.ClearPlayersList();
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

    }
}
