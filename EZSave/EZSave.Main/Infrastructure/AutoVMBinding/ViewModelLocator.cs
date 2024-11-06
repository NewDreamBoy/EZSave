using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace EZSave.Main.Infrastructure.AutoVMBinding
{
    public static class ViewModelLocator
    {
        public static readonly DependencyProperty AutoWireViewModelProperty = DependencyProperty.RegisterAttached(
            "AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), new PropertyMetadata(false, AutoWireViewModelChanged));

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
            //是否在设计器模式下
            if (DesignerProperties.GetIsInDesignMode(d)) return;
            var viewType = d.GetType();
            //适应视图名结尾带View和不带View的的情况
            //例如：MainWindow和MainWindowView
            //MainWindow就直接在后面加ViewModel
            //MainWindowView就先去掉View再在后面加ViewModel
            var viewModelName = Regex.Replace(viewType.FullName, @"View$", "ViewModel");
            if (viewModelName == viewType.FullName) viewModelName = $"{viewType.FullName}ViewModel";  // 直接在全名后添加 "ViewModel"
            viewModelName = viewModelName.Replace(".Views.", ".ViewModels.");  // 转换命名空间
            if (string.IsNullOrEmpty(viewModelName)) return;
            var viewModelType = viewType.Assembly.GetType(viewModelName);
            if (viewModelType == null) return;
            var viewModel = App.AppServiceProvider.GetService(viewModelType);
            ((FrameworkElement)d).DataContext = viewModel;
        }
    }
}