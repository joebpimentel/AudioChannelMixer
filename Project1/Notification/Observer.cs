using System;

namespace AudioChannelMixer.Infrastrucure.Notification
{
    public class AsyncObserver<T> : IObserver<T>
    {
        public void OnNext(T value)
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }
    }
}