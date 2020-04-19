using AudioChannelMixer.Infrastrucure;
using AudioChannelMixer.ViewModel;
using Microsoft.Practices.Unity;

namespace AudioChannelMixer.View
{
    /// <summary>
    /// Interaction logic for AudioChannelMixerView.xaml
    /// </summary>
    public partial class AudioChannelMixerView : IAudioChannelMixerView
    {
        //public AudioChannelMixerView()
        //{
        //    InitializeComponent();
        //}
        [InjectionConstructor]
        public AudioChannelMixerView(IAudioChannelMixerViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }


        public IViewModel ViewModel
        {
            get => (IAudioChannelMixerViewModel) DataContext;
            set => DataContext = value;
        }
    }
}
