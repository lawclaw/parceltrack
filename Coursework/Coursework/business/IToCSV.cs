namespace Coursework.business
{
    /// <summary>
    /// Interface that declares methods concerning formatting into CSV
    /// </summary>
    public interface IToCSV
    {
        /// <summary>
        /// Abstract method which declares formatting an object into CSV format
        /// </summary>
        /// <returns>String in CSV format</returns>
        public abstract string ToCSV();
    }
}
