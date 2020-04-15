using System.Windows;

namespace AudioChannelMixer.ViewModel
{
    public static class MvvmBehaviors
    {
        public static string GetLoadedMethodName(DependencyObject obj)
        {
            return (string)obj.GetValue(LoadedMethodNameProperty);
        }

        public static void SetLoadedMethodName(DependencyObject obj, string value)
        {
            obj.SetValue(LoadedMethodNameProperty, value);
        }

        public static readonly DependencyProperty LoadedMethodNameProperty =
            DependencyProperty.RegisterAttached("LoadedMethodName",
            typeof(string), typeof(MvvmBehaviors), new PropertyMetadata(null, OnLoadedMethodNameChanged));

        private static void OnLoadedMethodNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement element)
            {

                element.Loaded += (s, e2) =>
                {
                    var viewModel = element.DataContext;
                    if (viewModel == null) return;
                    var methodInfo = viewModel.GetType().GetMethod(e.NewValue.ToString());
                    if (methodInfo != null) methodInfo.Invoke(viewModel, null);
                };
            }
        }
    }
}
