namespace VideoPlayer.Converter
{
    using VideoPlayer.Controls;
    using Xamarin.Forms;

    [TypeConverter(typeof(VideoSourceConverter))]
    public abstract class VideoSource : Element
    {
        public static VideoSource FromUri(string uri) => new UriVideoSource() { Uri = uri };
    }
}
