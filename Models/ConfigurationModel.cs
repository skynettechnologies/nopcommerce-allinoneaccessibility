using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Widgets.AllinOneAccessibility.Models
{
    /// <summary>
    /// Represents plugin configuration model
    /// </summary>
    public record ConfigurationModel : BaseNopModel
    {
        [NopResourceDisplayName("Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.Enabled")]
        public bool Enabled { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.ApiKey")]
        public string ApiKey { get; set; }
        public string ApiKey_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.Color")]
        public string Color { get; set; }
        public string Color_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.Position")]
        public int Position { get; set; }
        public string Position_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.IconType")]
        public int IconType { get; set; }
        public bool IconType_OverrideForStore { get; set; }

        [NopResourceDisplayName("Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.IconSize")]
        public int IconSize { get; set; }
        public bool IconSize_OverrideForStore { get; set; }
    }
}