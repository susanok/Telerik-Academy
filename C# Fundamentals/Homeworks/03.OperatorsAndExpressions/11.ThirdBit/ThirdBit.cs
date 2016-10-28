using System;

namespace _11.ThirdBit
{
    class ThirdBit
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int position = 3;

            int movedBit = num >> position;
            int foundBit = movedBit & 1;

            bool isOne = foundBit == 1;

            if (isOne)
            {
                Console.WriteLine(1);
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
