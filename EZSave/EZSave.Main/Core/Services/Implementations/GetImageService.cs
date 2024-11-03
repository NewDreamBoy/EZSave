using EZSave.Main.Common;
using EZSave.Main.Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Windows.Media.Imaging;

namespace EZSave.Main.Core.Services.Implementations
{
    public class GetImageService : IGetImageService
    {
        private ILogger<GetImageService> _logger;

        public GetImageService(ILogger<GetImageService> logger)
        {
            _logger = logger;
        }

        public BitmapImage LoadImage(string imageName, ImageType imageType)
        {
            try
            {
                var path = "";
                switch (imageType)
                {
                    case ImageType.Bg:
                        path = "Resources/Images/Bg/" + imageName;
                        break;

                    case ImageType.Icon:
                        path = "Resources/Images/Icon/" + imageName;
                        break;

                    case ImageType.Ui:
                        path = "Resources/Images/Ui/" + imageName;
                        break;
                }

                if (!string.IsNullOrWhiteSpace(path))
                {
                    var uri = new Uri("pack://application:,,,/EZSave.Main;component/" + path);
                    var image = new BitmapImage(uri);
                    return image;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "加载图片失败");
            }
            return null;
        }
    }
}