using IoCContainersPerf.Car;
using IoCContainersPerf.IoCContainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IoCContainersPerf.Test
{
    [TestClass]
    public class CarTest
    {
        [TestMethod]
        public void TurnLeft_ConstructorInjection()
        {
            var car = UnityConfigManagerFactory.Resolve<ICar>();

            var result = car.TurnLeft();

            Assert.AreEqual("SteeringWheel is rotating to the left...", result);
        }

        [TestMethod]
        public void GetId_Singleton()
        {
            var car1 = UnityConfigManagerFactory.Resolve<ICar>();
            var car2 = UnityConfigManagerFactory.Resolve<ICar>();

            var result = car1.GetId();
            var result2 = car2.GetId();

            Assert.AreEqual(result, result2);
        }
    }
}
