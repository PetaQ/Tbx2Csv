namespace Tbx2Csv.ViewModel
{
    using System.Windows;
    using Tbx2Csv.DataTypes.DepInjection;
    
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public MainWindowViewModel()
        {
            base.DisplayName = "Tbx2Csv";
        }
    }
}
