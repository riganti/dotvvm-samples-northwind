using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using NorthwindStore.App.ViewModels.Admin.Base;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin.Base;
using NorthwindStore.BL.Facades.Admin;

namespace NorthwindStore.App.ViewModels.Admin
{
    public class SupplierDetailViewModel : DetailPageViewModel<SupplierDetailDTO, int>
    {
        public SupplierDetailViewModel(AdminSuppliersFacade facade) : base(facade)
        {
        }

        public override string ListPageRouteName => "Admin_SupplierList";

        public override string HighlightedMenuPath => "Suppliers";

        public override string PageTitle => IsNew ? "New Supplier" : "Edit Supplier";
    }
}

