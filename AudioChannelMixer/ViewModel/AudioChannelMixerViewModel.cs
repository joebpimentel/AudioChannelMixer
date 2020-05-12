using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Prism.Mvvm;

namespace AudioChannelMixer.ViewModel
{
    public class AudioChannelMixerViewModel : BindableBase, IAudioChannelMixerViewModel
    {
        // private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private ObservableCollection<ICompositeVolumeLevelViewModel> _audioSources;

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
            set => SetProperty(ref _audioSources, value);
        }

        private void PopulateInstance()
        {
            ICompositeVolumeLevelViewModel audioSource1 = new CompositeVolumeLevelViewModel("Player 1", (level: 0, name: "Master"), (level: 50, name: "Left"), (level: 100, name: "Right"));
            ICompositeVolumeLevelViewModel audioSource2 = new CompositeVolumeLevelViewModel("Player 2", (level: 33, name: "Master"), (level: 66, name: "Left"), (level: 99, name: "Right"));
            AudioSources = new ObservableCollection<ICompositeVolumeLevelViewModel> { audioSource1, audioSource2 };
        }
    }
}
