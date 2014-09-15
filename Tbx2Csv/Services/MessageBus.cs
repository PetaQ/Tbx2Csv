namespace Tbx2Csv.Services
{
    using System;
    using System.Collections.Generic;
    using Tbx2Csv.DataTypes.DepInjection;
    using System.Reactive.Subjects;
    using System.Reactive.Linq;
    
    public sealed class MessageBus : IMessageBus
    {
        /// <summary>
        ///     Subscribers List
        /// </summary>
        private Dictionary<Type, List<object>> m_Subscribers = new Dictionary<Type, List<object>>();

        /// <summary>
        ///     Subscribe MessageBus
        /// </summary>
        /// <param name="handler"></param>
        public void Subscribe(Action handler)
        {
            if (this.m_Subscribers.ContainsKey(typeof(string)))
            {
                var handlers = this.m_Subscribers[typeof(string)];
                handlers.Add(handler);
            }
            else
            {
                var handlers = new List<object>();
                handlers.Add(handler);
                this.m_Subscribers[typeof(string)] = handlers;
            }
        }

        /// <summary>
        ///     Unsubscribe MessageBus
        /// </summary>
        /// <param name="handler"></param>
        public void Unsubscribe(Action handler)
        {
            if (this.m_Subscribers.ContainsKey(typeof(string)))
            {
                var handlers = this.m_Subscribers[typeof(string)];
                handlers.Remove(handler);

                if (handlers.Count == 0)
                {
                    this.m_Subscribers.Remove(typeof(string));
                }
            }
        }

        /// <summary>
        ///     Publish Message
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public void Publish<T>(T message)
        {
            var messageType = message.GetType();
            if (this.m_Subscribers.ContainsKey(messageType))
            {
                var handlers = this.m_Subscribers[messageType];
                foreach (var handler in handlers)
                {
                    var actionType = handler.GetType();
                    var invoke = actionType.GetMethod("Invoke", new Type[] { messageType });
                    if (invoke != null)
                    {
                        invoke.Invoke(handler, new Object[] { message });
                    }
                }
            }
        }

        /// <summary>
        ///     Publish Message
        /// </summary>
        /// <param name="message">Message</param>
        public void Publish(object message)
        {
            var messageType = message.GetType();
            if (this.m_Subscribers.ContainsKey(messageType))
            {
                var handlers = this.m_Subscribers[messageType];
                foreach(var handler in handlers)
                {
                    var actionType = handler.GetType();
                    var invoke = actionType.GetMethod("Invoke", new Type[] { messageType });
                    if (invoke != null)
                    {
                        invoke.Invoke(handler, new Object[] { message });
                    }
                }
            }
        }
    }
}
