using System;

namespace _10.PointCircleRectangle
{
    class PointCircleRectangle
    {
        static void Main()
        {
            double centerX = 1;
            double centerY = 1;
            double radius = 1.5;
            double topY = 1;
            double leftX = -1;
            double width = 6;
            double height = 2;

            double pointX = double.Parse(Console.ReadLine());
            double pointY = double.Parse(Console.ReadLine());

            double rightX = leftX + width;
            double bottomY = topY - height;

            double distance = Math
                .Sqrt(((centerX - pointX) * (centerX - pointX)) + ((centerY - pointY) * (centerY - pointY)));

            bool isInCircle = distance <= radius;
            bool isInRectangle = pointX >= leftX && rightX >= pointX && topY >= pointY && bottomY <= pointY;

            if (isInCircle && isInRectangle)
            {
                Console.WriteLine("inside circle inside rectangle");
            }
            else if (isInCircle && !isInRectangle)
            {
                Console.WriteLine("inside circle outside rectangle");
            }
            else if (!isInCircle && isInRectangle)
            {
                Console.WriteLine("outside circle inside rectangle");
            }
            else if (!isInCircle && !isInRectangle)
            {
                Console.WriteLine("outside circle outside rectangle");
            }
        }
    }
}
