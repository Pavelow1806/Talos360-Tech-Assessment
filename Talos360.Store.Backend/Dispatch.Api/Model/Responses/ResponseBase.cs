namespace Dispatch.Api.Model.Responses
{
    public abstract class ResponseBase
    {
        public bool Success { get; set; } = true;
        public string Message { get; set; }
    }
}
