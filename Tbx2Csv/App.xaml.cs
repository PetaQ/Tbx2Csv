namespace Tbx2Csv
{
    using System.Windows;

    using Logic;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;

    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DepInj.Container.Resolve<ILog>().Write("INFO", "Start Application");
        }
    }
}
