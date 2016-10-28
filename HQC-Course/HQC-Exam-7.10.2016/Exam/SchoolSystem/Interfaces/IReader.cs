namespace SchoolSystem.Interfaces
{
    /// <summary>
    /// Takes care about the rading of the commands
    /// </summary>
    public interface IReader
    {
        /// <summary>
        /// Do the actual reading
        /// </summary>
        /// <returns>The readed commands</returns>
        string Read();
    }
}
