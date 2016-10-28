using System;

namespace _13.ComparingFloats
{
    class ComparingFloats
    {
        static void Main()
        {
            double firstNum = double.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());
            bool isEqual = Math.Abs(firstNum - secondNum) < 0.000001;

            if (isEqual)
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
