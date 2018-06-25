using System;
using VideoPlayer.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoPlayer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoView : ContentPage
	{
		public VideoView ()
		{
			InitializeComponent ();
		}

        void OnPlayPauseButtonClicked(object sender, EventArgs args)
        {

        }

        void OnStopButtonClicked(object sender, EventArgs args)
        {
        }
    }
}