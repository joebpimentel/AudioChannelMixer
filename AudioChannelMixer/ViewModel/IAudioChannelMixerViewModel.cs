using System.Collections.ObjectModel;
using System.ComponentModel;

namespace AudioChannelMixer.ViewModel
{
    public interface IAudioChannelMixerViewModel : INotifyPropertyChanged
    {
        ObservableCollection<CompositeVolumeLevelViewModel> AudioSources { get; set; }
    }
}