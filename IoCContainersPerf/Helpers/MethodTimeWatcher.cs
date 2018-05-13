using System;
using System.Diagnostics;

namespace IoCContainersPerf.Helpers
{
    public class MethodTimeWatcher : IDisposable
    {
        public Stopwatch Watch;
        public string Name;

        public MethodTimeWatcher(string name)
        {
            Watch = Stopwatch.StartNew();
            Name = name;
        }

        public void Dispose()
        {
            Watch.Stop();
            var elapsedMs = Watch.ElapsedMilliseconds;
            Console.WriteLine(Name + ": " + elapsedMs + " ms.");
        }
    }
}
