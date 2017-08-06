using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.Runtime.Filters;
using NorthwindStore.App.ViewModels;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.App.Filters
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        protected override Task OnCommandExceptionAsync(IDotvvmRequestContext context, ActionInfo actionInfo, Exception ex)
        {
            string message;
            if (ex is UIException)
            {
                message = ex.Message;
            }
            else
            {
                message = "An unknown error occured. Please try again or contact the support.";

                // TODO: logging
            }

            ((LayoutViewModel) context.ViewModel).AlertText = message;
            ((LayoutViewModel) context.ViewModel).AlertType = AlertType.Danger;
            context.IsCommandExceptionHandled = true;

            return Task.CompletedTask;
        }
    }
}
