using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Nationality
    {
        public string Name { get; private set; }
        //public float Value { get; private set; }
        public NationalityType NationalityType { get; private set; }

        public Nationality(string name, /*float value,*/ NationalityType nationalityType)
        {
            Name = name;
            //Value = value;
            NationalityType = nationalityType;
        }
    }
}