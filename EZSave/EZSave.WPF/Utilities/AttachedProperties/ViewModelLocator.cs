using System.ComponentModel;
using System.Windows;

namespace EZSave.WPF.Utilities.AttachedProperties
{
    public static class ViewModelLocator
    {
        public static readonly DependencyProperty AutoWireViewModelProperty = DependencyProperty.RegisterAttached
            ("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoWireViewModelChanged));


        public static void SetAutoWireViewModel(DependencyObject element, bool value)
        {
            element.SetValue(AutoWireViewModelProperty, value);
        }

        public static bool GetAutoWireViewModel(DependencyObject element)
        {
            return (bool)element.GetValue(AutoWireViewModelProperty);
        }

        private static void AutoWireViewModelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (DesignerProperties.GetIsInDesignMode(d)) return;
            var viewType = d.GetType();
            var viewModelName = $"{viewType.FullName}ViewModel";  // 直接在全名后添加 "ViewModel"
            viewModelName = viewModelName.Replace(".Views.", ".ViewModels.");  // 转换命名空间
            if (string.IsNullOrEmpty(viewModelName)) return;
            var viewModelType = viewType.Assembly.GetType(viewModelName);
            if (viewModelType == null) return;
            var viewModel = App.ServiceProvider.GetService(viewModelType);
            ((FrameworkElement)d).DataContext = viewModel;
        }
    }
}