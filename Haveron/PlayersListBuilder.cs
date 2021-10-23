using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class PlayersListBuilder
    {
        private List<ProtoMan> _players;

        private SkillBuilder _skillBuilder;
        private HumanPersona _humanPersona;

        private Orthography _orthography;
        private Random _random;

        private int _playerID { get; set; }

        private const int _characterStatsNumber = 5;

        public PlayersListBuilder()
        {
            _skillBuilder = new SkillBuilder();
            _humanPersona = new HumanPersona();

            _players = new List<ProtoMan>()
            {
                new Human(_skillBuilder.GetRandomBasicScills(),
                _humanPersona.GetRandomNationality(), _humanPersona.GetRandomRace())
            };

            _orthography = new Orthography();
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

        public bool IsPlayerChosen(out int playerIndex)
        {
            ShowPlayersList();

            if (_orthography.IsIntRead(out playerIndex) == false || playerIndex > _players.Count || playerIndex == 0)
            {
                Console.WriteLine("Такого игрока нет!");
                return false;
            }
            --playerIndex;
            return true;
        }

        public ProtoMan GetChosenPlayer(int playerIndex)
        {
            return _players[playerIndex];
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
            if (_orthography.IsIntRead(out int freePoints) == false)
                return;

            ProtoMan player = new Human(_skillBuilder.GetRandomBasicScills(),
                _humanPersona.GetRandomNationality(), _humanPersona.GetRandomRace(), freePoints);
            Balance(player);
            _players.Add(player);
        }

        private void CreatePeculiarPlayer()
        {
            Console.WriteLine("Укажите значение силы:");
            if (_orthography.IsIntRead(out int strength) == false)
                return;

            Console.WriteLine("Укажите значение ловкости:");
            if (_orthography.IsIntRead(out int agility) == false)
                return;

            Console.WriteLine("Укажите значение интеллекта:");
            if (_orthography.IsIntRead(out int intelligent) == false)
                return;

            Console.WriteLine("Укажите значение выносливости:");
            if (_orthography.IsIntRead(out int endurance) == false)
                return;

            Console.WriteLine("Укажите значение удачи:");
            if (_orthography.IsIntRead(out int lucky) == false)
                return;

            Console.WriteLine("Укажите уровень персонажа.");
            if (_orthography.IsIntRead(out int freePoints) == false)
                return;

            ProtoMan player = new Human(strength, agility, intelligent, endurance, lucky, freePoints, _skillBuilder.GetRandomBasicScills(),
               _humanPersona.GetRandomNationality(), _humanPersona.GetRandomRace());
            _players.Add(player);
        }

        private void Balance(ProtoMan player)
        {
            int distributiveStatValue;

            for (int i = 0; i < 4; i++)
            {
                Stat stat = player.GetStatByType((StatType)i);

                if (stat.Value < 2)
                    break;

                distributiveStatValue = _random.Next(1, (int)stat.Value - 2);
                player.GetStatByType(stat.StatType).ChangeValue(distributiveStatValue, '-');

                player.GetStatByType((StatType)_random.Next(0, _characterStatsNumber)).
                    ChangeValue(distributiveStatValue, '+');
            }
            DistributiveFreeStat(player);
            player.Update();
        }

        private void DistributiveFreeStat(ProtoMan player)
        {
            while (player.FreePoints != 0)
            {
                int point = _random.Next(1, player.FreePoints);

                player.GetStatByType((StatType)_random.Next(0, _characterStatsNumber)).
                    ChangeValue((point), '+');
                player.SubtractFreePoint(point);
            }
        }
    }
}