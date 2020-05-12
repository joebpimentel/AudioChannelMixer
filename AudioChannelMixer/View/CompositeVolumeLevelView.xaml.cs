using AudioChannelMixer.Infrastrucure;
using AudioChannelMixer.ViewModel;
using Microsoft.Practices.Unity;

namespace AudioChannelMixer.View
{
    /// <summary>
    /// Interaction logic for SliderComposite.xaml
    /// </summary>
    public partial class CompositeVolumeLevelView : ICompositeVolumeLevelView
    {
        public CompositeVolumeLevelView()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public CompositeVolumeLevelView(ICompositeVolumeLevelViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get => (ICompositeVolumeLevelViewModel)DataContext;
            set => DataContext = value;
        }

        private void AudioVolumeLevelView_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
