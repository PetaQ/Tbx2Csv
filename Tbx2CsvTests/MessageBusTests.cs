namespace Tbx2CsvTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Tbx2Csv.DataTypes;
    using Tbx2Csv.DataTypes.DepInjection;

    [TestClass]
    public class MessageBusTests
    {
        public bool m_work = false;

        [TestMethod]
        public void MessageBusTest()
        {
            var messagebus = DepInj.Container.Resolve<IMessageBus>();

            var message = "Testme if you can.";

            Action testmethod = delegate() { this.TestMethod(message); };

            messagebus.Subscribe(testmethod);

            messagebus.Publish(message);

            messagebus.Unsubscribe(testmethod);

            Assert.IsTrue(this.m_work);
        }

        public void TestMethod(string test)
        {
            if (!string.IsNullOrEmpty(test))
            {
                if (test == "Testme if you can.")
                {
                    this.m_work = true;
                }
            }
        }
    }
}
