namespace SwqlStudio.Playback
{
    public class PlaybackItem
    {
        public string FileName { get; set; }
        public bool MultiThread { get; set; }
        public ConnectionInfo ConnectionInfo { get; set; }
        public QueryTab QueryTab { get; set; }
    }
}
