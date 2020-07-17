using System;
using System.Collections.Generic;

namespace AudioChannelMixer.Services
{
    public interface IAudioService
    {
        IDictionary<string, string> MediaDictionary { get; }

        string AddStreamFromFile(string fileName);
    }
}