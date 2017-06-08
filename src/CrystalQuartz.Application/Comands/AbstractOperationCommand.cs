namespace CrystalQuartz.Application.Comands
{
    using System.Threading.Tasks;
    using CrystalQuartz.Application.Comands.Outputs;
    using CrystalQuartz.Application.Helpers;
    using CrystalQuartz.Core;
    using CrystalQuartz.Core.SchedulerProviders;

    public abstract class AbstractOperationCommand<TInput> : AbstractSchedulerCommand<TInput, SchedulerDataOutput>
    {
        protected AbstractOperationCommand(ISchedulerProvider schedulerProvider, ISchedulerDataProvider schedulerDataProvider) : base(schedulerProvider, schedulerDataProvider)
        {
        }

        protected override async Task InternalExecute(TInput input, SchedulerDataOutput output)
        {
            await PerformOperation(input);
            
            var data = await SchedulerDataProvider.GetData();
            data.MapToOutput(output);
        }

        protected abstract Task PerformOperation(TInput input);
    }
}