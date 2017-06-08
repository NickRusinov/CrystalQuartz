namespace CrystalQuartz.Application.Comands
{
    using System.Threading.Tasks;
    using CrystalQuartz.Application.Comands.Inputs;
    using CrystalQuartz.Core;
    using CrystalQuartz.Core.SchedulerProviders;
    using Quartz;
    using Quartz.Impl.Matchers;

    public class ResumeGroupCommand : AbstractOperationCommand<GroupInput>
    {
        public ResumeGroupCommand(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider) : base(schedulerProvider, schedulerDataProvider)
        {
        }

        protected override async Task PerformOperation(GroupInput input)
        {
            await Scheduler.ResumeJobs(GroupMatcher<JobKey>.GroupEquals(input.Group));
        }
    }
}