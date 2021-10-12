using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class PlayerBuilder
    {
        private List<ProtoMan> _players;

        private SkillBuilder _skillBuilder;
        private HumanPersona _humanPersona;

        private Random _random;

        private int _playerID { get; set; }

        public PlayerBuilder()
        {
            _skillBuilder = new SkillBuilder();
            _humanPersona = new HumanPersona();

            _players = new List<ProtoMan>()
            {
                new Human(_skillBuilder.GetRandomBasicScills(),
                _humanPersona.GetRandomNationality(), _humanPersona.GetRandomRace())
            };

            _random = new Random();
        }

        public void CreationPlayerMenu()
        {
            Console.WriteLine($"[1] - Создание рандомного игрока нулевого уровня\n" +
                $"[2] - Создание радномного человека определенного уровня\n" +
                $"[3] - Создание собственного игрока\n");

            switch (Console.ReadLine())
            {
                case "1":
                    CreatePlayer();
                    break;
                case "2":
                    CreateLvlPlayer();
                    break;
                case "3":
                    CreatePeculiarPlayer();
                    break;
                default:
                    Console.WriteLine("Неправильная команда!");
                    break;
            }
        }

        public void Balance(ProtoMan player)
        {
            int distributiveStatValue;

            for (int i = 0; i < 4; i++)
            {
                Stat stat = player.GetStatByType((StatType)i);

                if (stat.Value < 2)
                    break;

                distributiveStatValue = _random.Next(1, (int)stat.Value - 2);
                player.GetStatByType(stat.StatType).ChangeValue(distributiveStatValue, '-');

                player.GetStatByType((StatType)_random.Next(0, 5)).
                    ChangeValue(distributiveStatValue, '+');
            }
            DistribuveFreeStat(player);
            player.Update();
        }

        public void DistribuveFreeStat(ProtoMan player)
        {
            while (player.FreePoints != 0)
            {
                int point = _random.Next(1, player.FreePoints);

                player.GetStatByType((StatType)_random.Next(0, 5)).
                    ChangeValue((point), '+');
                player.SubtractFreePoint(point);
            }
        }

        public void ChoosePlayer()
        {
            ShowPlayersList();

            if (IsPlayerChosen(out int userInput) == false)
            {
                return;
            }

            --userInput;
            _playerID = userInput;
        }

        private bool IsStatChosed(out int userInput)
        {
            Console.WriteLine("Выберите характеристику:\n" +
                "[1] - Сила\n" +
                "[2] - Ловкость\n" +
                "[3] - Интеллект\n" +
                "[4] - Выносливость\n" +
                "[5] - Удача");

            if (IsIntRead(out userInput) == false && userInput > 5)
            {
                Console.WriteLine("Такого стата нет!");
                return false;
            }

            --userInput;
            return true;
        }

        public void ChangeValueStat()
        {
            if (IsStatChosed(out int userInput) == false)
            {
                return;
            }

            if ((IsIntRead(out int userValue)) && IsCharRead(out char userSign) &&
                (userSign == '-' || userSign == '+'))
            {
                //_players[_playerID].GetStatByType((StatType)userInput).ChangeValue(userValue, userSign);
                _players[_playerID].GetStatByType((StatType)userInput).SetValue(userValue);
                _players[_playerID].Update();
            }
        }

        public void ClearPlayersList()
        {
            Console.WriteLine("Очищаем...");
            _players.Clear();
        }

        public void ShowPlayersList()
        {
            int counter = 0;
            foreach (var player in _players)
            {
                ++counter;
                Console.WriteLine($"[{counter}] Имя: {player.Name}\n");
                player.ShowStats();
                Console.WriteLine();
            }
        }

        public void ShowCurrentPlayer()
        {
            if (_players.Count == 0)
            {
                return;
            }

            _players[_playerID].ShowInfo();

            _players[_playerID].ShowStats();

            _players[_playerID].ShowCharacteristics();

            //Работа с курсором для консоли| Вывод HP конечностей
            int ConsoleX = Console.CursorLeft;
            int ConsoleY = Console.CursorTop;

            _players[_playerID].ShowLimbsHealth();

            Console.SetCursorPosition(ConsoleX, ConsoleY);

            _players[_playerID].ShowBasicSkills();
        }

        public bool IsPlayerChosen(out int userInput)
        {
            if (IsIntRead(out userInput) == false || userInput > _players.Count || userInput == 0)
            {
                Console.WriteLine("Такого игрока нет!");
                return false;
            }
            return true;
        }

        public bool IsIntRead(out int userInput)
        {
            Console.Write("Введите число: ");
            if (int.TryParse(Console.ReadLine(), out userInput) == false || userInput < 0)
            {
                Console.WriteLine("Введено неправильное число ");
                return false;
            }
            return true;
        }

        //public bool IsFloatRead(out float userInput)
        //{
        //    Console.Write("Введите число: ");
        //    if (float.TryParse(Console.ReadLine(), out userInput) == false || userInput < 0)
        //    {
        //        Console.WriteLine("Введено неправильное число ");
        //        return false;
        //    }
        //    return true;
        //}

        public bool IsCharRead(out char sign)
        {
            Console.Write("Введите знак: ");
            if (char.TryParse(Console.ReadLine(), out sign) == false)
            {
                Console.WriteLine("Введено неправильный знак ");
                return false;
            }
            return true;
        }

        private void CreatePlayer()
        {
            ProtoMan player = new Human(_skillBuilder.GetRandomBasicScills(),
                _humanPersona.GetRandomNationality(), _humanPersona.GetRandomRace());
            Balance(player);
            _players.Add(player);
        }

        private void CreateLvlPlayer()
        {
            Console.WriteLine("Укажите уровень персонажа.");
            if (IsIntRead(out int freePoints) == false)
                return;

            ProtoMan player = new Human(_skillBuilder.GetRandomBasicScills(),
                _humanPersona.GetRandomNationality(), _humanPersona.GetRandomRace(), freePoints);
            Balance(player);
            _players.Add(player);
        }

        private void CreatePeculiarPlayer()
        {
            Console.WriteLine("Укажите значение силы:");
            if (IsIntRead(out int strength) == false)
                return;

            Console.WriteLine("Укажите ловкости:");
            if (IsIntRead(out int agility) == false)
                return;

            Console.WriteLine("Укажите интеллекта:");
            if (IsIntRead(out int intelligent) == false)
                return;

            Console.WriteLine("Укажите выносливости:");
            if (IsIntRead(out int endurance) == false)
                return;

            Console.WriteLine("Укажите удачи:");
            if (IsIntRead(out int lucky) == false)
                return;

            Console.WriteLine("Укажите уровень персонажа.");
            if (IsIntRead(out int freePoints) == false)
                return;

            ProtoMan player = new Human(strength, agility, intelligent, endurance, lucky, freePoints, _skillBuilder.GetRandomBasicScills(),
               _humanPersona.GetRandomNationality(), _humanPersona.GetRandomRace());
            _players.Add(player);
        }
    }
}