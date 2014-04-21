namespace Tbx2Csv.Logic.Logging
{
    using NLog;
    using System;
    using Tbx2Csv.DataTypes.DepInjection;

    public class Log : ILog
    {
        /// <summary>
        ///     Static Field Instance
        /// </summary>
        private static Logger Instance = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Write Message to LogFile
        /// </summary>
        /// <param name="message">String Message</param>
        public void Write(string category, string message)
        {
            try
            {
                if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(category))
                {
                    switch (category)
                    {
                        case "DEBUG":
                            Instance.Debug(message);
                            break;
                        case "INFO":
                            Instance.Info(message);
                            break;
                        case "FATAL":
                            Instance.Fatal(message);
                            break;
                        case "ERROR":
                            Instance.Error(message);
                            break;
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                Instance.ErrorException(ex.Message, ex);
            }
        }
    }
}
