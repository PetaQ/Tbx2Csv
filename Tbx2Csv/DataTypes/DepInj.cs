namespace Tbx2Csv.DataTypes
{
    using LightCore;
    using LightCore.Lifecycle;
    
    using Tbx2Csv.DataTypes.DepInjection;
    using Tbx2Csv.Logic;

    public static class DepInj
    {
        /// <summary>
        ///     Field Container
        /// </summary>
        private static IContainer m_container;

        /// <summary>
        ///     Container
        /// </summary>
        public static IContainer Container 
        { 
            get
            {
                if (m_container == null)
                {
                    Register();
                }
                return m_container;
            }
        }

        /// <summary>
        ///     Build 
        /// </summary>
        private static void Register()
        {
            var builder = new ContainerBuilder();

            builder.Register<ILog, Log>().ControlledBy<SingletonLifecycle>();

            m_container = builder.Build();
        }
    }

    
}
