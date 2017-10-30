using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.ViewModel;
using NorthwindStore.App.ViewModels.Admin.Base;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin;
using NorthwindStore.BL.Facades.Admin.Base;

namespace NorthwindStore.App.ViewModels.Admin
{
    public class ProductDetailViewModel : DetailPageViewModel<ProductDetailDTO, int>
    {
        private readonly BaseListsFacade baseListsFacade;

        public ProductDetailViewModel(AdminProductsFacade facade, BaseListsFacade baseListsFacade) : base(facade)
        {
            this.baseListsFacade = baseListsFacade;
        }


        public override string PageTitle => IsNew ? "New Product" : "Edit Product";
        public override string HighlightedMenuPath => "Products";
        public override string ListPageRouteName => "Admin_ProductList";



        [Bind(Direction.ServerToClientFirstRequest)]
        public List<CategoryBasicDTO> Categories => baseListsFacade.GetCategories();

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<SupplierBasicDTO> Suppliers => baseListsFacade.GetSuppliers();
    }
}

