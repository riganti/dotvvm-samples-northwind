using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Runtime.Filters;
using DotVVM.Framework.ViewModel;

namespace NorthwindStore.App.ViewModels.Admin
{
    [Authorize]
    public abstract class AdminViewModel : LayoutViewModel
    {

        public abstract string HighlightedMenuPath { get; }
    }
}

