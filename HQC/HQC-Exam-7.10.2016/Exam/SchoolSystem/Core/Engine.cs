namespace SchoolSystem.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Interfaces;
    using Models;

    public class Engine
    {
        private const string TypeInfoIsNullErrorMessage = "The type info is null!";

        private const string EndCommandName = "End";

        private IReader reader;

        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
            Teachers = new Dictionary<int, Teacher>();
            Students = new Dictionary<int, Student>();
        }

        public static Dictionary<int, Teacher> Teachers { get; set; }

        public static Dictionary<int, Student> Students { get; set; }

        public void ProcessCommand()
        {
            while (true)
            {
                try
                {
                    var command = this.reader.Read();
                    if (command == EndCommandName)
                    {
                        break;
                    }

                    var commandName = command.Split(' ')[0];
                    var assembli = this.GetType().GetTypeInfo().Assembly;
                    var typeInfo = assembli.DefinedTypes
                        .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                        .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                        .FirstOrDefault();
                    if (typeInfo == null)
                    {
                        throw new NullReferenceException(TypeInfoIsNullErrorMessage);
                    }

                    var createdCommand = Activator.CreateInstance(typeInfo) as ICommand;
                    var parameters = command.Split(' ').ToList();
                    parameters.RemoveAt(0);
                    this.writer.Write(createdCommand.Execute(parameters));
                }
                catch (Exception ex)
                {
                    this.writer.Write(ex.Message);
                }
            }
        }
    }
}
