namespace Tbx2Csv.ViewModel
{
    using System.Windows;
    using System.Windows.Controls;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;
    using Tbx2Csv.Logic.App;
    using Tbx2Csv.View;
    
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        /// <summary>
        ///     Field Tbx2CsvVersion
        /// </summary>
        private string m_tbx2CsvVersion;

        /// <summary>
        ///     Field Navigation ViewModel
        /// </summary>
        private INavigationView m_navigationView;

        private ContentViewModel m_contentView;

        /// <summary>
        ///     Konstruktor
        /// </summary>
        public MainWindowViewModel()
        {
            this.InitViewModel();
        }

        /// <summary>
        ///     NavigationViewModel
        /// </summary>
        public INavigationView NavigationView
        {
            get
            {
                return this.m_navigationView;
            }
            set
            {
                if (this.m_navigationView != value)
                {
                    this.m_navigationView = value;
                    this.OnPropertyChanged("NavigationView");
                }
            }
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
            this.NavigationView = DepInj.Container.Resolve<INavigationView>();
        }
    }
}
