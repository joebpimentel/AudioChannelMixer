using System;
using System.ComponentModel;
using System.Windows;
using AudioChannelMixer.Models;
using AudioChannelMixer.Services;
using Prism.Mvvm;

namespace AudioChannelMixer.ViewModel
{
    public class InputPanelViewModel : BindableBase
    {
        private static readonly bool isInDesignMode = DesignerProperties.GetIsInDesignMode(new DependencyObject());
        private Audio _audio;

        public InputPanelViewModel()
        {
        }

        public InputPanelViewModel(IAudioService audioService)
        {
            _audio = new Audio(audioService)
            {
                FileName = isInDesignMode ? @"C:\FilePath\filename.mp3" : string.Empty,
                Duration =  new TimeSpan(0,5,0)
            };
        }

        public Audio Audio
        {
            get => _audio;
            set => SetProperty(ref _audio, value);
        }
    }
}