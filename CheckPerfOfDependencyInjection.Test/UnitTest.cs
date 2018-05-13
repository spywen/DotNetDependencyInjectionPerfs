using CheckPerfOfDependencyInjection.DepInjFactories;
//UNITY
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject;
//MOCKING FRAMEWORKS
using Rhino.Mocks;

namespace CheckPerfOfDependencyInjection.Test
{
    [TestClass]
    public class UnitTest
    {
        //1 + 1 = 3

        private int _leftNumberExpected = 1;
        private int _rightNumberExpected = 1;
        private int _totalNumberExpected = 3;

        private int _leftNumber = 1;
        private int _rightNumber = 1;
        private int _fakeTotalNumber = 3;

        [TestMethod, TestCategory("RhinoMock"), TestCategory("Unity code")]
        public void UnityCodeRhinoMock()
        {
            var mock = Rhino.Mocks.MockRepository.GenerateMock<IMyBusiness>();
            mock.Stub(x => x.Sum(Arg<int>.Is.Equal(_leftNumberExpected), Arg<int>.Is.Equal(_rightNumberExpected))).Return(_fakeTotalNumber);
            UnityCodeManagerFactory.Container.RegisterInstance(mock);

            var myBiz = UnityCodeManagerFactory.Resolve<IMyBusiness>();
            var total = myBiz.Sum(_leftNumber, _rightNumber);

            Assert.AreEqual(_totalNumberExpected, total);
        }

        [TestMethod, TestCategory("Moq"), TestCategory("Unity code")]
        public void UnityCodeMoq()
        {
            var mock = new Mock<IMyBusiness>();
            mock.Setup(x => x.Sum(It.Is<int>(y => y.Equals(_leftNumberExpected)), It.Is<int>(y => y.Equals(_rightNumberExpected)))).Returns(_fakeTotalNumber);
            UnityCodeManagerFactory.Container.RegisterInstance(mock.Object);

            var myBiz = UnityCodeManagerFactory.Resolve<IMyBusiness>();
            var total = myBiz.Sum(_leftNumber, _rightNumber);

            Assert.AreEqual(_totalNumberExpected, total);
        }

        [TestMethod, TestCategory("RhinoMock"), TestCategory("Unity config")]
        public void UnityConfigRhinoMock()
        {
            var mock = Rhino.Mocks.MockRepository.GenerateMock<IMyBusiness>();
            mock.Stub(x => x.Sum(Arg<int>.Is.Equal(_leftNumberExpected), Arg<int>.Is.Equal(_rightNumberExpected))).Return(_fakeTotalNumber);
            UnityConfigManagerFactory.Container.RegisterInstance(mock);

            var myBiz = UnityConfigManagerFactory.Resolve<IMyBusiness>();
            var total = myBiz.Sum(_leftNumber, _rightNumber);

            Assert.AreEqual(_totalNumberExpected, total);
        }

        [TestMethod, TestCategory("Moq"), TestCategory("Unity config")]
        public void UnityConfigMoq()
        {
            var mock = new Mock<IMyBusiness>();
            mock.Setup(x => x.Sum(It.Is<int>(y => y.Equals(_leftNumberExpected)), It.Is<int>(y => y.Equals(_rightNumberExpected)))).Returns(_fakeTotalNumber);
            UnityConfigManagerFactory.Container.RegisterInstance(mock.Object);

            var myBiz = UnityConfigManagerFactory.Resolve<IMyBusiness>();
            var total = myBiz.Sum(_leftNumber, _rightNumber);

            Assert.AreEqual(_totalNumberExpected, total);
        }

        [TestMethod, TestCategory("RhinoMock"), TestCategory("StructureMap")]
        public void StructureMapRhinoMock()
        {
            var mock = Rhino.Mocks.MockRepository.GenerateMock<IMyBusiness>();
            mock.Stub(x => x.Sum(Arg<int>.Is.Equal(_leftNumberExpected), Arg<int>.Is.Equal(_rightNumberExpected))).Return(_fakeTotalNumber);
            SMManagerFactory.Container.Inject(mock);

            var myBiz = SMManagerFactory.Resolve<IMyBusiness>();
            var total = myBiz.Sum(_leftNumber, _rightNumber);

            Assert.AreEqual(_totalNumberExpected, total);
        }

        [TestMethod, TestCategory("Moq"), TestCategory("StructureMap")]
        public void StructureMapMoq()
        {
            var mock = new Mock<IMyBusiness>();
            mock.Setup(x => x.Sum(It.Is<int>(y => y.Equals(_leftNumberExpected)), It.Is<int>(y => y.Equals(_rightNumberExpected)))).Returns(_fakeTotalNumber);
            SMManagerFactory.Container.Inject(mock);

            var myBiz = SMManagerFactory.Resolve<IMyBusiness>();
            var total = myBiz.Sum(_leftNumber, _rightNumber);

            Assert.AreEqual(_totalNumberExpected, total);
        }

        [TestMethod, TestCategory("RhinoMock"), TestCategory("NInject")]
        public void NInjectRhinoMock()
        {
            var mock = Rhino.Mocks.MockRepository.GenerateMock<IMyBusiness>();
            mock.Stub(x => x.Sum(Arg<int>.Is.Equal(_leftNumberExpected), Arg<int>.Is.Equal(_rightNumberExpected))).Return(_fakeTotalNumber);
            SMManagerFactory.Container.Inject(mock);


            Ninject.IKernel kernel = new StandardKernel(new NInjectManagerFactory());
            var instance = kernel.Get<IMyBusiness>();

            var myBiz = SMManagerFactory.Resolve<IMyBusiness>();
            var total = myBiz.Sum(_leftNumber, _rightNumber);

            Assert.AreEqual(_totalNumberExpected, total);
        }

        [TestMethod, TestCategory("Moq"), TestCategory("NInject")]
        public void NInjectMoq()
        {
            var mock = new Mock<IMyBusiness>();
            mock.Setup(x => x.Sum(It.Is<int>(y => y.Equals(_leftNumberExpected)), It.Is<int>(y => y.Equals(_rightNumberExpected)))).Returns(_fakeTotalNumber);
            SMManagerFactory.Container.Inject(mock);

            var myBiz = SMManagerFactory.Resolve<IMyBusiness>();
            var total = myBiz.Sum(_leftNumber, _rightNumber);

            Assert.AreEqual(_totalNumberExpected, total);
        }
    }
}
