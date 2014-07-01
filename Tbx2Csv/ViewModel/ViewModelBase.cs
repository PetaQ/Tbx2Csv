namespace Tbx2Csv.ViewModel
{
    using Logic;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;

    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        ///     Display Name of the MVVM ViewMode
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        ///     PropertyChangedEventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Log Message to ApplicationLogFile
        /// </summary>
        /// <param name="message">String Message</param>
        /// <param name="category">String Category</param>
        public void LogWrite(string category, string message)
        {
            DepInj.Container.Resolve<ILog>().Write(category, message);
        }

        /// <summary>
        ///     OnPropertyChanged Event
        /// </summary>
        /// <param name="name">String Property</param>
        protected virtual void OnPropertyChanged(string name)
        {
            this.CheckProperty(name);

            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(name);
                handler(this, e);
            }
        }

        /// <summary>
        ///     Check Property is real
        /// </summary>
        /// <param name="name"></param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void CheckProperty(string name)
        {
            if (TypeDescriptor.GetProperties(this)[name] == null)
            {
                var msg = string.Format("Invalid property name: {0}", name);

                if (this.ThrowOnInvalidPropertyName)
                {
                    throw new Exception(msg);
                }
                else
                {
                    Debug.Fail(msg);
                }
            }
        }


        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose()
        {
        }

        public virtual bool ThrowOnInvalidPropertyName { get; private set; }
    }
}
