using EZSave.WPF.Common;
using System.Windows.Media.Imaging;

namespace EZSave.WPF.Services
{
    public interface IImageService
    {
        BitmapImage LoadImage(string imageName , ImageType imageType);
    }
}