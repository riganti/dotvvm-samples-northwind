using System;
using System.Threading.Tasks;
using Castle.Facilities.TypedFactory;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Remotion.Linq.Parsing;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.App.ViewModels
{
    public abstract class LayoutViewModel : DotvvmViewModelBase 
    {

        public abstract string PageTitle { get; }


        [Bind(Direction.ServerToClient)]
        public string AlertText { get; set; }

        [Bind(Direction.ServerToClient)]
        public AlertType AlertType { get; set; }


        [Bind(Direction.ServerToClientFirstRequest)]
        public string CurrentUserName => Context.HttpContext.User.Identity.Name;



        public async Task SignOut()
        {
            await Context.GetAspNetCoreContext().SignOutAsync("Cookie");
            Context.RedirectToRoute("Default");
        }



        protected bool ExecuteSafe(Action action, string errorMessage = null)
        {
            try
            {
                action();
                return true;
            }
            catch (DotvvmInterruptRequestExecutionException)
            {
                // we must not catch DotvvmInterruptRequestExecutionException otherwise the redirects will break
                throw;
            }
            catch (UIException ex)
            {
                errorMessage = ex.Message;
            }
            catch (Exception)
            {
                if (errorMessage == null)
                {
                    errorMessage = "An unknown error occured. Please try again or contact the support.";
                }
            }

            AlertText = errorMessage;
            AlertType = AlertType.Danger;

            return false;
        }
    }
}