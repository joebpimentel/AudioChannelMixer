using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AudioChannelMixer.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AudioService : IAudioService
    {

        public AudioService()
        {
            PlayersDictionary = new ConcurrentDictionary<string, string>();
        }

        public IDictionary<string, string> PlayersDictionary { get; }
    }
}