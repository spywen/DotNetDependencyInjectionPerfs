using System;

namespace IoCContainersPerf.Car
{
    public class Identification : IIdentification
    {
        private string _id;
        public string Id
        {
            get
            {
                if (_id == null)
                {
                    _id = GetId();
                }
                return _id;
            }
        }

        private string GetId()
        {
            return Guid.NewGuid().ToString();
        }
    }

    public interface IIdentification
    {
        string Id { get; }
    }
}
