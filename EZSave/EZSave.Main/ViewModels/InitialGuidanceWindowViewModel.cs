using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EZSave.Main.Common;
using EZSave.Main.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Media.Imaging;
using EZSave.Main.Infrastructure.AutoVMBinding;

namespace EZSave.Main.ViewModels
{
    public partial class InitialGuidanceWindowViewModel : ViewModelBase
    {
        private readonly ILogger<InitialGuidanceWindowViewModel> _logger;
        private readonly IGetImageService _getImageService;

        [ObservableProperty]
        private string _title = "添加计划";

        #region 图片资源

        [ObservableProperty]
        private BitmapImage _bgImage;

        [ObservableProperty]
        private BitmapImage _AddPlanIcon;

        #endregion


        [RelayCommand]
        private void AddPlan()
        {
           
        }

        public InitialGuidanceWindowViewModel(ILogger<InitialGuidanceWindowViewModel> logger, IGetImageService getImageService)
        {
            this._logger = logger;
            this._getImageService = getImageService;
            VmInitialize();
        }

        public override void ViewWindowInit()
        {
            BgImage = _getImageService.LoadImage("引导页-开始引导Bg.png", ImageType.Bg);
            AddPlanIcon = _getImageService.LoadImage("引导页-添加.png", ImageType.Icon);
        }
    }
}