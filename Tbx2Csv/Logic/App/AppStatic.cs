namespace Tbx2Csv.Logic.App
{
    using System.Reflection;
    using System.Windows;
    
    public class AppStatic
    {
        public static string ProductVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            }
        }
    }
}
