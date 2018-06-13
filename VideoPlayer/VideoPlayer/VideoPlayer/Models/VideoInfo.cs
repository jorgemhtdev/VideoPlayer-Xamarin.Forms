namespace Models
{
    using VideoPlayer.Converter;

    public class VideoInfo
    {
        public string DisplayName { set; get; }

        public VideoSource VideoSource { set; get; }

        public override string ToString() => DisplayName;
    }
}
