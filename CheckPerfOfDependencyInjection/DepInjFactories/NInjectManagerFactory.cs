using Ninject.Modules;

namespace CheckPerfOfDependencyInjection.DepInjFactories
{
    public class NInjectManagerFactory : NinjectModule
    {
        public override void Load() 
        {
            this.Bind<IMyBusiness>().To<MyBusiness>();
        }
    }
}
