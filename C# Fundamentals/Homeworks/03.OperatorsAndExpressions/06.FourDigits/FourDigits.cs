using System;

namespace _06.FourDigits
{
    class FourDigits
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int num1 = num / 10;
            int d = num % 10;
            int num2 = num1 / 10;
            int c = num1 % 10;
            int num3 = num2 / 10;
            int b = num2 % 10;
            int num4 = num3 / 10;
            int a = num3 % 10;

            Console.WriteLine(a + b + c + d);
            Console.WriteLine("{0}{1}{2}{3}", d, c, b, a);
            Console.WriteLine("{0}{1}{2}{3}", d, a, b, c);
            Console.WriteLine("{0}{1}{2}{3}", a, c, b, d);
        }
    }
}
