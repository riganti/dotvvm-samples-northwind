using System;
using System.Collections.Generic;
using DotVVM.Framework.ViewModel;
using NorthwindStore.BL.Facades.Admin;

namespace NorthwindStore.App.ViewModels.Admin
{
    public class ProductListOrderDialog : DotvvmViewModelBase
    {
        private readonly AdminProductsFacade facade;

        public ProductListOrderDialog(AdminProductsFacade facade)
        {
            this.facade = facade;
        }


        public event Action RefreshRequested;

        public bool IsDisplayed { get; set; }

        public int OrderedQuantity { get; set; }

        public List<int> SelectedProductIds { get; set; } = new List<int>();



        public void SubmitOrder()
        {
            facade.BatchOrder(SelectedProductIds, OrderedQuantity);

            OrderedQuantity = 0;
            IsDisplayed = false;
            SelectedProductIds.Clear();

            RefreshRequested?.Invoke();
        }

    }
}