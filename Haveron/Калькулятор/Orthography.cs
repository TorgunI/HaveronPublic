using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Haveron
{
    class Orthography
    {

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

        public bool IsCharRead(out char sign)
        {
            Console.Write("Введите знак: + или -");
            if (char.TryParse(Console.ReadLine(), out sign) == false)
            {
                Console.WriteLine("Введено неправильный знак ");
                return false;
            }
            return true;
        }

    }
}
