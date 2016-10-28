using System;

namespace _08.PrimeCheck
{
    class PrimeCheck
    {
        static void Main()
        {
            double num = Convert.ToInt32(Console.ReadLine());
            bool isPrime = true;

            if (num == 1 || num == 0 || num < 0)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i < num; i++)
                {
                    if (num % i == 0)
                    {
                        isPrime = false;
                    }
                }
            }

            if (isPrime)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
