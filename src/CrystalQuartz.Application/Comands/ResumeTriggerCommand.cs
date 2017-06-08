namespace CrystalQuartz.Application.Comands
{
    using System.Threading.Tasks;
    using CrystalQuartz.Application.Comands.Inputs;
    using CrystalQuartz.Core;
    using CrystalQuartz.Core.SchedulerProviders;
    using Quartz;

    public class ResumeTriggerCommand : AbstractOperationCommand<TriggerInput>
    {
        public ResumeTriggerCommand(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider) : base(schedulerProvider, schedulerDataProvider)
        {
        }

        protected override async Task PerformOperation(TriggerInput input)
        {
            var triggerKey = new TriggerKey(input.Trigger, input.Group);
            await Scheduler.ResumeTrigger(triggerKey);
        }
    }
}