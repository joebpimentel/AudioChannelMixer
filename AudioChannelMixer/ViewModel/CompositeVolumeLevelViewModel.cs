using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using AudioChannelMixer.Infrastrucure.Command;
using AudioChannelMixer.Models;
using Microsoft.Win32;
using Prism.Mvvm;

namespace AudioChannelMixer.ViewModel
{
    public sealed class CompositeVolumeLevelViewModel : BindableBase, ICompositeVolumeLevelViewModel
    {
        private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private IAudioVolumeLevelViewModel _leftChannel;
        private IAudioVolumeLevelViewModel _masterVolume;
        private IAudioVolumeLevelViewModel _rightChannel;
        private string _sourceName;
        private Audio _audio;

        public CompositeVolumeLevelViewModel()
        {
            if (isInDesignMode)
            {

                SourceName = "Media X";
                LeftChannel = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 30,
                    ChannelName = "Left"
                };

                RightChannel = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 70,
                    ChannelName = "Right"
                };

                MasterVolume = new AudioVolumeLevelViewModel
                {
                    VolumeLevel = 100,
                    ChannelName = "Master"
                };
            }
        }

        public CompositeVolumeLevelViewModel(string source, (int level, string name) masterChannel, (int level, string name) leftChannel, (int level, string name) rightChannel)
        {
            SourceName = source;
            MasterVolume = new AudioVolumeLevelViewModel(masterChannel);
            LeftChannel = new AudioVolumeLevelViewModel(leftChannel);
            RightChannel = new AudioVolumeLevelViewModel(rightChannel);
            ChooseFile = new AsyncCommand(ExecuteSubmitAsync, CanExecuteSubmit);
            // _aggregator.GetEvent<FileNameChangeEvent>().Subscribe(OnPropertyChanged())
        }

        public IAudioVolumeLevelViewModel LeftChannel
        {
            get => _leftChannel;
            set => SetProperty(ref _leftChannel, value);
        }

        public IAudioVolumeLevelViewModel RightChannel
        {
            get => _rightChannel;
            set => SetProperty(ref _rightChannel, value);
        }

        public IAudioVolumeLevelViewModel MasterVolume
        {
            get => _masterVolume;
            set => SetProperty(ref _masterVolume, value);
        }

        public string SourceName
        {
            get => _sourceName;
            set => SetProperty(ref _sourceName, value);
        }

        public Audio Audio
        {
            get => _audio;
            set => SetProperty(ref _audio, value);
        }

        public IAsyncCommand ChooseFile { get; private set; }

        private bool CanExecuteSubmit()
        {
            return true;
        }

        private async Task ExecuteSubmitAsync()
        {
            var openFileDialog = new OpenFileDialog
            {
                Title = "Select Audio File",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Audio Files|*.mp3;*.ogg;*.wav" +
                         "|All Files|*.*",
                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                SourceName = openFileDialog.FileName;
            }

            var x = openFileDialog.FileName;
            await Task.FromResult(x);
        }
    }
}