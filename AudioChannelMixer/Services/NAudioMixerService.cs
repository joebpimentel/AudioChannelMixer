using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using AudioChannelMixer.Infrastrucure.Audio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioChannelMixer.Services
{
    public class NAudioMixerService : IAudioService
    {
        private ConcurrentDictionary<Guid, CachedAudio> CachedAudioDictionary;
        private ConcurrentDictionary<Guid, MixingSampleProvider> MixingSampleProviders;
        private readonly WaveOutEvent outputDevice;
        private readonly MixingSampleProvider mixer;
        private const int sampleRate = 44100;
        private const int channelCount = 2;

        public NAudioMixerService()
        {
            // var output = new NAudio.Mixer
            MediaDictionary = new ConcurrentDictionary<Guid, string>();
            CachedAudioDictionary = new ConcurrentDictionary<Guid, CachedAudio>();
            MixingSampleProviders = new ConcurrentDictionary<Guid, MixingSampleProvider>();
            outputDevice = new WaveOutEvent();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channelCount))
            {
                ReadFully = true
            };
            outputDevice.Init(mixer);
            outputDevice.Play();
        }

        public IDictionary<Guid, string> MediaDictionary { get; }

        public Guid AddStreamFromFile(string fileName)
        {
            var sampleId = Guid.NewGuid();
            var cachedAudio = new CachedAudio(fileName);
            var success = MixingSampleProviders.TryAdd(sampleId, new MixingSampleProvider(cachedAudio.WaveFormat));

            return success ? sampleId : Guid.Empty;
        }
        public void PlaySound(CachedAudio audio)
        {
            AddMixerInput(new CachedAudioSampleProvider(audio));
        }

        public void AddMixerInput(IAudioSampleProvider audioProvider)
        {
            mixer.AddMixerInput(ConvertToRightChannelCount(audioProvider));
        }

        private ISampleProvider ConvertToRightChannelCount(IAudioSampleProvider audioProvider)
        {
            if (audioProvider.WaveFormat.Channels == mixer.WaveFormat.Channels)
            {
                return audioProvider;
            }
            if (audioProvider.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels == 2)
            {
                return new MonoToStereoSampleProvider(audioProvider);
            }
            throw new NotImplementedException("Not yet implemented this channel count conversion");
        }
    }
}