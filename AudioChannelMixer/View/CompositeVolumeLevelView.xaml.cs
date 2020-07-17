using System;
using AudioChannelMixer.Events;
using AudioChannelMixer.Infrastrucure;
using AudioChannelMixer.Infrastrucure.MVVM;
using AudioChannelMixer.ViewModel;
using Microsoft.Practices.Unity;
using Microsoft.Win32;
using Prism.Common;
using Prism.Events;

namespace AudioChannelMixer.View
{
    /// <summary>
    /// Interaction logic for SliderComposite.xaml
    /// </summary>
    public partial class CompositeVolumeLevelView : ICompositeVolumeLevelView
    {
        private readonly IEventAggregator _aggregator = SingletonEventAggregator.Instance;
        public ObservableObject<(string filename, IViewModel model)> fileChoosedObservable;
        public CompositeVolumeLevelView()
        {
            InitializeComponent();
        }

        [InjectionConstructor]
        public CompositeVolumeLevelView(ICompositeVolumeLevelViewModel viewModel)
        {
            InitializeComponent();
            ViewModel = viewModel;
            fileChoosedObservable = new ObservableObject<(string filename, IViewModel model)>();
        }

        public IViewModel ViewModel
        {
            get => (ICompositeVolumeLevelViewModel)DataContext;
            set => DataContext = value;
        }
    }
}
