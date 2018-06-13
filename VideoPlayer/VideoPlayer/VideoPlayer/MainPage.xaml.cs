namespace VideoPlayer
{
    using ViewModel;
    using Xamarin.Forms;

    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		    BindingContext = new VideoViewModel();
        }
    }
}
