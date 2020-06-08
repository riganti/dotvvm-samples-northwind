using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Storage;
using NorthwindStore.App.ViewModels.Admin.Base;
using NorthwindStore.BL.DTO;
using NorthwindStore.BL.Facades.Admin;
using System.Linq;

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
            // TODO: this is not very efficient because we need two database queries
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

