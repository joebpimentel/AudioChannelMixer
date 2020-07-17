using System.ComponentModel;
using System.Windows;
using Prism.Mvvm;

namespace AudioChannelMixer.ViewModel
{
    public class MixerInputsViewModel : BindableBase, IVolumeLevelModel
    {
        private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private IAudioVolumeLevelViewModel _leftChannel;
        private IAudioVolumeLevelViewModel _masterVolume;
        private IAudioVolumeLevelViewModel _rightChannel;

        public MixerInputsViewModel()
        {
            if (isInDesignMode)
            {

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

        public MixerInputsViewModel((int level, string name) masterChannel, (int level, string name) leftChannel, (int level, string name) rightChannel)
        {
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
    }
}