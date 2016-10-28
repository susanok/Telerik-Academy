namespace SchoolSystem.Core
{
    using System;
    using Interfaces;

    public class ConsoleReaderProvider : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}