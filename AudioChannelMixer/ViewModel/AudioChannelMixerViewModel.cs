using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AudioChannelMixer.ViewModel
{
    public class AudioChannelMixerViewModel : IAudioChannelMixerViewModel
    {
        // private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private ObservableCollection<ICompositeVolumeLevelViewModel> _audioSources;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public AudioChannelMixerViewModel()
        {
            // TODO: Since prism / unit versions are different I didn't succeed yet to make it work with DI
            //if (!isInDesignMode)
            //{
            //    MessageBox.Show("Exception: You should not call this constructor in production mode", nameof(AudioChannelMixerViewModel));
            //    throw new ApplicationException("Exception: You should not call this constructor in production mode");
            //}
            // View = new AudioChannelMixerView { ViewModel = this };
            AudioSources = new ObservableCollection<ICompositeVolumeLevelViewModel>();
            PopulateInstance();
        }

        // public RelayCommand DeleteCommand { get; private set; }
        // public string Name => "change me";
        public ObservableCollection<ICompositeVolumeLevelViewModel> AudioSources
        {
            get => _audioSources;
            set
            {
                _audioSources = value;
                OnPropertyChanged(nameof(AudioSources));
                foreach (var compositeVolume in AudioSources)
                {
                    PropertyChanged?.Invoke(compositeVolume, new PropertyChangedEventArgs(nameof(compositeVolume)));
                    PropertyChanged?.Invoke(compositeVolume.SourceName, new PropertyChangedEventArgs(nameof(compositeVolume.SourceName)));
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void PopulateInstance()
        {
            ICompositeVolumeLevelViewModel audioSource1 = new CompositeVolumeLevelViewModel("Player 1", (level: 0, name: "Master"), (level: 0, name: "Left"), (level: 0, name: "Right"));
            ICompositeVolumeLevelViewModel audioSource2 = new CompositeVolumeLevelViewModel("Player 2", (level: 0, name: "Master"), (level: 0, name: "Left"), (level: 0, name: "Right"));
            AudioSources = new ObservableCollection<ICompositeVolumeLevelViewModel> { audioSource1, audioSource2 };
            // DeleteCommand = new RelayCommand(OnDelete, CanDelete);
        }
    }
}
