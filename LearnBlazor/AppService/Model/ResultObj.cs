namespace LearnBlazor.AppService.Model
{
    public class ResultObj<T>
    {
        public T? ResultObject { get; set; }
        public string? Message { get; set; }
        public MessageType MessageType { get; set; }
    }
    public enum MessageType
    {
        Success = 0,
        Error = 1,
        Warning = 2,
    }
}
