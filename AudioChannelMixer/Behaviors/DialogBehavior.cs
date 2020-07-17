using System.Windows;
using Microsoft.Win32;

namespace AudioChannelMixer.Behaviors
{
    public static class DialogBehavior
    {
        public static readonly DependencyProperty DialogVisibleProperty =
            DependencyProperty.RegisterAttached(
                "DialogVisible", typeof(bool), typeof(DialogBehavior),
                new PropertyMetadata(false, OnDialogVisibleChange));

        public static void SetDialogVisible(DependencyObject source, bool value)
        {
            source.SetValue(DialogVisibleProperty, value);
        }

        public static bool GetDialogVisible(DependencyObject source)
        {
            return (bool)source.GetValue(DialogVisibleProperty);
        }

        private static void OnDialogVisibleChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is Window parent))
            {
                return;
            }

            // when DialogVisible is set to true we create a new dialog
            // box and set its DataContext to that of its parent
            if ((bool)e.NewValue)
            {
                var openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.CheckFileExists = true;
                openFileDialog.CheckPathExists = true;
                openFileDialog.Filter = "Audio Files|*.mp3;*.ogg;*.wav" +
                                        "|All Files|*.*";
                openFileDialog.ShowDialog();
            }
        }
    }
}