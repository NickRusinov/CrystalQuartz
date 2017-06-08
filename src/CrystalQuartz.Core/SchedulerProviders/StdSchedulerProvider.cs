namespace CrystalQuartz.Core.SchedulerProviders
{
    using System;
    using System.Collections.Specialized;
    using System.Threading.Tasks;
    using Quartz;
    using Quartz.Impl;

    public class StdSchedulerProvider : ISchedulerProvider
    {
        protected IScheduler _scheduler;

        protected virtual bool IsLazy
        {
            get { return false; }
        }

        public async Task Init()
        {
            if (!IsLazy)
            {
                await LazyInit();    
            }
        }

        private async Task LazyInit()
        {
            NameValueCollection properties = null;
            try
            {
                properties = GetSchedulerProperties();
                ISchedulerFactory schedulerFactory = new StdSchedulerFactory(properties);
                _scheduler = await schedulerFactory.GetScheduler();
                await InitScheduler(_scheduler);
            } 
            catch(Exception ex)
            {
                throw new SchedulerProviderException("Could not initialize scheduler", ex, properties);
            }

            if (_scheduler == null)
            {
                throw new SchedulerProviderException(
                    "Could not initialize scheduler", properties);
            }
        }

        protected virtual Task InitScheduler(IScheduler scheduler)
        {
            return Task.FromResult<object>(null);
        }

        protected virtual NameValueCollection GetSchedulerProperties()
        {
            return new NameValueCollection();
        }

        public virtual IScheduler Scheduler
        {
            get
            {
                if (_scheduler == null)
                {
                    LazyInit().GetAwaiter().GetResult();
                }

                return _scheduler;
            }
        }
    }
}