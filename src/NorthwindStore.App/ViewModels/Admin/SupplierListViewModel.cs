using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using NorthwindStore.App.ViewModels.Admin.Base;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin.Base;
using NorthwindStore.BL.Facades.Admin;

namespace NorthwindStore.App.ViewModels.Admin
{
    public class SupplierListViewModel : ListPageViewModel<SupplierListDTO, int>
    {
        public SupplierListViewModel(AdminSuppliersFacade facade) : base(facade)
        {
        }

        public override ISortingOptions DefaultSortOptions => new SortingOptions()
        {
            SortExpression = nameof(SupplierListDTO.CompanyName)
        };

        public override string HighlightedMenuPath => "Suppliers";

        public override string PageTitle => "Suppliers";
    }
}

