namespace VideoPlayer.Controls
{
    using Converter;
    using Xamarin.Forms;

    public class UriVideoSource : VideoSource
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(nameof(Uri), typeof(string), typeof(UriVideoSource));

        public string Uri
        {
            set => SetValue(UriProperty, value);
            get => (string)GetValue(UriProperty);
        }
    }
}
