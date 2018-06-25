using VideoPlayer.iOS.Renderer;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(VideoPlayer.Controls.VideoPlayer), typeof(VideoPlayerRenderer))]
namespace VideoPlayer.iOS.Renderer
{
    using AVFoundation;
    using AVKit;
    using Controls;
    using CoreMedia;
    using Foundation;
    using System;
    using System.ComponentModel;
    using UIKit;
    using Interface;
    using Models;
    using Xamarin.Forms;
    using Xamarin.Forms.Platform.iOS;

    public class VideoPlayerRenderer : ViewRenderer<VideoPlayer, UIView>
    {
        AVPlayer player;
        AVPlayerItem playerItem;
        AVPlayerViewController _playerViewController;      

        public override UIViewController ViewController => _playerViewController;

        protected override void OnElementChanged(ElementChangedEventArgs<VideoPlayer> args)
        {
            base.OnElementChanged(args);

            if (args.NewElement != null)
            {
                if (Control == null)
                {
                    // Create AVPlayerViewController
                    _playerViewController = new AVPlayerViewController();

                    // Set Player property to AVPlayer
                    player = new AVPlayer();
                    _playerViewController.Player = player;

                    var x = _playerViewController.View;

                    // Use the View from the controller as the native control
                    SetNativeControl(_playerViewController.View);
                }

                SetAreTransportControlsEnabled();
                SetSource();

                args.NewElement.UpdateStatus += OnUpdateStatus;
                args.NewElement.PlayRequested += OnPlayRequested;
                args.NewElement.PauseRequested += OnPauseRequested;
                args.NewElement.StopRequested += OnStopRequested;
            }

            if (args.OldElement != null)
            {
                args.OldElement.UpdateStatus -= OnUpdateStatus;
                args.OldElement.PlayRequested -= OnPlayRequested;
                args.OldElement.PauseRequested -= OnPauseRequested;
                args.OldElement.StopRequested -= OnStopRequested;
                
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            player?.ReplaceCurrentItemWithPlayerItem(null);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(sender, args);

            if (args.PropertyName == VideoPlayer.AreTransportControlsEnabledProperty.PropertyName)
            {
                SetAreTransportControlsEnabled();
            }
            else if (args.PropertyName == VideoPlayer.SourceProperty.PropertyName)
            {
                SetSource();
            }
            else if (args.PropertyName == VideoPlayer.PositionProperty.PropertyName)
            {
                var controlPosition = ConvertTime(player.CurrentTime);

                if (Math.Abs((controlPosition - Element.Position).TotalSeconds) > 1)
                {
                    player.Seek(CMTime.FromSeconds(Element.Position.TotalSeconds, 1));
                }
            }
        }

        void SetAreTransportControlsEnabled()
        {
            ((AVPlayerViewController)ViewController).ShowsPlaybackControls = Element.AreTransportControlsEnabled;
        }

        void SetSource()
        {
            AVAsset asset = null;

            var uri = (Element.Source as UriVideoSource)?.Uri;

            if (!string.IsNullOrWhiteSpace(uri))
            {
                asset = AVAsset.FromUrl(new NSUrl(uri));
            }

            playerItem = asset != null ? new AVPlayerItem(asset) : null;

            player.ReplaceCurrentItemWithPlayerItem(playerItem);

            if (playerItem != null && Element.AutoPlay)
            {
                player.Play();
            }
        }

        void OnUpdateStatus(object sender, EventArgs args)
        {
            var videoStatus = VideoStatus.NotReady;

            switch (player.Status)
            {
                case AVPlayerStatus.ReadyToPlay:
                    switch (player.TimeControlStatus)
                    {
                        case AVPlayerTimeControlStatus.Playing:
                            videoStatus = VideoStatus.Playing;
                            break;

                        case AVPlayerTimeControlStatus.Paused:
                            videoStatus = VideoStatus.Paused;
                            break;
                    }
                    break;
            }
            ((IVideoPlayerController)Element).Status = videoStatus;

            if (playerItem == null) return;

            ((IVideoPlayerController)Element).Duration = ConvertTime(playerItem.Duration);
            ((IElementController)Element).SetValueFromRenderer(VideoPlayer.PositionProperty, ConvertTime(playerItem.CurrentTime));
        }

        TimeSpan ConvertTime(CMTime cmTime) => TimeSpan.FromSeconds(Double.IsNaN(cmTime.Seconds) ? 0 : cmTime.Seconds);

        void OnPlayRequested(object sender, EventArgs args) => player.Play();

        void OnPauseRequested(object sender, EventArgs args) => player.Pause();

        void OnStopRequested(object sender, EventArgs args)
        {
            player.Pause();
            player.Seek(new CMTime(0, 1));
        }
    }
}