using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Storage;
using DotVVM.Framework.ViewModel;
using NorthwindStore.App.ViewModels.Admin.Base;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin;
using NorthwindStore.BL.Facades.Admin.Base;

namespace NorthwindStore.App.ViewModels.Admin
{
    public class CategoryDetailViewModel : DetailPageViewModel<CategoryDetailDTO, int>
    {
        private readonly AdminCategoriesFacade facade;
        private readonly IUploadedFileStorage storage;

        public CategoryDetailViewModel(AdminCategoriesFacade facade, IUploadedFileStorage storage) : base(facade)
        {
            this.facade = facade;
            this.storage = storage;
        }

        public override string PageTitle => IsNew ? "Create Category" : "Edit Category";
        public override string HighlightedMenuPath => "Categories";
        public override string ListPageRouteName => "Admin_CategoryList";


        public UploadData PictureData { get; set; } = new UploadData();

        public bool PictureChanged { get; set; }


        public void RemovePicture()
        {
            CurrentItem.HasPicture = false;
            PictureData.Clear();
        }

        public void SetNewPicture()
        {
            CurrentItem.HasPicture = true;
            PictureChanged = true;
        }

        protected override void OnItemSaved()
        {
            if (PictureData.Files.Any())
            {
                var file = PictureData.Files.First();
                using (var stream = storage.GetFile(file.FileId))
                {
                    facade.SaveImage(CurrentItemId, stream);
                }
            }

            base.OnItemSaved();
        }
    }
}

