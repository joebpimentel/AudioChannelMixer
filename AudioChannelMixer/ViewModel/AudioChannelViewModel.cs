using AudioChannelMixer.View;
using Unity;

namespace AudioChannelMixer.ViewModel
{
    public class AudioChannelViewModel : IAudioChannelViewModel
    {
        public AudioChannelViewModel()
        {
            CurrentViewModel = new AudioChannelMixerViewModel();
        }

        public object CurrentViewModel { get; set; }
    }
}
