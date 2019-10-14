using System.Collections;
using System.Collections.Generic;
using Core.Common;
using System.Threading.Tasks;

namespace Core.Queries
{
    public abstract class ListMessageHandler<T, TOut>
        where T : class, IRequest<TOut>
        where TOut : class, IResult, new()
    {
        public abstract Task<IList<TOut>> Handler(T message);
    }
}
