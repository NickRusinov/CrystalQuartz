namespace CrystalQuartz.Application.Comands
{
    using System.Threading.Tasks;
    using CrystalQuartz.Application.Comands.Inputs;
    using CrystalQuartz.Core;
    using CrystalQuartz.Core.SchedulerProviders;

    public class StartSchedulerCommand : AbstractOperationCommand<NoInput>
    {
        public StartSchedulerCommand(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider) : base(schedulerProvider, schedulerDataProvider)
        {
        }

        protected override async Task PerformOperation(NoInput input)
        {
            await Scheduler.Start();
        }
    }
}