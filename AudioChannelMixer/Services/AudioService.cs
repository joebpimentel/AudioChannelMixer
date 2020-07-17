using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using AudioChannelMixer.FFmpeg;
using FFmpeg.AutoGen;
using FFmpeg.AutoGen.Example;
using PixelFormat = System.Windows.Media.PixelFormat;

namespace AudioChannelMixer.Services
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AudioService : IAudioService
    {
        public AudioService()
        {
            MediaDictionary = new ConcurrentDictionary<string, string>();
        }

        /// <summary>
        /// MediaDictionary, key = media name reference, value = media file name;
        /// </summary>
        public IDictionary<string, string> MediaDictionary { get; }

        public string AddStreamFromFile(string fileName)
        {
            using (var asd = new AudioStreamDecoder(fileName))
            {
                Console.WriteLine($@"codec name: {asd.CodecName}");

                var info = asd.GetContextInfo();
                info.ToList().ForEach(x => Console.WriteLine($@"{x.Key} = {x.Value}"));

                var sourceSize = asd.FrameSize;
                var sourcePixelFormat = asd.PixelFormat;
                var destinationSize = sourceSize;
                //var destinationPixelFormat = AVPixelFormat.AV_PIX_FMT_BGR24;
                //using (var afc = new AudioFrameConverter(sourceSize, sourcePixelFormat, destinationSize, destinationPixelFormat))
                //{
                //    var frameNumber = 0;
                //    while (asd.TryDecodeNextFrame(out var frame))
                //    {
                //        var convertedFrame = afc.Convert(frame);

                //        using (var bitmap = new Bitmap(convertedFrame.width, convertedFrame.height, convertedFrame.linesize[0], PixelFormat.Format24bppRgb, (IntPtr)convertedFrame.data[0]))
                //            bitmap.Save($"frame.{frameNumber:D8}.jpg", ImageFormat.Jpeg);
                //        DateTime dt = DateTime.FromBinary(convertedFrame.pkt_dts);
                //        Console.WriteLine($@"frame: {frameNumber}, timestamp: {convertedFrame.pkt_dts}, date time: {dt.ToLocalTime()}");
                //        frameNumber++;
                //    }
                //}
            }

            return string.Empty;
        }
    }
}
