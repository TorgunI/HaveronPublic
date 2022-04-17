using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Haveron.Калькулятор_характеристик;

namespace Haveron
{
    class Menu
    {
        private PlayersListBuilder _playersListBuilder;
        private PlayerBuilder _playerBuilder;
        private CharacteristicCalculator _characteristicCalculator;

        public Menu()
        {
            _playersListBuilder = new PlayersListBuilder();
            _playerBuilder = new PlayerBuilder(_playersListBuilder.GetChosenPlayer(0));
            _characteristicCalculator = new CharacteristicCalculator();
        }

        public void RunMenu()
        {
            bool isRun = true;

            while (isRun)
            {
                Console.WriteLine("Выберите меню, которое хотите запустить:\n" +
                    "[1] - Калькулятор персонажа\n" +
                    "[2] - Калькулятор характеристик\n" +
                    "[3] - Рандомайзер вещей\n" +
                    "[0] - Выход");

                Console.Write("Ввод: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        RunPlayerCalculator();
                        break;
                    case "2":
                        _characteristicCalculator.ChangeHumanStat();
                        break;
                    case "0":
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

        private void RunPlayerCalculator()
        {
            bool isRun = true;
            while (isRun)
            {
                _playerBuilder.ShowCurrentPlayer();

                Console.WriteLine("[1] - Взаимодействие с выбранным персонажем\n" +
                    "[2] - Взаимодействие со списком игроков\n" +
                    "[0] - Выход");

                Console.Write("Ввод: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        RunPlayerMenu();
                        break;
                    case "2":
                        RunPlayersListMenu();
                        break;
                    case "0":
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
                "[2] - Распределить очки уровня\n" +
                "[3] - Настройка вывода информации об игроке\n" +
                "[0] - Выход из меню персонажа");
            Console.Write("Ввод: ");

            switch (Console.ReadLine())
            {
                case "1":
                    _playerBuilder.ChangeValueStat();
                    break;
                case "2":
                    _playerBuilder.DistributeFreePoints();
                    break;
                case "3":
                    _playerBuilder.DisplayOutputSelection();
                    break;
                case "0":
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
                    "[4] - Очистить список персонажей\n" +
                    "[0] - Выход из меню персонажа");
            Console.Write("Ввод: ");

            switch (Console.ReadLine())
            {
                case "1":
                    _playerBuilder.ChangePlayer(_playersListBuilder.TryChoosePlayer());
                    break;
                case "2":
                    _playerBuilder.ChangePlayer(_playersListBuilder.GetNewPlayer());
                    break;
                case "3":
                    _playersListBuilder.ShowPlayersList();
                    break;
                case "4":
                    _playersListBuilder.ClearPlayersList();
                    break;
                case "0":
                    break;
                default:
                    Console.WriteLine("Неправильная команда!");
                    break;
            }
        }
    }
}