﻿namespace Tbx2Csv
{
    using System.Windows;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;
    using Tbx2Csv.View;
    using Tbx2Csv.ViewModel;

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var mainviewmodel = DepInj.Container.Resolve<IMainWindowViewModel>();
            if (mainviewmodel != null)
            {
                this.DataContext = mainviewmodel as MainWindowViewModel;
            }
        }
    }
}
