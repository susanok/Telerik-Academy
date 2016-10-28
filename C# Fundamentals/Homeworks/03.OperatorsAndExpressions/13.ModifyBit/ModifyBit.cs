using System;

namespace _13.ModifyBit
{
    class ModifyBit
    {
        static void Main()
        {
            ulong num = ulong.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());
            ulong bitValue = ulong.Parse(Console.ReadLine());

            if (bitValue == 0)
            {
                ulong mask = ~(1UL << position);
                ulong result = num & mask;
                Console.WriteLine(result);
            }
            else
            {
                ulong mask = 1UL << position;
                ulong result = num | mask;
                Console.WriteLine(result);
            }
        }
    }
}
