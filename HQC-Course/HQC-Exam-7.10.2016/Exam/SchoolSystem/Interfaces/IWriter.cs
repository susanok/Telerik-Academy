namespace SchoolSystem.Interfaces
{
    /// <summary>
    /// Takes care about the writing of the responds
    /// </summary>
    public interface IWriter
    {
        /// <summary>
        /// Do the actual writing
        /// </summary>
        /// <param name="message">Receives a message which must be written</param>
        void Write(string message);
    }
}
