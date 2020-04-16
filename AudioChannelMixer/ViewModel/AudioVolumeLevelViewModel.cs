using System.ComponentModel;
using System.Runtime.CompilerServices;
using AudioChannelMixer.Annotations;

namespace AudioChannelMixer.ViewModel
{
    public sealed class AudioVolumeLevelViewModel : IAudioVolumeLevelViewModel
    {
        private int _volumeLevel;
        public event PropertyChangedEventHandler PropertyChanged;

        public AudioVolumeLevelViewModel()
        {
            VolumeLevel = 100;
        }

        public int VolumeLevel
        {
            get => _volumeLevel;
            set
            {
                _volumeLevel = value;
                OnPropertyChanged(nameof(VolumeLevel));
            }
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}