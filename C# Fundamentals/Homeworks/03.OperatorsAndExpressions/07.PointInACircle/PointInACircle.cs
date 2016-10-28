using System;

namespace _07.PointInACircle
{
    class PointInACircle
    {
        static void Main()
        {
            double centerX = 0;
            double centerY = 0;
            double radius = 2;

            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            bool isInCircle = ((x - centerX) * (x - centerX)) + ((y - centerY) + (y - centerY)) <= radius * radius;
            double distance = Math.Sqrt(((centerX - x) * (centerX - x)) + ((centerY - y) * (centerY - y)));

            if (distance <= 2)
            {
                Console.WriteLine("yes {0:F2}", distance);
            }
            else
            {
                Console.WriteLine("no {0:F2}", distance);
            }
        }
    }
}
