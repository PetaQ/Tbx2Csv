namespace Tbx2Csv.ViewModel
{
    using System.Windows;
    using Tbx2Csv.DataTypes.DepInjection;
    using Tbx2Csv.Logic.App;
    
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        private string m_tbx2CsvVersion;

        public MainWindowViewModel()
        {
            base.DisplayName = "Tbx2Csv";
            this.InitViewModel();
        }

        /// <summary>
        ///     Tbx2Csv Version Property
        /// </summary>
        public string Tbx2CsvVersion
        {
            get
            {
                return this.m_tbx2CsvVersion;
            }
            set
            {
                if (this.m_tbx2CsvVersion != value)
                {
                    this.m_tbx2CsvVersion = value;
                    this.OnPropertyChanged("Tbx2CsvVersion");
                }
            }
        }

        /// <summary>
        ///     Init ViewModel
        /// </summary>
        private void InitViewModel()
        {
            this.Tbx2CsvVersion = AppStatic.ProductVersion;
        }
    }
}
