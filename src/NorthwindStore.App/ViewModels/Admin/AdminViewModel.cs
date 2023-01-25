using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Hosting;
using System.Threading.Tasks;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.Framework.ViewModel;

namespace NorthwindStore.App.ViewModels.Admin
{
    //[Authorize]
    public abstract class AdminViewModel : LayoutViewModel
    {
        public override async Task Init()
        {
            await Context.Authorize();

            await base.Init();
        }
        public abstract string HighlightedMenuPath { get; }
    }
}

