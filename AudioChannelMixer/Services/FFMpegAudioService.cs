using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using AudioChannelMixer.FFmpeg;
using AudioChannelMixer.Infrastrucure.Audio;

namespace AudioChannelMixer.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class FFMpegAudioService : IAudioService
    {
        public FFMpegAudioService()
        {
            MediaDictionary = new ConcurrentDictionary<Guid, string>();
        }

        public IDictionary<Guid, string> MediaDictionary { get; }

        public Guid AddStreamFromFile(string fileName)
        {
            using (var asd = new AudioStreamDecoder(fileName))
            {
                Console.WriteLine($@"codec name: {asd.CodecName}");

                var info = asd.GetContextInfo();
                info.ToList().ForEach(x => Console.WriteLine($@"{x.Key} = {x.Value}"));

                // var sourceSize = asd.FrameSize;
                // var sourcePixelFormat = asd.PixelFormat;
                // var destinationSize = sourceSize;
                // var destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;
                // using (var afc = new AudioFrameConverter(sourceSize, sourcePixelFormat, destinationSize, destinationPixelFormat))
                // {
                //    var frameNumber = 0;
                //    while (asd.TryDecodeNextFrame(out var frame))
                //    {
                //        var convertedFrame = afc.Convert(frame);
                //
                //        using (var bitmap = new Bitmap(convertedFrame.width, convertedFrame.height, convertedFrame.linesize[0], PixelFormat.Format24bppRgb, (IntPtr)convertedFrame.data[0]))
                //            bitmap.Save($"frame.{frameNumber:D8}.jpg", ImageFormat.Jpeg);
                //        DateTime dt = DateTime.FromBinary(convertedFrame.pkt_dts);
                //        Console.WriteLine($@"frame: {frameNumber}, timestamp: {convertedFrame.pkt_dts}, date time: {dt.ToLocalTime()}");
                //        frameNumber++;
                //    }
                // }
            }

            return Guid.Empty;
        }

        public void PlaySound(CachedAudio audio)
        {
            throw new NotImplementedException();
        }

        public void AddMixerInput(IAudioSampleProvider audioProvider)
        {
            throw new NotImplementedException();
        }
    }
}
