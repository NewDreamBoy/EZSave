using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EZSave.Main.Common;
using EZSave.Main.Core.Services.Interfaces;
using EZSave.Main.Infrastructure;
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
        private string _title = "引导窗口";

        [ObservableProperty]
        private BitmapImage _bgImage;

        [RelayCommand]
        private void AddPlan()
        {
            Title = "添加计划";
        }

        public InitialGuidanceWindowViewModel(ILogger<InitialGuidanceWindowViewModel> logger, IGetImageService getImageService)
        {
            this._logger = logger;
            this._getImageService = getImageService;
            VmInitialize();
        }

        public override void ViewWindowInit()
        {
            BgImage = _getImageService.LoadImage("开始引导Bg.png", ImageType.Bg);
        }
    }
}