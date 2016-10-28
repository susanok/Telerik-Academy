using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age
{
    class Age
    {
        static void Main()
        {
            string[] readedBirthDate = Console.ReadLine().Split('.');
            string userInput = String.Join("-", readedBirthDate);
            DateTime userDate = DateTime.ParseExact(userInput, "MM-dd-yyyy", null);
            DateTime today = DateTime.Today;
            int age = today.Year - userDate.Year;

            if (userDate.Month > today.Month)
            {
                age--;
            }
            else
            {
                if (userDate.Month == today.Month)
                {
                    if (userDate.Day > today.Day)
                    {
                        age--;
                    }
                }
            }

            Console.WriteLine(age);
            int futureAge = age + 10;
            Console.WriteLine(futureAge);
        }
    }
}
