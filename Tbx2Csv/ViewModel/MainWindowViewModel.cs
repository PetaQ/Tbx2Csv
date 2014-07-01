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

        private NavigationView m_navigationView;
        private View.StartView m_startView;

        /// <summary>
        ///     Konstruktor
        /// </summary>
        public MainWindowViewModel()
        {
            this.InitViewModel();

            DepInj.Container.Resolve<IMessageBus>().Subscribe(this.ChangeView);
        }

        public NavigationView NavigationView
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

        public StartView StartView
        {
            get
            {
                return this.m_startView;
            }
            set
            {
                if (this.m_startView != value)
                {
                    this.m_startView = value;
                    this.OnPropertyChanged("StartView");
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

        public void ChangeView()
        {

        }

        /// <summary>
        ///     Init ViewModel
        /// </summary>
        private void InitViewModel()
        {
            this.Tbx2CsvVersion = AppStatic.ProductVersion;

            var navigationViewModel = new NavigationViewModel();
            this.NavigationView = new NavigationView(navigationViewModel);

            var startViewModel = new StartViewModel();
            this.StartView = new StartView(startViewModel);
        }
    }
}
