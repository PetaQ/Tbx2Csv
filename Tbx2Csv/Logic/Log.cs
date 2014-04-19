namespace Tbx2Csv.Logic
{
    using NLog;
    using System;

    public static class Log
    {
        /// <summary>
        ///     Static Field Instance
        /// </summary>
        public static Logger Instance { get; set; }

        /// <summary>
        ///     Write Message to LogFile
        /// </summary>
        /// <param name="message">String Message</param>
        public static void Write(string category, string message)
        {
            try
            {
                Instance = LogManager.GetCurrentClassLogger();

                if (Instance != null)
                {
                    if (!string.IsNullOrEmpty(message) && !string.IsNullOrEmpty(category))
                    {
                        switch(category)
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
                        }
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
