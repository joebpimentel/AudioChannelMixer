using System.Windows;
using CommonServiceLocator;
using Prism.Ioc;

namespace AudioChannelMixer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<View.AudioChannelMixerShell>();
        }
    }
}