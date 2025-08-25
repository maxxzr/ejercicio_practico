namespace Bank.Application.Models
{
    public class ResponseResult
    {
        public int DataId { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Success { get; set; } = true;
    }
}
