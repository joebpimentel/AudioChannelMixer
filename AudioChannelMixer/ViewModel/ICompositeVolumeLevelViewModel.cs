using System.ComponentModel;

namespace AudioChannelMixer.ViewModel
{
    public interface ICompositeVolumeLevelViewModel : INotifyPropertyChanged
    {
        IAudioVolumeLevelViewModel LeftChannel { get; set; }

        IAudioVolumeLevelViewModel RightChannel { get; set; }

        IAudioVolumeLevelViewModel MasterVolume { get; set; }

        string SourceName { get; set; }
    }
}