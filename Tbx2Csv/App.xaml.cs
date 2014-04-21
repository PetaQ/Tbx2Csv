namespace Tbx2Csv
{
    using System.Windows;

    using Logic;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;
    using Tbx2Csv.ViewModel;
    using Tbx2Csv.View;

    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DepInj.Container.Resolve<ILog>().Write("INFO", "Start Application");


            var viewmodel = new MainViewModel();
            var view = new MainView(viewmodel);

            var window = new MainWindow();
            window.DataContext = view;

            window.ShowDialog();
        }
    }
}
