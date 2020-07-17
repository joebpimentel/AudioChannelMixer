using Prism.Events;

namespace AudioChannelMixer.Events
{
    public class SingletonEventAggregator: EventAggregator
    {
        private static SingletonEventAggregator instance;
        private static readonly object padlock = new object();

        private SingletonEventAggregator()
        {
        }

        public static SingletonEventAggregator Instance
        {
            get
            {
                lock (padlock)
                {
                    return instance ?? (instance = new SingletonEventAggregator());
                }
            }
        }
    }
}