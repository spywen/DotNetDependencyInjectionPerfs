using Microsoft.Practices.Unity;

namespace CheckPerfOfDependencyInjection.DepInjFactories
{
    public class UnityCodeManagerFactory
    {
        #region Variables
        private static UnityContainer _container;
        #endregion

        #region Properties
        public static UnityContainer Container
        {
            get { return _container ?? (_container = new UnityContainer()); }
        }
        #endregion

        #region Constructor
        static UnityCodeManagerFactory()
        {
            SetDefaultDependencies();
        }
        #endregion

        #region Public Methods
        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }

        public static void SetDefaultDependencies()
        {
            Container.RegisterType<IMyBusiness, MyBusiness>(new TransientLifetimeManager());
        }

        #endregion
    }
}
