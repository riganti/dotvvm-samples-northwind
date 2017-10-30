using DotVVM.Framework.Controls.DynamicData.Configuration;
using DotVVM.Framework.Controls.DynamicData.PropertyHandlers.FormEditors;
using NorthwindStore.App.Controls;
using NorthwindStore.App.Resources;
using NorthwindStore.BL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindStore.App
{
    public class AppDynamicDataConfiguration : DynamicDataConfiguration
    {

        public AppDynamicDataConfiguration()
        {
            FormBuilders[""] = new CustomFormBuilder();

            FormEditorProviders.RemoveAll(p => p is TextBoxEditorProvider);
            FormEditorProviders.Add(new BusinessPackTextBoxFormEditorProvider());

            ErrorMessagesResourceFile = typeof(ErrorMessages);
            PropertyDisplayNamesResourceFile = typeof(PropertyNames);
            UseLocalizationResourceFiles = true;

            SetComboBoxConventions();
        }

        private void SetComboBoxConventions()
        {
            var conventions = new ComboBoxConventions();
            conventions.Register(p => p.Name.EndsWith("CategoryId"), new DotVVM.Framework.Controls.DynamicData.Annotations.ComboBoxSettingsAttribute()
            {
                DataSourceBinding = "_root.Categories",
                DisplayMember = nameof(CategoryBasicDTO.CategoryName),
                ValueMember = nameof(CategoryBasicDTO.Id),
                EmptyItemText = "(select category)"
            });
            conventions.Register(p => p.Name.EndsWith("SupplierId"), new DotVVM.Framework.Controls.DynamicData.Annotations.ComboBoxSettingsAttribute()
            {
                DataSourceBinding = "_root.Suppliers",
                DisplayMember = nameof(SupplierBasicDTO.CompanyName),
                ValueMember = nameof(SupplierBasicDTO.Id),
                EmptyItemText = "(select supplier)"
            });

            var provider = new ComboBoxConventionFormEditorProvider(conventions);
            FormEditorProviders.Insert(0, provider);
        }
    }
}
