using DotVVM.Framework.Controls;
using DotVVM.Framework.Controls.DynamicData;
using DotVVM.Framework.Controls.DynamicData.Metadata;
using DotVVM.Framework.Controls.DynamicData.PropertyHandlers;
using DotVVM.Framework.Controls.DynamicData.PropertyHandlers.FormEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using Microsoft.Extensions.DependencyInjection;

namespace NorthwindStore.App.Controls
{
    public class BusinessPackTextBoxFormEditorProvider : FormEditorProviderBase
    {
        public override bool CanValidate => true;


        public override bool CanHandleProperty(PropertyInfo propertyInfo, DynamicDataContext context)
        {
            return TextBoxHelper.CanHandleProperty(propertyInfo, context);
        }

        public override void CreateControl(DotvvmControl container, PropertyDisplayMetadata property, DynamicDataContext context)
        {
            var textBox = new DotVVM.BusinessPack.Controls.TextBox(context.BindingCompilationService);
            container.Children.Add(textBox);

            var cssClass = ControlHelpers.ConcatCssClasses(ControlCssClass, property.Styles?.FormControlCssClass);
            if (!string.IsNullOrEmpty(cssClass))
            {
                textBox.SetAttribute("class", cssClass);
            }

            textBox.FormatString = property.FormatString;
            textBox.SetBinding(TextBox.TextProperty, context.CreateValueBinding(property.PropertyInfo.Name));

            if (property.DataType == DataType.Password)
            {
                textBox.Type = TextBoxType.Password;
            }
            else if (property.DataType == DataType.MultilineText)
            {
                textBox.Type = TextBoxType.MultiLine;
            }

            if (textBox.IsPropertySet(DynamicEntity.EnabledProperty))
            {
                ControlHelpers.CopyProperty(textBox, DynamicEntity.EnabledProperty, textBox, TextBox.EnabledProperty);
            }
        }

    }
}
