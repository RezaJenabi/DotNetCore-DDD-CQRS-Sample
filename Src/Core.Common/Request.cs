namespace Core.Common
{
    public class Request<T> : IRequest<T> where T : Result
    {
    }

    public interface IRequest<T> where T : IResult
    {
    }
}
