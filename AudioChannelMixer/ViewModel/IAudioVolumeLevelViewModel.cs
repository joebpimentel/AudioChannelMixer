using System.ComponentModel;

namespace AudioChannelMixer.ViewModel
{
    public interface IAudioVolumeLevelViewModel : INotifyPropertyChanged
    {
        int VolumeLevel { get; set; }

        string ChannelName { get; set; }
    }
}