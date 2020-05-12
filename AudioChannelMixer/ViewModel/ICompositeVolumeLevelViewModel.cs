using AudioChannelMixer.Infrastrucure;

namespace AudioChannelMixer.ViewModel
{
    public interface ICompositeVolumeLevelViewModel : IViewModel
    {
        IAudioVolumeLevelViewModel LeftChannel { get; set; }

        IAudioVolumeLevelViewModel RightChannel { get; set; }

        IAudioVolumeLevelViewModel MasterVolume { get; set; }

        string SourceName { get; set; }
    }
}