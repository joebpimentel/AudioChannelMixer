using System.Collections.ObjectModel;
using System.ComponentModel;
using AudioChannelMixer.Infrastrucure;
using AudioChannelMixer.Infrastrucure.MVVM;

namespace AudioChannelMixer.ViewModel
{
    public interface IAudioChannelMixerViewModel : IViewModel
    {
        ObservableCollection<ICompositeVolumeLevelViewModel> AudioSources { get; set; }
    }
}