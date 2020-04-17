using System.Windows;
using AudioChannelMixer.Services;
using AudioChannelMixer.View;
using AudioChannelMixer.ViewModel;
using CommonServiceLocator;
using Prism.Ioc;
using Prism.Unity;
using Unity;

namespace AudioChannelMixer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetContainer().RegisterType<IAudioService, AudioService>(nameof(AudioService), TypeLifetime.Singleton);
            containerRegistry.GetContainer().RegisterType<IAudioChannelMixerView, AudioChannelMixerView>();
            containerRegistry.GetContainer().RegisterType<IAudioChannelMixerViewModel, AudioChannelMixerViewModel>();
            //containerRegistry.GetContainer().RegisterType<IAudioChannelMixerViewModel, AudioChannelMixerViewModel>(
            //    new InjectionConstructor(containerRegistry.GetContainer().Resolve<AudioService>()));
        }

        protected override Window CreateShell()
        {
            return ServiceLocator.Current.GetInstance<AudioChannelMixerView>();
        }
    }
}