using System;

namespace _14.PrintTheASCIITable
{
    class PrintTheASCIITable
    {
        static void Main()
        {
            for (int i = 33; i < 127; i++)
            {
                Console.Write(Char.ConvertFromUtf32(i));
            }
        }
    }
}
