using System.Collections.Generic;

namespace SchoolSystem.Interfaces
{
    /// <summary>
    /// Determines a command wich can execute
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameters">Parameters to execute</param>
        /// <returns>Return response if it's successfull</returns>
        string Execute(IList<string> parameters);
    }
}
