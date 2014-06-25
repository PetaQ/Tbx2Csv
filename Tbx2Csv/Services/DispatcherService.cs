namespace Tbx2Csv.Services
{
    using System;
    using System.Windows;
    using System.Windows.Threading;

    public static class DispatcherService
    {
        public static void Invoke(Action action)
        {
            Dispatcher dispatcher = Application.Current.Dispatcher;
            if (dispatcher == null || dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.Invoke(action);
            }
        }
    }
}
