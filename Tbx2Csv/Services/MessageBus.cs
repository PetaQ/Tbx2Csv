namespace Tbx2Csv.Services
{
    using System;
    using System.Collections.Generic;
    using Tbx2Csv.DataTypes.DepInjection;
    using System.Reactive.Subjects;
    using System.Reactive.Linq;
    
    public sealed class MessageBus : IMessageBus, IDisposable
    {
        private readonly Subject<object> m_subscribers;

        public MessageBus()
        {
            this.m_subscribers = new Subject<object>();
        }

        public void Publish<T>(T instance)
        {
            this.m_subscribers.OnNext(instance);
        }

        public IObservable<T> Subscribe<T>()
        {
            return this.m_subscribers.OfType<T>().AsObservable();
        }
    
        public void Dispose()
        {
            this.m_subscribers.Dispose();
        }
    }
}
