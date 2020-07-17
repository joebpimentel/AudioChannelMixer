using AudioChannelMixer.Infrastrucure.MVVM;

namespace AudioChannelMixer.ViewModel
{
    public interface IVolumeLevelModel : IViewModel
    {
        IAudioVolumeLevelViewModel LeftChannel { get; set; }

        IAudioVolumeLevelViewModel RightChannel { get; set; }

        IAudioVolumeLevelViewModel MasterVolume { get; set; }
    }
}