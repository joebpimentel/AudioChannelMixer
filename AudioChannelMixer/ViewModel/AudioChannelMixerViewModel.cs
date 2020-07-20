using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using AudioChannelMixer.Infrastrucure.Command;
using Prism.Mvvm;

namespace AudioChannelMixer.ViewModel
{
    public class AudioChannelMixerViewModel : BindableBase, IAudioChannelMixerViewModel
    {
        private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private ObservableCollection<ICompositeVolumeLevelViewModel> _audioSources;
        private MixerOutputLevelViewModel _mixerVolumes;

        public AudioChannelMixerViewModel()
        {
            AudioSources = new ObservableCollection<ICompositeVolumeLevelViewModel>();
            AddAudio = new AsyncCommand(AddAudioCommandAsync, CanAddAudio);
            PopulateInstance();
            if (isInDesignMode)
            {
                PopulateInstance();
            }
        }

        public IAsyncCommand AddAudio { get; }

        private async Task AddAudioCommandAsync()
        {
            AudioSources.Add(new CompositeVolumeLevelViewModel());
            await Task.FromResult(0);
        }

        private bool CanAddAudio()
        {
            return AudioSources.Count < 4;
        }

        // public RelayCommand DeleteCommand { get; private set; }
        // public string Name => "change me";
        public ObservableCollection<ICompositeVolumeLevelViewModel> AudioSources
        {
            get => _audioSources;
            set => SetProperty(ref _audioSources, value);
        }

        public MixerOutputLevelViewModel MixerVolumes
        {
            get => _mixerVolumes;
            set => SetProperty(ref _mixerVolumes, value);
        }

        private void PopulateInstance()
        {
            ICompositeVolumeLevelViewModel audioSource1 = new CompositeVolumeLevelViewModel("Player 1", (level: 0, name: "Master"), (level: 50, name: "Left"), (level: 100, name: "Right"));
            ICompositeVolumeLevelViewModel audioSource2 = new CompositeVolumeLevelViewModel("Player 2", (level: 33, name: "Master"), (level: 66, name: "Left"), (level: 99, name: "Right"));
            AudioSources = new ObservableCollection<ICompositeVolumeLevelViewModel> { audioSource1, audioSource2 };
            MixerVolumes = new MixerOutputLevelViewModel((level: 30, name: "Master"), (level: 50, name: "Left"), (level: 100, name: "Right"));
        }
    }
}
