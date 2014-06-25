namespace Tbx2Csv.View
{
    using System.Windows.Controls;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;
    using Tbx2Csv.ViewModel;

    /// <summary>
    /// Interaktionslogik für NavigationView.xaml
    /// </summary>
    public partial class NavigationView : UserControl, INavigationView
    {
        public NavigationView()
        {
            InitializeComponent();
            
            var viewmodel = DepInj.Container.Resolve<INavigationViewModel>();
            if (viewmodel != null)
            {
                this.DataContext = viewmodel;
            }

        }
    }
}
