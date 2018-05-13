using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace IoCContainersPerf.IoCContainers
{
    public class UnityConfigManagerFactory
    {
        #region Variables
        private static IUnityContainer _container;
        #endregion

        public UnityConfigManagerFactory() { }

        #region Properties
        public static IUnityContainer Container
        {
            get
            {
                if (_container == null)
                {
                    // -- Method 1: simple using app/web.config file. WARNING: require to chanbe '<container>' as '<container name="unityContainer">'
                    //_container = new UnityContainer().LoadConfiguration("unityContainer");

                    // -- Method 2: simple 2 using app/web.config file
                    //_container = new UnityContainer();
                    //((UnityConfigurationSection)ConfigurationManager.GetSection("unity")).Configure(_container);

                    // -- Method 3: using specific file
                    var fileMap = new ExeConfigurationFileMap
                    {
                        ExeConfigFilename = "unity.config"
                    };
                    System.Configuration.Configuration configuration =
                        ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                    var unitySection = (UnityConfigurationSection)configuration.GetSection("unity");

                    _container = new UnityContainer();
                    unitySection.Configure(_container, "containerOne");
                }
                return _container;
            }
        }

        public static T Resolve<T>()
        {
            T ret = default(T);

            if (Container.IsRegistered(typeof(T)))
            {
                ret = Container.Resolve<T>();
            }

            return ret;
        }
        #endregion
    }
}
