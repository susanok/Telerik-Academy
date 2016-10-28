using System;

namespace _15.BitSwap
{
    class BitSwap
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int q = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());
            int closePos = 0;
            int farPos = 0;

            if (p < q)
            {
                closePos += p;
                farPos += q;
            }
            else
            {
                closePos += q;
                farPos += p;
            }

            int maskClose = (1 << k) - 1;
            int maskFar = (1 << k) - 1;

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
