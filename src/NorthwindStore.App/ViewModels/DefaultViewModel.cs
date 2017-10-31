using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Hosting;
using DotVVM.Framework.ViewModel;
using Microsoft.AspNetCore.Authentication;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades;

namespace NorthwindStore.App.ViewModels
{
    public class DefaultViewModel : LayoutViewModel
    {
        private readonly LoginFacade loginFacade;

        public DefaultViewModel(LoginFacade loginFacade)
        {
            this.loginFacade = loginFacade;
        }

        public override string PageTitle => "Sign In";

        public LoginDTO Login { get; set; } = new LoginDTO();


        public async Task SignIn()
        {
            var identity = loginFacade.SignIn(Login);
            if (identity == null)
            {
                AlertText = "The credentials are not valid!";
                AlertType = AlertType.Danger;
                return;
            }

            await Context.GetAuthentication().SignInAsync("Cookie", identity);
            Context.RedirectToRoute("Admin_RegionList");
        }
    }
}

