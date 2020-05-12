using System.ComponentModel;
using System.Windows;
using Prism.Mvvm;

namespace AudioChannelMixer.ViewModel
{
    public sealed class CompositeVolumeLevelViewModel : BindableBase, ICompositeVolumeLevelViewModel
    {
        private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private IAudioVolumeLevelViewModel _leftChannel;
        private IAudioVolumeLevelViewModel _masterVolume;
        private IAudioVolumeLevelViewModel _rightChannel;
        private string _sourceName;

        public CompositeVolumeLevelViewModel()
        {
            if (isInDesignMode)
            {

                SourceName = "Player X";
                LeftChannel = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 30,
                    ChannelName = "Left"
                };

                RightChannel = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 70,
                    ChannelName = "Right"
                };

                MasterVolume = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 100,
                    ChannelName = "Master"
                };
            }
        }

        public CompositeVolumeLevelViewModel(string source, (int level, string name) masterChannel, (int level, string name) leftChannel, (int level, string name) rightChannel)
        {
            SourceName = source;
            MasterVolume = new AudioVolumeLevelViewModel(masterChannel);
            LeftChannel = new AudioVolumeLevelViewModel(leftChannel);
            RightChannel = new AudioVolumeLevelViewModel(rightChannel);
        }

        public IAudioVolumeLevelViewModel LeftChannel
        {
            get => _leftChannel;
            set => SetProperty(ref _leftChannel, value);
        }

        public IAudioVolumeLevelViewModel RightChannel
        {
            get => _rightChannel;
            set => SetProperty(ref _rightChannel, value);
        }

        public IAudioVolumeLevelViewModel MasterVolume
        {
            get => _masterVolume;
            set => SetProperty(ref _masterVolume, value);
        }

        public string SourceName
        {
            get => _sourceName;
            set => SetProperty(ref _sourceName, value);
        }
    }
}