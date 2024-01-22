using Nop.Core.Configuration;
using Nop.Plugin.Widgets.AllinOneAccessibility.Data;

namespace Nop.Plugin.Widgets.AllinOneAccessibility
{
    /// <summary>
    /// Represents plugin settings
    /// </summary>
    public class AllinOneAccessibilitySettings : ISettings
    {
        /// <summary>
        /// Gets or sets the API key
        /// </summary>
        public string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plugin is enabled
        /// </summary>
        public bool Enabled { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether the plugin is color
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plugin is Position
        /// </summary>
        public PositionType Position { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plugin is IconType
        /// </summary>
        public IconTypes IconType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the plugin is IconSize
        /// </summary>
        public IconSizes IconSize { get; set; }
    }
}