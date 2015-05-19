namespace SwqlStudio
{
    public interface IConnectionTab
    {
        IApplicationService ApplicationService { get; set; }
        ConnectionInfo ConnectionInfo { get; set; }
    }
}