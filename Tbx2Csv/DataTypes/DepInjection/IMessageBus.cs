namespace Tbx2Csv.DataTypes.DepInjection
{
    using System;
    
    public interface IMessageBus
    {
        void Publish<T>(T instance);

        IObservable<T> Subscribe<T>();
    }
}
