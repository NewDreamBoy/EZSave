using EZSave.WPF.Common;
using System.Windows.Media.Imaging;
using Microsoft.Extensions.Logging;

namespace EZSave.WPF.Services
{
    public class ImageService : IImageService
    {
        private ILogger<ImageService> _logger;

        public ImageService(ILogger<ImageService> logger)
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
                    var uri = new Uri("pack://application:,,,/EZSave.WPF;component/" + path);
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