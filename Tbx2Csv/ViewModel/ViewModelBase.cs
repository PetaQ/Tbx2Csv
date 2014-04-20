namespace Tbx2Csv.ViewModel
{
    using Logic;

    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;

    public class ViewModelBase
    {
        /// <summary>
        ///     Log Message to ApplicationLogFile
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="category">Category</param>
        public void LogWrite(string category, string message)
        {
            DepInj.Container.Resolve<ILog>().Write(category, message);
        }
    }
}
