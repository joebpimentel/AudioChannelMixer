using System;
using System.Collections.Generic;

namespace AudioChannelMixer.Infrastrucure.Notification
{
    public class Observable<T> : IObservable<T>, IDisposable
    {
        private readonly List<IObserver<T>> observers;

        public Observable()
        {
            observers = new List<IObserver<T>>();
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber<T>(observers, observer);
        }

        public void Dispose()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }
}