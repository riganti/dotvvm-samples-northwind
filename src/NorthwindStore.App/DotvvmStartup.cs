using DotVVM.Framework;
using DotVVM.Framework.Configuration;
using DotVVM.Framework.Routing;
using NorthwindStore.App.Controls;
using NorthwindStore.App.Filters;
using NorthwindStore.App.Presenters;
using DotVVM.Framework.Controls.DynamicData;

namespace NorthwindStore.App
{
    public class DotvvmStartup : IDotvvmStartup
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            config.AddBusinessPackConfiguration();
            config.AddDynamicDataConfiguration();

            config.Runtime.GlobalFilters.Add(new ErrorHandlingFilter());

            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/default.dothtml");
            
            // category image presenter
            config.RouteTable.Add("CategoryImage", "image/category/{Id}", null, null, Startup.Resolve<CategoryImagePresenter>);

            // auto-discovery strategy for admin section
            config.RouteTable.AutoDiscoverRoutes(new AdminRouteStrategy(config));    
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            config.Markup.AddMarkupControl("cc", "SaveCancelButtons", "Controls/SaveCancelButtons.dotcontrol");
            config.Markup.AddMarkupControl("cc", "ProductListOrderDialog", "Controls/ProductListOrderDialog.dotcontrol");
            config.Markup.AddMarkupControl("cc", "NewItemButton", "Controls/NewItemButton.dotcontrol");

            config.Markup.AddCodeControls("cc", typeof(TextBoxFormField));
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
        }
    }
}
