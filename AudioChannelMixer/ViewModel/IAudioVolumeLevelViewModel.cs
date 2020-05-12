namespace AudioChannelMixer.ViewModel
{
    public interface IAudioVolumeLevelViewModel
    {
        int VolumeLevel { get; set; }

        string ChannelName { get; set; }
    }
}