﻿namespace CrystalQuartz.WebFramework.Commands
{
    using System;
    using System.Threading.Tasks;
    using CrystalQuartz.WebFramework.Utils;

    public abstract class AbstractCommand<TInput, TOutput> : ICommand<TInput> where TOutput : CommandResult, new()
    {
        public object Execute(TInput input)
        {
            var result = new TOutput
            {
                Success = true
            };

            try
            {
                InternalExecute(input, result).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.ErrorMessage = ex.FullMessage();

                HandleError(ex, input, result);
            }

            return result;
        }

        protected virtual void HandleError(Exception exception, TInput input, TOutput output)
        {
        }

        protected abstract Task InternalExecute(TInput input, TOutput output);
    }
}