using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Plugin.Widgets.AllinOneAccessibility.Models;
using Nop.Plugin.Widgets.AllinOneAccessibility.Services;
using Nop.Plugin.Widgets.AllinOneAccessibility.Data;
using Nop.Services.Configuration;
using Nop.Services.Localization;
using Nop.Services.Logging;
using Nop.Services.Messages;
using Nop.Services.Security;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Widgets.AllinOneAccessibility.Controllers
{
    [AuthorizeAdmin]
    [Area(AreaNames.Admin)]
    [AutoValidateAntiforgeryToken]
    public class AllinOneAccessibilityController : BasePluginController
    {
        #region Fields

        private readonly ILocalizationService _localizationService;
        private readonly ILogger _logger;
        private readonly INotificationService _notificationService;
        private readonly IPermissionService _permissionService;
        private readonly ISettingService _settingService;
        private readonly IStoreContext _storeContext;
        private readonly IWorkContext _workContext;
        private readonly AllinOneAccessibilityHttpClient _allinOneAccessibilityHttpClient;
        private readonly AllinOneAccessibilitySettings _allinOneAccessibilitySettings;

        #endregion

        #region Ctor

        public AllinOneAccessibilityController(ILocalizationService localizationService,
            ILogger logger,
            INotificationService notificationService,
            IPermissionService permissionService,
            ISettingService settingService,
            IStoreContext storeContext,
            IWorkContext workContext,
            AllinOneAccessibilityHttpClient allinOneAccessibilityHttpClient,
            AllinOneAccessibilitySettings allinOneAccessibilitySettings)
        {
            _localizationService = localizationService;
            _logger = logger;
            _notificationService = notificationService;
            _permissionService = permissionService;
            _settingService = settingService;
            _storeContext = storeContext;
            _workContext = workContext;
            _allinOneAccessibilityHttpClient = allinOneAccessibilityHttpClient;
            _allinOneAccessibilitySettings = allinOneAccessibilitySettings;
        }

        #endregion

        #region Methods

        public async Task<IActionResult> Configure()
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            var model = new ConfigurationModel
            {
                Enabled = _allinOneAccessibilitySettings.Enabled,
                ApiKey = _allinOneAccessibilitySettings.ApiKey,
                Color = _allinOneAccessibilitySettings.Color,
                Position = (int)_allinOneAccessibilitySettings.Position,
                IconType = (int)_allinOneAccessibilitySettings.IconType,
                IconSize = (int)_allinOneAccessibilitySettings.IconSize,
            };

            return View("~/Plugins/Widgets.AllinOneAccessibility/Views/Configure.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Configure(ConfigurationModel model)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManageWidgets))
                return AccessDeniedView();

            if (!ModelState.IsValid)
                return await Configure();

            _allinOneAccessibilitySettings.ApiKey = model.ApiKey;

            _allinOneAccessibilitySettings.Enabled = model.Enabled;
            _allinOneAccessibilitySettings.Color = model.Color;
            _allinOneAccessibilitySettings.Position = (PositionType)model.Position;
            _allinOneAccessibilitySettings.IconType = (IconTypes)model.IconType;
            _allinOneAccessibilitySettings.IconSize = (IconSizes)model.IconSize;
            await _settingService.SaveSettingAsync(_allinOneAccessibilitySettings);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.Plugins.Saved"));

            return await Configure();
        }
    }

    #endregion
}