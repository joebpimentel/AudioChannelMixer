using System.Collections.Generic;

namespace AudioChannelMixer.Services
{
    public interface IAudioService
    {
        IDictionary<string, string> PlayersDictionary { get; }
    }
}