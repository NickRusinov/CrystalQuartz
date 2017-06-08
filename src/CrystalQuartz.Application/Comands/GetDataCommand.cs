namespace CrystalQuartz.Application.Comands
{
    using System.Threading.Tasks;
    using CrystalQuartz.Application.Comands.Inputs;
    using CrystalQuartz.Core;
    using CrystalQuartz.Core.SchedulerProviders;

    public class GetDataCommand : AbstractOperationCommand<NoInput>
    {
        public GetDataCommand(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider) : base(schedulerProvider, schedulerDataProvider)
        {
        }

        protected override Task PerformOperation(NoInput input)
        {
            return Task.FromResult<object>(null);
        }
    }
}