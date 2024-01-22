using Nop.Core;

namespace Nop.Plugin.Widgets.AllinOneAccessibility
{
    /// <summary>
    /// Represents plugin constants
    /// </summary>
    public static class AllinOneAccessibilityDefaults
    {
        /// <summary>
        /// Gets the system name
        /// </summary>
        public static string SystemName => "Widgets.AllinOneAccessibility";

        /// <summary>
        /// Gets the user agent used to request third-party services
        /// </summary>
        public static string UserAgent => $"nopCommerce-{NopVersion.CURRENT_VERSION}";

        /// <summary>
        /// Gets the configuration route name
        /// </summary>
        public static string ConfigurationRouteName => "Plugin.Widgets.AllinOneAccessibility.Configure";

        /// <summary>
        /// Gets the name of autosuggest component
        /// </summary>
        public static string ComponentName => "aioa";

        /// <summary>
        /// Gets a key of the attribute to store words for address
        /// </summary>
        public static string AddressValueAttribute => "AllinOneAccessibilityValue";

        /// <summary>
        /// Gets a field prefix on the checkout billing address page
        /// </summary>
        public static string BillingAddressPrefix => "BillingNewAddress";

        /// <summary>
        /// Gets a field prefix on the checkout billing address page
        /// </summary>
        public static string ShippingAddressPrefix => "ShippingNewAddress";
    }
}