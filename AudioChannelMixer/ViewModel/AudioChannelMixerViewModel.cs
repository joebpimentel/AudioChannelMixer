using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using AudioChannelMixer.Annotations;
using AudioChannelMixer.Services;
using Unity;

namespace AudioChannelMixer.ViewModel
{
    public class AudioChannelMixerViewModel : IAudioChannelMixerViewModel
    {
        private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());

        private ObservableCollection<CompositeVolumeLevelViewModel> _audioSources;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public AudioChannelMixerViewModel()
        {
            // TODO: Since prism / unit versions are different I didn't succeed yet to make it work with DI
            //if (!isInDesignMode)
            //{
            //    MessageBox.Show("Exception: You should not call this constructor in production mode", nameof(AudioChannelMixerViewModel));
            //    throw new ApplicationException("Exception: You should not call this constructor in production mode");
            //}

            PopulateInstance();
        }

        [InjectionConstructor]
        public AudioChannelMixerViewModel(
            IAudioService audioService)
        {
            Console.Write(audioService.PlayersDictionary.Keys.ToString());

            PopulateInstance();
        }

        public RelayCommand DeleteCommand { get; private set; }

        public string Name => "change me";

        public ObservableCollection<CompositeVolumeLevelViewModel> AudioSources
        {
            get => _audioSources;
            set
            {
                _audioSources = value;
                OnPropertyChanged(nameof(AudioSources));
            }
        }

        private void OnDelete()
        {
        }

        private bool CanDelete()
        {
            return true;
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PopulateInstance()
        {
            var audioSource1 = new CompositeVolumeLevelViewModel
            {
                LeftChannel = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 0,
                    ChannelName = "Left"
                },

                RightChannel = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 0,
                    ChannelName = "Right"
                },

                MasterVolume = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 0,
                    ChannelName = "Master"
                },

                SourceName = "Player 1"
            };

            var audioSource2 = new CompositeVolumeLevelViewModel
            {
                LeftChannel = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 0,
                    ChannelName = "Left"
                },

                RightChannel = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 0,
                    ChannelName = "Right"
                },

                MasterVolume = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 0,
                    ChannelName = "Master"
                },

                SourceName = "Player 2"
            };

            AudioSources = new ObservableCollection<CompositeVolumeLevelViewModel> { audioSource1, audioSource2 };

            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }
    }
}
