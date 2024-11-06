using CommunityToolkit.Mvvm.ComponentModel;

namespace EZSave.Main.Infrastructure.AutoVMBinding
{
    public abstract class ViewModelBase : ObservableObject
    {
        /// <summary>
        /// ViewModel初始化工作
        /// </summary>
        public void VmInitialize()
        {
            ViewWindowInit();
        }
        public abstract void ViewWindowInit();
    }
}
