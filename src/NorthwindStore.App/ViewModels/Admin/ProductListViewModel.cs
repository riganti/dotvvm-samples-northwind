using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using NorthwindStore.App.ViewModels.Admin.Base;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin;
using NorthwindStore.BL.Facades.Admin.Base;

namespace NorthwindStore.App.ViewModels.Admin
{
    public class ProductListViewModel : FilteredListPageViewModel<ProductListDTO, int, ProductFilterDTO>
    {
        private readonly BaseListsFacade baseListsFacade;

        public ProductListViewModel(AdminProductsFacade facade, BaseListsFacade baseListsFacade, ProductListOrderDialog productListOrderDialog) : base(facade)
        {
            this.baseListsFacade = baseListsFacade;

            OrderDialog = productListOrderDialog;
        }

        public override string PageTitle => "Products";
        public override string HighlightedMenuPath => "Products";
        public override ISortingOptions DefaultSortOptions => new SortingOptions()
        {
            SortExpression = nameof(ProductListDTO.ProductName)
        };


        [Bind(Direction.ServerToClientFirstRequest)]
        public List<CategoryBasicDTO> Categories => baseListsFacade.GetCategories();

        [Bind(Direction.ServerToClientFirstRequest)]
        public List<SupplierBasicDTO> Suppliers => baseListsFacade.GetSuppliers();



        public ProductListOrderDialog OrderDialog { get; set; }


        public override Task Init()
        {
            OrderDialog.RefreshRequested += () =>
            {
                Items.RequestRefresh();
            };

            return base.Init();
        }
    }
}

