using System;
using System.Collections.Generic;
using AudioChannelMixer.Infrastrucure.Audio;

namespace AudioChannelMixer.Services
{
    public interface IAudioService
    {
        /// <summary>
        /// MediaDictionary, key = media name reference, value = media file name;
        /// </summary>
        IDictionary<Guid, string> MediaDictionary { get; }

        Guid AddStreamFromFile(string fileName);

        void PlaySound(CachedAudio audio);

        void AddMixerInput(IAudioSampleProvider audioProvider);
    }
}