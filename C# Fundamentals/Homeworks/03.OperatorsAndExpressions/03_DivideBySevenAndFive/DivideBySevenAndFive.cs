using System;

namespace _03_DivideBySevenAndFive
{
    class DivideBySevenAndFive
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            if (num % 5 == 0 && num % 7 == 0)
            {
                Console.WriteLine("true " + num);
            }
            else
            {
                Console.WriteLine("false " + num);
            }
        }
    }
}
