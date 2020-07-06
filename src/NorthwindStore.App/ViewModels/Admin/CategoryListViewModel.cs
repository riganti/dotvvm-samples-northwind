using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.Framework.Controls;
using NorthwindStore.App.ViewModels.Admin.Base;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin;

namespace NorthwindStore.App.ViewModels.Admin
{
    public class CategoryListViewModel : ListPageViewModel<CategoryListDTO, int>
    {
        
        public CategoryListViewModel(AdminCategoriesFacade facade) : base(facade)
        {
        }

        public override ISortingOptions DefaultSortOptions => new SortingOptions()
        {
            SortExpression = nameof(CategoryListDTO.CategoryName)
        };

        public override string PageTitle => "Categories";

        public override string HighlightedMenuPath => "Categories";
    }
}

