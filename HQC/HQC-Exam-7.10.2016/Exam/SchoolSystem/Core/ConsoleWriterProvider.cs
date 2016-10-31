namespace SchoolSystem.Core
{
    using System;
    using Interfaces;

    public class ConsoleWriterProvider : IWriter
    {
        public void Write(string message)
        {
            Console.WriteLine(message);
            Console.Write("\n");
        }
    }
}
