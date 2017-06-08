namespace CrystalQuartz.Core.Tests
{
    using System.Threading.Tasks;
    using Quartz;
    using SchedulerProviders;

    public class SchedulerProviderStub : ISchedulerProvider
    {
        public SchedulerProviderStub(IScheduler scheduler)
        {
            Scheduler = scheduler;
        }

        public SchedulerProviderStub()
        {
        }

        public Task Init()
        {
            return Task.FromResult<object>(null);
        }

        public IScheduler Scheduler
        {
            get; set;
        }
    }
}