namespace VideoPlayer.Interface
{
    using System;
    using VideoPlayer.Models;

    public interface IVideoPlayerController
    {
        VideoStatus Status { set; get; }

        TimeSpan Duration { set; get; }
    }
}
