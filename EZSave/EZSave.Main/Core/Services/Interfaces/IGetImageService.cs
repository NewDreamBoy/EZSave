using EZSave.Main.Common;
using System.Windows.Media.Imaging;

namespace EZSave.Main.Core.Services.Interfaces
{
    public interface IGetImageService
    {
        BitmapImage LoadImage(string imageName, ImageType imageType);
    }
}