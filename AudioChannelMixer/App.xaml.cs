using System.Windows;
using AudioChannelMixer.View;
using AudioChannelMixer.ViewModel;
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
            containerRegistry.Register<IAudioChannelMixerShell, AudioChannelMixerShell>();
            containerRegistry.Register<IAudioVolumeLevelView, AudioVolumeLevelView>();
            containerRegistry.Register<IAudioChannelViewModel, AudioChannelViewModel>();
            
        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<View.AudioChannelMixerShell>();
        }
    }
}