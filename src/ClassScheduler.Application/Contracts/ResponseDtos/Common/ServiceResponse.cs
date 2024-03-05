

namespace ClassScheduler.Application.Contracts.ResponseDtos.Common;
public class ServiceResponse<T>
{
    public T? Data { get; set; }
    public bool Success { get; set; } = false;
    public string Message { get; set; } = string.Empty;
    public List<string> Errors { get; set; } = [];

}