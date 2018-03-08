namespace SwqlStudio
{
    public interface IConnectionTab
    {
        ConnectionInfo ConnectionInfo { get; set; }

        bool AllowsChangeConnection { get; }
    }
}