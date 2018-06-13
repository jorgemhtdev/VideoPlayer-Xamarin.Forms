using System.Collections.Generic;
using System.Collections.ObjectModel;
using VideoPlayer.View;
using Video = VideoPlayer.Models.Video;

namespace VideoPlayer.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        #region Attributes 
        public IList<Video> Videos { get; private set; }
        private Video selectedItemVideo;
        #endregion

        #region Properties
        public Video SelectedItemVideo
        {
            get => selectedItemVideo;
            set
            {
                SetProperty(ref selectedItemVideo, value);
                HandleSelection();
            }
        }
        #endregion

        public MainViewModel()
        {
            Videos = new ObservableCollection<Video>
            {
                new Video
                {
                    Title = "#",
                    Handle = "#",
                    ViewCount = 0,
                    HeroImage = "#",
                    ProfileImage = "#",
                    Url = "#"
                },
                new Video
                {
                    Title = "#",
                    Handle = "#",
                    ViewCount = 0,
                    HeroImage = "#",
                    ProfileImage = "#",
                    Url = "#"
                },
                new Video
                {
                    Title = "#",
                    Handle = "#",
                    ViewCount = 0,
                    HeroImage = "#",
                    ProfileImage = "#",
                    Url = "#"
                },
                new Video
                {
                    Title = "#",
                    Handle = "#",
                    ViewCount = 0,
                    HeroImage = "#",
                    ProfileImage = "#",
                    Url = "#"
                },
                new Video
                {
                    Title = "#",
                    Handle = "#",
                    ViewCount = 0,
                    HeroImage = "#",
                    ProfileImage = "#",
                    Url = "#"
                },
            };
        }

        private async void HandleSelection()
        {
            if (SelectedItemVideo?.Url == null) return;

            await App.Current.MainPage.Navigation.PushAsync(new VideoView(), true);
        }
    }
}