using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Stat
    {
        public string Name { get; private set; }
        public float Value { get; private set; }
        public StatType StatType { get; private set; }

        public Stat(string name, float value, StatType statType)
        {
            Name = name;
            Value = value;
            StatType = statType;
        }

        public void SetValue(float userValue)
        {
            Value = userValue;
        }

        public void ChangeValue(float userValue, char sign)
        {
            switch (sign)
            {
                case '+':
                    Value += userValue;
                    break;
                case '-':
                    Value -= userValue;
                    break;
            }
        }
    }
}