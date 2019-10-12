namespace Core.Common
{
    public class Result : IResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public interface IResult
    {
    }
}
