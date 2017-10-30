using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.BusinessPack.Controls;
using DotVVM.Framework.Controls;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Hosting;
using DotVVM.Utils.HtmlElements;
using TextBox = DotVVM.Framework.Controls.TextBox;

namespace NorthwindStore.App.Controls
{
    public class TextBoxFormField : HtmlGenericControl
    {
        public TextBoxFormField() : base("div")
        {
        }
        


        [MarkupOptions(AllowBinding = false)]
        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }
        public static readonly DotvvmProperty LabelTextProperty
            = DotvvmProperty.Register<string, TextBoxFormField>(c => c.LabelText, "");


        [MarkupOptions(AllowHardCodedValue = false)]
        public IValueBinding TextBinding
        {
            get { return (IValueBinding)GetValue(TextBindingProperty); }
            set { SetValue(TextBindingProperty, value); }
        }
        public static readonly DotvvmProperty TextBindingProperty
            = DotvvmProperty.Register<IValueBinding, TextBoxFormField>(c => c.TextBinding, null);


        [MarkupOptions(AllowBinding = false)]
        public TextBoxFormFieldSize Size
        {
            get { return (TextBoxFormFieldSize)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }
        public static readonly DotvvmProperty SizeProperty
            = DotvvmProperty.Register<TextBoxFormFieldSize, TextBoxFormField>(c => c.Size, TextBoxFormFieldSize.Full);



        protected override void OnInit(IDotvvmRequestContext context)
        {
            var textBinding = GetValueBinding(TextBindingProperty);
            
            // set my properties
            this.Attributes["class"] = "form-field";
            this.SetBinding(Validator.ValueProperty, textBinding);

            // create label
            var label = new HtmlGenericControl("label");
            label.InnerText = LabelText;
            this.Children.Add(label);

            // create div for TextBox
            var div = new HtmlGenericControl("div");
            this.Children.Add(div);

            // create TextBox
            var textBox = new DotVVM.BusinessPack.Controls.TextBox();
            textBox.SetBinding(TextBox.TextProperty, textBinding);
            if (Size == TextBoxFormFieldSize.Short)
            {
                textBox.AddCssClass("short");
            }
            div.Children.Add(textBox);
            
            base.OnInit(context);
        }
    }

    public enum TextBoxFormFieldSize
    {
        Full,
        Short
    }
}

