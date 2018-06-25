namespace VideoPlayer.Converter
{
    using System;
    using VideoPlayer.Controls;
    using Xamarin.Forms;

    public class VideoSourceConverter : TypeConverter
    {
        public override object ConvertFromInvariantString(string value)
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                return Uri.TryCreate(value, UriKind.Absolute, out var uri) && uri.Scheme != "file" ?  VideoSource.FromUri(value) : VideoSource.FromUri(value);
            }

            throw new InvalidOperationException("Cannot convert null or whitespace to ImageSource");
        }
    }
}
