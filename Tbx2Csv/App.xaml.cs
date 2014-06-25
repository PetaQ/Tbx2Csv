namespace Tbx2Csv
{
    using System.Windows;

    using Logic;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;
    using Tbx2Csv.ViewModel;
    using Tbx2Csv.View;
    using System;

    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            DepInj.Container.Resolve<ILog>().Write("INFO", "Start Application");
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                var mainWindow = (Window)DepInj.Container.Resolve<IMainWindow>();
                if (mainWindow != null)
                {
                    mainWindow.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                DepInj.Container.Resolve<ILog>().Write("ERROR", string.Format("Error starting Application. Error: {0}", ex.Message));
            }
            base.OnStartup(e);
        }
    }
}
