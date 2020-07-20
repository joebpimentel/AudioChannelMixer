using System;
using NAudio.Wave;

namespace AudioChannelMixer.Infrastrucure.Audio
{
    public class CachedAudioSampleProvider : IAudioSampleProvider
    {
        private readonly CachedAudio _audio;
        private long position;

        public CachedAudioSampleProvider(CachedAudio audio)
        {
            _audio = audio;
        }

        public int Read(float[] buffer, int offset, int count)
        {
            var availableSamples = _audio.AudioData.Length - position;
            var samplesToCopy = Math.Min(availableSamples, count);
            Array.Copy(_audio.AudioData, position, buffer, offset, samplesToCopy);
            position += samplesToCopy;
            return (int)samplesToCopy;
        }

        public WaveFormat WaveFormat => _audio.WaveFormat;
    }
}