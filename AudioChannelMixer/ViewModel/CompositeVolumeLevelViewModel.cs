using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace AudioChannelMixer.ViewModel
{
    public sealed class CompositeVolumeLevelViewModel : ICompositeVolumeLevelViewModel
    {
        private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private IAudioVolumeLevelViewModel _leftChannel;
        private IAudioVolumeLevelViewModel _masterVolume;
        private IAudioVolumeLevelViewModel _rightChannel;
        private string _sourceName;

        public event PropertyChangedEventHandler PropertyChanged;

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
            set
            {
                _leftChannel = value;
                OnPropertyChanged(nameof(LeftChannel));
            }
        }

        public IAudioVolumeLevelViewModel RightChannel
        {
            get => _rightChannel;
            set
            {
                _rightChannel = value;
                OnPropertyChanged(nameof(RightChannel));
            }
        }

        public IAudioVolumeLevelViewModel MasterVolume
        {
            get => _masterVolume;
            set
            {
                _masterVolume = value;
                OnPropertyChanged(nameof(MasterVolume));
            }
        }

        public string SourceName
        {
            get => _sourceName;
            set
            {
                _sourceName = value;
                OnPropertyChanged(nameof(SourceName));
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}