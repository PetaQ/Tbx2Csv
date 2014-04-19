namespace Tbx2Csv.ViewModel
{
    using Logic;

    public class ViewModelBase
    {
        /// <summary>
        ///     Log Message to ApplicationLogFile
        /// </summary>
        /// <param name="message"></param>
        public void LogWrite(string category, string message)
        {
            Log.Write(category.ToUpper(), message);
        }
    }
}
