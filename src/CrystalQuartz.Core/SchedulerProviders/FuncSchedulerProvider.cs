namespace CrystalQuartz.Core.SchedulerProviders
{
    using System;
    using System.Threading.Tasks;
    using Quartz;

    public class FuncSchedulerProvider : ISchedulerProvider
    {
        private readonly Func<IScheduler> _factory;

        public FuncSchedulerProvider(Func<IScheduler> factory)
        {
            _factory = factory;
        }

        public Task Init()
        {
            return Task.FromResult<object>(null);
        }

        public IScheduler Scheduler
        {
            get
            {
                return _factory.Invoke();
            }
        }
    }
}