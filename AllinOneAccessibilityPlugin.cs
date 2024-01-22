using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Nop.Core.Domain.Cms;
using Nop.Plugin.Widgets.AllinOneAccessibility.Components;
using Nop.Plugin.Widgets.AllinOneAccessibility.Data;
using Nop.Services.Cms;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Payments;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Widgets.AllinOneAccessibility
{
    /// <summary>
    /// Represents what3words plugin
    /// </summary>
    public class AllinOneAccessibilityPlugin : BasePlugin, IWidgetPlugin
    {
        #region Fields

        private readonly IActionContextAccessor _actionContextAccessor;
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        private readonly IUrlHelperFactory _urlHelperFactory;
        private readonly WidgetSettings _widgetSettings;

        #endregion

        #region Ctor

        public AllinOneAccessibilityPlugin(IActionContextAccessor actionContextAccessor,
            ILocalizationService localizationService,
            ISettingService settingService,
            IUrlHelperFactory urlHelperFactory,
            WidgetSettings widgetSettings)
        {
            _actionContextAccessor = actionContextAccessor;
            _localizationService = localizationService;
            _settingService = settingService;
            _urlHelperFactory = urlHelperFactory;
            _widgetSettings = widgetSettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the widget zones
        /// </returns>
        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(new List<string> { PublicWidgetZones.HomepageTop });
        }

        /// <summary>
        /// Gets a configuration page URL
        /// </summary>
        public override string GetConfigurationPageUrl()
        {
            return _urlHelperFactory.GetUrlHelper(_actionContextAccessor.ActionContext).RouteUrl(AllinOneAccessibilityDefaults.ConfigurationRouteName);
        }

        /// <summary>
        /// Gets a type of a view component for displaying widget
        /// </summary>
        /// <param name="widgetZone">Name of the widget zone</param>
        /// <returns>View component type</returns>
        public Type GetWidgetViewComponent(string widgetZone)
        {
            if (widgetZone is null)
                throw new ArgumentNullException(nameof(widgetZone));

           

            return typeof(AllinOneAccessibilityViewComponent);
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task InstallAsync()
        {
            await _settingService.SaveSettingAsync(new AllinOneAccessibilitySettings());

            if (!_widgetSettings.ActiveWidgetSystemNames.Contains(AllinOneAccessibilityDefaults.SystemName))
            {
                _widgetSettings.ActiveWidgetSystemNames.Add(AllinOneAccessibilityDefaults.SystemName);
                await _settingService.SaveSettingAsync(_widgetSettings);
            }

            //locales
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Plugins.Widgets.AllinOneAccessibility.Configuration"] = "Configuration",
                ["Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.Enabled"] = "Enabled",
                ["Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.ApiKey"] = "API Key",
                ["Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.Color"] = "Color",
                ["Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.Position"] = "Position",
                ["Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.IconType"] = "Icon Type",
                ["Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.IconSize"] = "Icon Size",
                ["Plugins.Widgets.AllinOneAccessibility.Configuration.Fields.Enabled.Hint"] = "Toggle to enable/disable All in One Accessibility service.",
                ["Plugins.Widgets.AllinOneAccessibility.Configuration.Failed"] = "Failed to get the generated API key",
                ["Plugins.Widgets.AllinOneAccessibility.Address.Field.Label"] = "AllinOneAccessibility address",
                ["Plugins.Widgets.AllinOneAccessibility.Address.Field.Tooltip"] = "Is your property hard to find? To help your delivery driver find your exact location, please enter your what3words delivery address.",
                ["Plugins.Widgets.AllinOneAccessibility.Address.Field.Tooltip.Link"] = "Find yours here",
               
            });

            await base.InstallAsync();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        /// <returns>A task that represents the asynchronous operation</returns>
        public override async Task UninstallAsync()
        {
            //settings
            await _settingService.DeleteSettingAsync<AllinOneAccessibilitySettings>();
            if (_widgetSettings.ActiveWidgetSystemNames.Contains(AllinOneAccessibilityDefaults.SystemName))
            {
                _widgetSettings.ActiveWidgetSystemNames.Remove(AllinOneAccessibilityDefaults.SystemName);
                await _settingService.SaveSettingAsync(_widgetSettings);
            }

            //locales
            await _localizationService.DeleteLocaleResourcesAsync("Plugins.Widgets.AllinOneAccessibility");

            await base.UninstallAsync();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether to hide this plugin on the widget list page in the admin area
        /// </summary>
        public bool HideInWidgetList => false;

        /// <summary>
        /// Gets a payment method type
        /// </summary>
        public PositionType PositionType => PositionType.TopLeft;
        #endregion
    }
}