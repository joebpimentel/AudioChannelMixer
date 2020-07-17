using System;

namespace AudioChannelMixer.Infrastrucure.Error
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}