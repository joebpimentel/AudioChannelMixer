using System.Collections.ObjectModel;
using System.ComponentModel;
using AudioChannelMixer.Infrastrucure;

namespace AudioChannelMixer.ViewModel
{
    public interface IAudioChannelMixerViewModel : IViewModel
    {
        ObservableCollection<ICompositeVolumeLevelViewModel> AudioSources { get; set; }
    }
}