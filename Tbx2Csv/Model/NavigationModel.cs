namespace Tbx2Csv.Model
{
    using System.ComponentModel;
    using Tbx2Csv.Services;
    using Tbx2Csv.ViewModel;

    public class NavigationModel : IDataErrorInfo
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Error
        {
            get { throw new System.NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}
