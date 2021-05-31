using System;
using System.Globalization;
using System.Threading.Tasks;
using AutoMapper.Execution;
using DotVVM.Framework.ViewModel;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin.Base;
using Riganti.Utils.Infrastructure.Core;

namespace NorthwindStore.App.ViewModels.Admin.Base
{
    public abstract class DetailPageViewModel<TDTO, TKey> : AdminViewModel, ISaveCancelViewModel 
        where TDTO : IEntity<TKey>
    {
        [Bind(Direction.None)]
        public IDetailFacade<TDTO, TKey> Facade { get; }

        public DetailPageViewModel(IDetailFacade<TDTO, TKey> facade)
        {
            this.Facade = facade;
        }


        public abstract string ListPageRouteName { get; }


        public TKey CurrentItemId { get; set; }

        public bool IsNew => Equals(CurrentItemId, default(TKey));

        public TDTO CurrentItem { get; set; }


        public override Task Init()
        {
            if (Context.Parameters.ContainsKey("Id"))
            {
                CurrentItemId = (TKey) Convert.ChangeType(Context.Parameters["Id"], typeof(TKey));
            }

            return base.Init();
        }

        public override Task PreRender()
        {
            if (!Context.IsPostBack)
            {
                if (!IsNew)
                {
                    CurrentItem = Facade.GetDetail(CurrentItemId);
                }
                else
                {
                    CurrentItem = Facade.InitializeNew();
                }
                OnItemLoaded();
            }

            return base.PreRender();
        }


        protected virtual Task OnItemLoaded()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnItemSaving()
        {
            return Task.CompletedTask;
        }

        protected virtual Task OnItemSaved()
        {
            return Task.CompletedTask;
        }


        public async Task Save()
        {
            await OnItemSaving();

            CurrentItem = Facade.Save(CurrentItem);
            CurrentItemId = CurrentItem.Id;

            await OnItemSaved();

            Context.RedirectToRoute(ListPageRouteName);
        }

        public void Cancel()
        {
            Context.RedirectToRoute(ListPageRouteName);
        }

    }
}