using System;

namespace _02.MoonGravity
{
    class MoonGravity
    {
        static void Main(string[] args)
        {
            float weigth = float.Parse(Console.ReadLine());
            float moonWeight = (weigth / 100) * 17;
            Console.WriteLine("{0:F3}", moonWeight);
        }
    }
}
