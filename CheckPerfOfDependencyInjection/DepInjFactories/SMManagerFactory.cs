using StructureMap;

namespace CheckPerfOfDependencyInjection.DepInjFactories
{
    public class SMManagerFactory
    {
        private static Container _container;
        public static Container Container
        {
            get
            {
                if (_container == null)
                {
                    _container = InitializeDepInj();
                }
                return _container;
            }
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.GetInstance<T>() != null)
            {
                return Container.GetInstance<T>();
            }

            return ret;
        }

        private static Container InitializeDepInj()
        {
            return new Container(_ =>
            {
                _.For<IMyBusiness>().Use<MyBusiness>();
            });
        }
    }
}
