namespace IoCContainersPerf.Car
{
    public class Car : ICar
    {
        private ISteeringWheel steeringWheel;
        private IIdentification identification;

        public Car(ISteeringWheel steeringWheel, IIdentification identification)
        {
            this.steeringWheel = steeringWheel;
            this.identification = identification;
        }

        public string GetId()
        {
            return identification.Id;
        }

        public string TurnLeft()
        {
            return steeringWheel.Rotate("left");
        }
    }

    public interface ICar
    {
        string TurnLeft();

        string GetId();
    }
}
