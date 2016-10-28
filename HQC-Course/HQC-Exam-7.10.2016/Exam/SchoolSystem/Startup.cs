namespace SchoolSystem
{
    using Core;

    public class Startup
    {
        public static void Main()
        {
            var consoleReaderPr = new ConsoleReaderProvider();
            var consoleWriterPr = new ConsoleWriterProvider();
            var engine = new Engine(consoleReaderPr, consoleWriterPr);
            engine.ProcessCommand();
        }
    }
}
