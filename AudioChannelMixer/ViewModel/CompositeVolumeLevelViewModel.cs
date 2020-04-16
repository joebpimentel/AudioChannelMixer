using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AudioChannelMixer.ViewModel
{
    public class CompositeVolumeLevelViewModel
    {
        public CompositeVolumeLevelViewModel()
        {
            Audios = new ObservableCollection<AudioVolumeLevelViewModel>
            {
                new AudioVolumeLevelViewModel(),
                new AudioVolumeLevelViewModel()
            };

        }

        public ObservableCollection<AudioVolumeLevelViewModel> Audios { get; }
    }
}