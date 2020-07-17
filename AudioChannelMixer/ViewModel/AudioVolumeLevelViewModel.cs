using System;
using AudioChannelMixer.Services;
using Microsoft.Practices.Unity;
using Prism.Mvvm;

namespace AudioChannelMixer.ViewModel
{
    public sealed class AudioVolumeLevelViewModel : BindableBase, IAudioVolumeLevelViewModel
    {
        private int _volumeLevel;
        private string _channelName;

        public AudioVolumeLevelViewModel()
        {
            VolumeLevel = 100;
            ChannelName = "Left";
        }

        [InjectionConstructor]
        public AudioVolumeLevelViewModel(IAudioService audioService)
        {
            var audios = audioService.MediaDictionary;
            Console.WriteLine(audios.Keys.ToString());
        }

        public AudioVolumeLevelViewModel((int level, string name) channel)
        {
            VolumeLevel = channel.level;
            ChannelName = channel.name;
        }

        public int VolumeLevel
        {
            get => _volumeLevel;
            set => SetProperty(ref _volumeLevel, value);
        }

        public string ChannelName
        {
            get => _channelName;
            set => SetProperty(ref _channelName, value);
        }

        public double PaddingWidth => _channelName == "Master" ? 0.0 : 25.0;
    }
}