using System;

namespace _14.BitExchange
{
    class BitExchange
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int closePos = 3;
            int farPos = 24;
            int maskClose = 7;
            int maskFar = 7;

            maskClose = maskClose << closePos;
            int closeBitValue = num & maskClose;
            closeBitValue = closeBitValue >> closePos;

            maskFar = maskFar << farPos;
            int farBitValue = num & maskFar;
            farBitValue = farBitValue >> farPos;

            num = num & ~maskClose;
            num = num & ~maskFar;

            closeBitValue = closeBitValue << farPos;
            farBitValue = farBitValue << closePos;
            num = num | farBitValue;
            num = num | closeBitValue;

            Console.WriteLine(num);
        }
    }
}
