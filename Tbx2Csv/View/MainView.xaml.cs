namespace Tbx2Csv.View
{
    using System.Windows;
    using System.Windows.Controls;
    using Tbx2Csv.ViewModel;

    /// <summary>
    /// Interaktionslogik für MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView(MainViewModel viewmodel)
        {
            InitializeComponent();
            this.DataContext = viewmodel;
        }
    }
}
