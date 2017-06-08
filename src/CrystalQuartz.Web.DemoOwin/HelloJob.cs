namespace CrystalQuartz.Web.DemoOwin
{
    using System;
    using System.Threading.Tasks;
    using Quartz;

    public class HelloJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello, CrystalQuartz!");

            return Task.FromResult<object>(null);
        }
    }
}