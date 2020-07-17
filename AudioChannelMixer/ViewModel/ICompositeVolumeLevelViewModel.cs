using AudioChannelMixer.Infrastrucure;
using AudioChannelMixer.Infrastrucure.MVVM;

namespace AudioChannelMixer.ViewModel
{
    public interface ICompositeVolumeLevelViewModel : IVolumeLevelModel
    {
        string SourceName { get; set; }
    }
}