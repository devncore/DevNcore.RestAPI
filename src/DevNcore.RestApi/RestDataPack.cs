namespace DevNcore.RestApi
{
    public class RestDataPack
    {
        public bool IsError { get; internal set; }
        public Exception Exception { get; internal set; }
        public bool IsContent { get; internal set; }
        public string Data { get; internal set; }
    }
}
