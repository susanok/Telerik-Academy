using System;

namespace _12.NthBit
{
    class NthBit
    {
        static void Main()
        {
            ulong num = ulong.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());

            ulong moveBit = num >> position;
            ulong foundBit = moveBit & 1;

            Console.WriteLine(foundBit);
        }
    }
}
