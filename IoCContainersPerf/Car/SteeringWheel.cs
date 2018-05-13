namespace IoCContainersPerf.Car
{
    public class SteeringWheel : ISteeringWheel
    {
        public string Rotate(string direction)
        {
            return $"SteeringWheel is rotating to the {direction}...";
        }
    }

    public interface ISteeringWheel
    {
        string Rotate(string direction);
    }
}
