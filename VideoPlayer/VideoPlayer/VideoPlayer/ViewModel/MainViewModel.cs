namespace VideoPlayer.ViewModel
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using View;
    using Xamarin.Forms;
    using Video = Models.Video;

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
                    Author = "Spider-Man",
                    ViewCount = 120,
                    ImageVideo = "Image_1.jpeg",
                    ProfileImage = "Person_1.jpeg",
                    Url = "#"
                },
                new Video
                {
                    Author = "Black Widow",
                    ViewCount = 140,
                    ImageVideo =  "Image_2.jpeg",
                    ProfileImage = "Person_2.jpeg",
                    Url = "#"
                },
                new Video
                {
                    Author = "Aquaman",
                    ViewCount = 199,
                    ImageVideo =  "Image_3.jpeg",
                    ProfileImage = "Person_3.jpeg",
                    Url = "#"
                },
                new Video
                {
                    Author = "Thor",
                    ViewCount = 223,
                    ImageVideo = "Image_4.jpeg",
                    ProfileImage = "Person_4.jpeg",
                    Url = "#"
                },
                new Video
                {
                    Author = "Hulk",
                    ViewCount = 232,
                    ImageVideo =  "Image_5.jpeg",
                    ProfileImage = "Person_5.jpeg",
                    Url = "#"
                },
            };
        }

        private async void HandleSelection()
        {
            if (SelectedItemVideo?.Url == null) return;

            await Application.Current.MainPage.Navigation.PushAsync(new VideoView(), true);
        }
    }
}