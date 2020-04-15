namespace AudioChannelMixer.ViewModel
{
    public class AudioChannelViewModel
    {
        public AudioChannelViewModel()
        {
            CurrentViewModel = new MixerViewModel();
        }
        public object CurrentViewModel { get; set; }
    }
}
