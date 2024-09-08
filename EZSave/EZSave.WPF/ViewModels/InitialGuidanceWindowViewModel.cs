using System.Windows.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EZSave.WPF.Common;
using EZSave.WPF.Services;
using Microsoft.Extensions.Logging;

namespace EZSave.WPF.ViewModels
{
    public partial class InitialGuidanceWindowViewModel : ViewModelBase
    {

        private readonly ILogger<InitialGuidanceWindowViewModel> _logger;
        private readonly IImageService _imageService;

        public InitialGuidanceWindowViewModel(ILogger<InitialGuidanceWindowViewModel> logger, IImageService imageService)
        {
            this._logger = logger;
            this._imageService = imageService;
            BgImage = _imageService.LoadImage("开始引导Bg.png", ImageType.Bg);
        }
  

        [ObservableProperty]
        private string _title = "引导窗口";

        [ObservableProperty]
        private BitmapImage _bgImage;


        [RelayCommand]
        private void AddPlan()
        {
            Title = "添加计划";
        }

        public override void ViewWindowInit()
        {
            BgImage = _imageService.LoadImage("开始引导Bg.png", ImageType.Bg);
        }
    }
}