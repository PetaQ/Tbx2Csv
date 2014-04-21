namespace Tbx2Csv.ViewModel
{
    using Logic;
    using System.ComponentModel;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;

    public class ViewModelBase
    {
        /// <summary>
        ///     Display Name of the MVVM ViewMode
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///     PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Log Message to ApplicationLogFile
        /// </summary>
        /// <param name="message">String Message</param>
        /// <param name="category">String Category</param>
        public void LogWrite(string category, string message)
        {
            DepInj.Container.Resolve<ILog>().Write(category, message);
        }

        /// <summary>
        ///     OnPropertyChanged Event
        /// </summary>
        /// <param name="name">String Property</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
