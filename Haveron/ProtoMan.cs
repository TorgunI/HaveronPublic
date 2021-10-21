using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    abstract class ProtoMan
    {
        public string Name { get; protected set; }
        public Race Race { get; protected set; }
        public Nationality Nationality { get; protected set; }

        public Stat Strength { get; protected set; }
        public Stat Agility { get; protected set; }
        public Stat Intelligent { get; protected set; }
        public Stat Endurance { get; protected set; }
        public Stat Lucky { get; protected set; }

        public float HP { get; protected set; }
        public float Mana { get; protected set; }
        public float OD { get; protected set; }
        public float PersonalDamage { get; protected set; }
        public float ProtactionPointer { get; protected set; }
        public float PersonalInitiation { get; protected set; }

        public float HeadHealth { get; protected set; }
        public float BodyHealth { get; protected set; }
        public float StomachHealth { get; protected set; }
        public float RightHandHealth { get; protected set; }
        public float LeftHandHealth { get; protected set; }
        public float RightLegHealth { get; protected set; }
        public float LeftLegHealth { get; protected set; }

        public int FreePoints { get; protected set; }
        public int Level { get; protected set; }

        private List<Stat> _stats;
        private List<float> _limbsHealth;
        private List<string> _basicSkills;

        //Инициализация
        public ProtoMan() 
        {
            Name = "Man";
            Race = new Race("Человек", RaceType.Human);
            Nationality = new Nationality("Хаверон", NationalityType.Haveron);
            Level = 0;

            Strength = new Stat("Сила", 5, StatType.Strength);
            Agility = new Stat("Ловкость", 5, StatType.Agility);
            Endurance = new Stat("Выносливость", 5, StatType.Endurance);
            Intelligent = new Stat("Интеллект", 5, StatType.Intelligent);
            Lucky = new Stat("Удача", 5, StatType.Lucky);

            HP = (Strength.Value + Agility.Value + Endurance.Value) * 2;
            Mana = (Intelligent.Value + Endurance.Value) / 2;
            OD = (Agility.Value + Endurance.Value) / 2;
            PersonalInitiation = (Intelligent.Value + Agility.Value) / 2;
            PersonalDamage = (Strength.Value + Agility.Value) / 5;
            ProtactionPointer = (Strength.Value + Agility.Value + Endurance.Value) / 3;

            HeadHealth = HP * 0.1f;
            BodyHealth = HP * 0.3f;
            StomachHealth = HP * 0.2f;
            RightHandHealth = HP * 0.1f;
            LeftHandHealth = HP * 0.1f;
            RightLegHealth = HP * 0.1f;
            LeftLegHealth = HP * 0.1f;

            _stats = new List<Stat>()
            {
                Strength,
                Agility,
                Intelligent,
                Endurance,
                Lucky
            };

            _limbsHealth = new List<float>()
            {
                HeadHealth,
                BodyHealth,
                StomachHealth,
                RightHandHealth,
                LeftLegHealth,
                RightLegHealth,
                LeftLegHealth
            };
        }

        //Player lvl 0
        public ProtoMan(List<string> basicSkills, Nationality nationality, Race race) : this()
        {
            Race = race;
            Nationality = nationality;
            _basicSkills = basicSkills;
        }

        //Custom Player
        public ProtoMan(float strength, float agility, float intelligent, float endurance, float lucky, 
            List<string> basicSkills, Nationality nationality, Race race) : this()
        {
            Race = race;
            Nationality = nationality;

            Strength.SetValue(strength);
            Agility.SetValue(agility);
            Intelligent.SetValue(intelligent);
            Endurance.SetValue(endurance);
            Lucky.SetValue(lucky);

            _basicSkills = basicSkills;
        }

        public void SetName(string name)
        {
            Name = name;
        }

        public Stat GetStatByType(StatType statType)
        {
            foreach (var stat in _stats)
            {
                if (stat.StatType == statType)
                {
                    return stat;
                }
            }
            throw new Exception("Такого стата нет!"); // заглушка, нужно пофиксить
        }

        public void SetFreePoints(int value)
        {
            FreePoints = value;
        }

        public void SubtractFreePoint(int value)
        {
            FreePoints -= value;
        }

        public void DistributeFreePointsToCharacteristic(int value, Stat stat)
        {
            FreePoints -= value;
            stat.ChangeValue(value, '+');
        }

        //public void GetBasicSkills(List<string> playerBasicSkills)
        //{
        //    _basicSkills = playerBasicSkills;
        //}

        //public void IncreaseNationalityPoints()
        //{

        //}

        public void Update()
        {
            HP = (Strength.Value + Agility.Value + Endurance.Value) * 2;
            Mana = (Intelligent.Value + Endurance.Value) / 2;
            OD = (Agility.Value + Endurance.Value) / 2;
            PersonalInitiation = (Intelligent.Value + Agility.Value) / 2;
            PersonalDamage = (Strength.Value + Agility.Value) / 5;
            ProtactionPointer = (Strength.Value + Agility.Value + Endurance.Value) / 3;

            HeadHealth = HP * 0.1f;
            BodyHealth = HP * 0.3f;
            StomachHealth = HP * 0.2f;
            RightHandHealth = HP * 0.1f;
            LeftHandHealth = HP * 0.1f;
            RightLegHealth = HP * 0.1f;
            LeftLegHealth = HP * 0.1f;

            _stats = new List<Stat>()
            {
                Strength,
                Agility,
                Intelligent,
                Endurance,
                Lucky
            };

            _limbsHealth = new List<float>()
            {
                HeadHealth,
                BodyHealth,
                StomachHealth,
                RightHandHealth,
                LeftLegHealth,
                RightLegHealth,
                LeftLegHealth
            };
        }

        public void CheckLevel()
        {
            if(Level > 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    FreePoints++;
                }
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Имя:{Name}\n" +
                $"Раса: {Race.Name}\n" +
                $"Национальность: {Nationality.Name}\n" +
                $"Уровень: {Level}");
        }

        public void ShowStats()
        {
            foreach (var stat in _stats)
            {
                Console.WriteLine(stat.Name + ": " + stat.Value);
            }
            Console.WriteLine();
        }

        public void ShowCharacteristics()
        {
            Console.WriteLine($"HP: {HP};\n" +
                $"Mana: {Mana};\n" +
                $"OD: {OD};\n" +
                $"Личная Инициация: {PersonalInitiation};\n" +
                $"Личный Урон:{PersonalDamage};\n" +
                $"Показатель Защиты: {ProtactionPointer}\n");
        }

        public void ShowLimbsHealth()
        {
            Console.SetCursorPosition(40, 0);
            Console.Write($"Голова: {HeadHealth}");

            Console.SetCursorPosition(40, 1);
            Console.Write($"Торс: {BodyHealth}");

            Console.SetCursorPosition(50,2);
            Console.Write($"Правая рука: {RightHandHealth}");

            Console.SetCursorPosition(30,2);
            Console.Write($"Левая рука:{LeftHandHealth}");

            Console.SetCursorPosition(40,3);
            Console.Write($"Живот: {StomachHealth}");

            Console.SetCursorPosition(50,4);
            Console.Write($"Правая нога: {RightLegHealth}");

            Console.SetCursorPosition(30,4);
            Console.Write($"Левая нога: {LeftLegHealth}");
        }

        public void ShowBasicSkills()
        {
            Console.WriteLine("Базовые скиллы:");

            for (int i = 0; i < _basicSkills.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_basicSkills[i]}");
            }
            Console.WriteLine();
        }
    }
}