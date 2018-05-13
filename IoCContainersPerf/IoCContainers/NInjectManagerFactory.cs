using Ninject.Modules;

namespace IoCContainersPerf.IoCContainers
{
    public class NInjectManagerFactory : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMyBusiness>().To<MyBusiness>();
        }
    }
}
