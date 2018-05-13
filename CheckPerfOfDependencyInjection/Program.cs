using CheckPerfOfDependencyInjection.DepInjFactories;
using CheckPerfOfDependencyInjection.Helpers;
using Ninject;
using System;

namespace CheckPerfOfDependencyInjection
{
    class Program
    {
        public const int Iterations = 100000;

        static void Main(string[] args)
        {
            using (var mtw = new MethodTimeWatcher("WITHOUT DEPENDENCY INJECTION"))
            {
                for (var i = 0; i < Iterations; i++)
                {
                    var instance = new MyBusiness();
                    var result = instance.Sum(1, 1);
                }
            }

            using (var mtw = new MethodTimeWatcher("WITH DEPENDENCY INJECTION (UNITY)"))
            {
                for (var i = 0; i < Iterations; i++)
                {
                    var instance = UnityCodeManagerFactory.Resolve<IMyBusiness>();
                    var result = instance.Sum(1, 1);
                }
            }

            using (var mtw = new MethodTimeWatcher("WITH DEPENDENCY INJECTION (UNITY APP.CONFIG)"))
            {
                for (var i = 0; i < Iterations; i++)
                {
                    var instance = UnityConfigManagerFactory.Resolve<IMyBusiness>();
                    var result = instance.Sum(1, 1);
                }
            }

            using (var mtw = new MethodTimeWatcher("WITH DEPENDENCY INJECTION (STRUCTUREMAP)"))
            {
                for (var i = 0; i < Iterations; i++)
                {
                    var instance = SMManagerFactory.Resolve<IMyBusiness>();
                    var result = instance.Sum(1, 1);
                }
            }

            using (var mtw = new MethodTimeWatcher("WITH DEPENDENCY INJECTION (NINJECT)"))
            {
                Ninject.IKernel kernel = new StandardKernel(new NInjectManagerFactory());
                for (var i = 0; i < Iterations; i++)
                {
                    var instance = kernel.Get<IMyBusiness>();
                    var result = instance.Sum(1, 1);
                }
            }


            Console.WriteLine(" --- End of the program --- ");
            Console.ReadKey();
        }
    }
}
