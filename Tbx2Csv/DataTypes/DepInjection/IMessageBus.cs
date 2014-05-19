namespace Tbx2Csv.DataTypes.DepInjection
{
    using System;

    public interface IMessageBus
    {
        void Subscribe(Action handler);
        
        void Unsubscribe(Action handler);

        void Publish(object message);
    }
}
