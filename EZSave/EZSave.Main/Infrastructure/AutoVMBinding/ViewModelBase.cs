using CommunityToolkit.Mvvm.ComponentModel;

namespace EZSave.Main.Infrastructure.AutoVMBinding
{
    public abstract class ViewModelBase : ObservableObject
    {
        public void VmInitialize()
        {
            ViewWindowInit();
        }
        public abstract void ViewWindowInit();
    }
}
