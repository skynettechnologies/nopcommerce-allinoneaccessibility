using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Core.Caching;
using Nop.Plugin.Widgets.AllinOneAccessibility.Models;
using Nop.Services.Configuration;
using Nop.Services.Media;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.AllinOneAccessibility.Components
{
    public class AllinOneAccessibilityViewComponent : NopViewComponent
    {
        #region Fields

        private readonly IStoreContext _storeContext;
        private readonly IStaticCacheManager _staticCacheManager;
        private readonly ISettingService _settingService;
        private readonly IPictureService _pictureService;
        private readonly IWebHelper _webHelper;
        private readonly AllinOneAccessibilitySettings _allinOneAccessibilitySettings;

        #endregion

        #region Ctor

        public AllinOneAccessibilityViewComponent(IStoreContext storeContext,
            IStaticCacheManager staticCacheManager,
            ISettingService settingService,
            IPictureService pictureService,
            IWebHelper webHelper,
            AllinOneAccessibilitySettings allinOneAccessibilitySettings)
        {

            _storeContext = storeContext;
            _staticCacheManager = staticCacheManager;
            _settingService = settingService;
            _pictureService = pictureService;
            _webHelper = webHelper;
            _allinOneAccessibilitySettings = allinOneAccessibilitySettings;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoke the widget view component
        /// </summary>
        /// <param name="widgetZone">Widget zone</param>
        /// <param name="additionalData">Additional parameters</param>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the view component result
        /// </returns>
        public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
        {
            var model = new ConfigurationModel {
                Enabled= _allinOneAccessibilitySettings.Enabled,
                ApiKey = _allinOneAccessibilitySettings.ApiKey,
                Color = _allinOneAccessibilitySettings.Color,
                Position = (int)_allinOneAccessibilitySettings.Position,
                IconType = (int)_allinOneAccessibilitySettings.IconType,
                IconSize = (int)_allinOneAccessibilitySettings.IconSize,
               
            };
           return View("~/Plugins/Widgets.AllinOneAccessibility/Views/PublicInfo.cshtml", model);

        }

        #endregion
    }
}