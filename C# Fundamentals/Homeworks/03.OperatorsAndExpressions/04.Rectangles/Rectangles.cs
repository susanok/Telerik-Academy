using System;

namespace _04.Rectangles
{
    class Rectangles
    {
        static void Main()
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double area = width * height;
            double per = (2 * width) + (2 * height);

            Console.WriteLine("{0:F2} {1:F2}", area, per);
        }
    }
}
