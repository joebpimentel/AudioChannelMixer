using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using AudioChannelMixer.Events;
using AudioChannelMixer.Services;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Prism.Events;
using Prism.Mvvm;

namespace AudioChannelMixer.Models
{
    public class Audio : BindableBase, IDisposable
    {
        private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private readonly IEventAggregator _aggregator = SingletonEventAggregator.Instance;
        private readonly IAudioService audioService;
        private string _fileName;
        private TimeSpan _duration;

        public Audio(IAudioService audioService)
        {
            if (!isInDesignMode)
            {
                _aggregator.GetEvent<FileNameChangeEvent>().Unsubscribe(SelectedFileTextChangedAction);
                _aggregator.GetEvent<FileNameChangeEvent>().Subscribe(SelectedFileTextChangedAction);

                this.audioService = audioService;
            }
        }

        public string FileName
        {
            private get => _fileName;
            set
            {
                if (!string.IsNullOrEmpty(value) && !File.Exists(value) && !isInDesignMode)
                {
                    MessageBox.Show(
                        $"File {value} does not exists. Ignored!",
                        "File Selection",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    StreamId = Guid.Empty;
                }
                else
                {
                    StreamId = audioService.AddStreamFromFile(FileName);
                    if (StreamId == Guid.Empty)
                    {
                        MessageBox.Show(
                            $"Audio service could not add stream {FileName}",
                            "File Selection",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
                    }
                    else
                    {
                        SetProperty(ref _fileName, value);
                    }
                }
            }
        }

        private Guid StreamId { get; set; }

        private void LoadAudioFile(string fileName)
        {
            throw new NotImplementedException();
        }

        public TimeSpan Duration
        {
            get => _duration;
            set => SetProperty(ref _duration, value);
        }
        public void Dispose()
        {
            _aggregator.GetEvent<FileNameChangeEvent>().Unsubscribe(SelectedFileTextChangedAction);
        }

        private void SelectedFileTextChangedAction(string s) { FileName = s; }
    }
}