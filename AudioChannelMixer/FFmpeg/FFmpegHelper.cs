using System;
using System.Runtime.InteropServices;
using FFmpeg.AutoGen;

namespace AudioChannelMixer.FFmpeg
{
    internal static class FFmpegHelper
    {
        private const int bufferSize = 1024;

        public static unsafe string AvStrError(int error)
        {
            var buffer = stackalloc byte[bufferSize];
            ffmpeg.av_strerror(error, buffer, (ulong)bufferSize);
            var message = Marshal.PtrToStringAnsi((IntPtr)buffer);
            return message;
        }

        public static int ThrowExceptionIfError(this int error)
        {
            if (error < 0)
            {
                throw new ApplicationException(AvStrError(error));
            }

            return error;
        }
    }
}