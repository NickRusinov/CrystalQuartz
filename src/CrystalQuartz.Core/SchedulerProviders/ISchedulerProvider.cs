namespace CrystalQuartz.Core.SchedulerProviders
{
    using System.Threading.Tasks;
    using Quartz;

    public interface ISchedulerProvider
    {
        /// <summary>
        /// Initializes provider and creates all necessary instances 
        /// (scheduler factory and scheduler itself).
        /// </summary>
        Task Init();

        /// <summary>
        /// Gets scheduler instance. Should return same instance on every call.
        /// </summary>
        IScheduler Scheduler { get; }
    }
}