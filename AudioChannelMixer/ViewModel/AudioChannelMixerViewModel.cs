using System.ComponentModel;

namespace AudioChannelMixer.ViewModel
{
    public class AudioChannelMixerViewModel : INotifyPropertyChanged
    {
        public AudioChannelMixerViewModel()
        {
            DeleteCommand = new RelayCommand(OnDelete,CanDelete);
        }

        public RelayCommand DeleteCommand { get; private set; }

        public string Name => "change me";

        private void OnDelete()
        {
        }

        private bool CanDelete()
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
