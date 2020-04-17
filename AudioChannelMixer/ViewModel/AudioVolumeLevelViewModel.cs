using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AudioChannelMixer.Annotations;
using AudioChannelMixer.Services;
using Unity;

namespace AudioChannelMixer.ViewModel
{
    public sealed class AudioVolumeLevelViewModel : IAudioVolumeLevelViewModel
    {
        private int _volumeLevel;
        private string _channelName;

        public event PropertyChangedEventHandler PropertyChanged;

        public AudioVolumeLevelViewModel()
        {
            VolumeLevel = 100;
            ChannelName = "Left";
        }

        [InjectionConstructor]
        public AudioVolumeLevelViewModel(IAudioService audioService)
        {
            var audios = audioService.PlayersDictionary;
            Console.WriteLine(audios.Keys.ToString());
        }

        public int VolumeLevel
        {
            get => _volumeLevel;
            set
            {
                _volumeLevel = value;
                OnPropertyChanged(nameof(VolumeLevel));
            }
        }

        public string ChannelName
        {
            get => _channelName;
            set
            {
                _channelName = value;
                OnPropertyChanged(nameof(ChannelName));
            }
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}