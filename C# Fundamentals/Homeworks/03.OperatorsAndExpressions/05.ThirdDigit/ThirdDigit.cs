using System;

namespace _05.ThirdDigit
{
    class ThirdDigit
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int num1 = num / 10;
            int digit1 = num % 10;
            int num2 = num1 / 10;
            int digit2 = num1 % 10;
            int num3 = num2 / 10;
            int digit3 = num2 % 10;

            if (digit3 == 7)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false " + digit3);
            }
        }
    }
}
