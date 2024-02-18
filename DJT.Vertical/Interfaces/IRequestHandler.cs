using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Interfaces
{
    public interface IRequestHandler<TResult>
    {
        public TResult Execute();
    }

    public interface IRequestHandler<TOptions, TResult>
    {
        public TResult Execute(TOptions options);
    }

    public interface IRequestHandler<TKey, TOptions, TResult>
    {
        public TResult Execute(TKey key, TOptions options);
    }
}
