using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.ViewModel;
using NorthwindStore.BL.Facades.Admin.Base;

namespace NorthwindStore.App.ViewModels.Admin.Base
{
    public abstract class FilteredListPageViewModel<TDTO, TKey, TFilterDTO> : AdminViewModel 
        where TDTO : new() 
        where TFilterDTO : new()
    {
        [Bind(Direction.None)]
        public IFilteredListFacade<TDTO, TKey, TFilterDTO> Facade { get; }

        public FilteredListPageViewModel(IFilteredListFacade<TDTO, TKey, TFilterDTO> facade)
        {
            this.Facade = facade;
        }


        [Bind(Direction.None)]
        public abstract ISortingOptions DefaultSortOptions { get; }

        public BusinessPackDataSet<TDTO> Items { get; set; }

        public TFilterDTO Filter { get; set; } = new TFilterDTO();

        public override Task Init()
        {
            Items = new BusinessPackDataSet<TDTO>()
            {
                PagingOptions =
                {
                    PageSize = 50
                },
                SortingOptions = DefaultSortOptions
            };

            return base.Init();
        }

        public override Task PreRender()
        {
            if (!Context.IsPostBack || Items.IsRefreshRequired)
            {
                LoadData();
            }

            return base.PreRender();
        }

        private void LoadData()
        {
            OnDataLoading();
            Facade.FillDataSet(Items, Filter);
            OnDataLoaded();
        }

        public void ApplyFilter()
        {
            Items.RequestRefresh();
        }

        public void Delete(TKey id)
        {
            OnItemDeleting(id);
            Facade.Delete(id);
            OnItemDeleted(id);
        }

        protected virtual void OnDataLoading()
        {
        }

        protected virtual void OnDataLoaded()
        {
        }

        protected virtual void OnItemDeleting(TKey id)
        {
        }

        protected virtual void OnItemDeleted(TKey id)
        {
        }
    }
}