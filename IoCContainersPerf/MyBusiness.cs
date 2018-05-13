namespace IoCContainersPerf
{
    public class MyBusiness: IMyBusiness
    {
        public int Sum(int a, int b)
        {
            return a + b;
        }
    }

    public interface IMyBusiness
    {
        int Sum(int a, int b);
    }
}
