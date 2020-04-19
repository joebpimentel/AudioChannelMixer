using AudioChannelMixer.Infrastrucure;
using AudioChannelMixer.View;
using AudioChannelMixer.ViewModel;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;

namespace AudioChannelMixer.Modules
{
    internal class AudioChannelMixerModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _manager;

        public AudioChannelMixerModule(IUnityContainer container, IRegionManager manager)
        {
            _container = container;
            _manager = manager;
        }

        public void Initialize()
        {
            _container.RegisterType<IAudioChannelMixerView, AudioChannelMixerView>();
            _container.RegisterType<IAudioChannelMixerViewModel, AudioChannelMixerViewModel>();

            _container.RegisterType<ICompositeVolumeLevelView, CompositeVolumeLevelView>();
            _container.RegisterType<ICompositeVolumeLevelViewModel, CompositeVolumeLevelViewModel>();

            _manager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(AudioChannelMixerView));
        }
    }
}