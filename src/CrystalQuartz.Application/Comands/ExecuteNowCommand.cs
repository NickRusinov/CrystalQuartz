namespace CrystalQuartz.Application.Comands
{
    using System.Threading.Tasks;
    using CrystalQuartz.Application.Comands.Inputs;
    using CrystalQuartz.Core;
    using CrystalQuartz.Core.SchedulerProviders;
    using Quartz;

    public class ExecuteNowCommand : AbstractOperationCommand<JobInput>
    {
        public ExecuteNowCommand(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider) : base(schedulerProvider, schedulerDataProvider)
        {
        }

        protected override async Task PerformOperation(JobInput input)
        {
            await Scheduler.TriggerJob(new JobKey(input.Job, input.Group));
        }
    }
}