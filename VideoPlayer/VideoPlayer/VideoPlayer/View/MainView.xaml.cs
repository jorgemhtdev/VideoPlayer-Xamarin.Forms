using VideoPlayer.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VideoPlayer.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainView : ContentPage
	{
		public MainView ()
		{
			InitializeComponent ();
            BindingContext = new MainViewModel();
		}
	}
}