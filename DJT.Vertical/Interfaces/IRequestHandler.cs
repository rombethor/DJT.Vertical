using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJT.Vertical.Interfaces
{
    /// <summary>
    /// A request handler which takes no arguments but provides a response.
    /// </summary>
    /// <typeparam name="TResult">The response type</typeparam>
    public interface IRequestHandler<TResult>
    {
        /// <summary>
        /// Handle the request
        /// </summary>
        /// <returns></returns>
        public TResult Execute();
    }

    /// <summary>
    /// A request handler which takes an 'options' object and provides a response.
    /// </summary>
    /// <typeparam name="TOptions">Options to operate on</typeparam>
    /// <typeparam name="TResult">Type of the response</typeparam>
    public interface IRequestHandler<TOptions, TResult>
    {
        /// <summary>
        /// Handle the request
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public TResult Execute(TOptions options);
    }

    /// <summary>
    /// A request handler which takes a key, an options object and provides a response.
    /// </summary>
    /// <typeparam name="TKey">Key or index</typeparam>
    /// <typeparam name="TOptions">Options</typeparam>
    /// <typeparam name="TResult">A result type</typeparam>
    public interface IRequestHandler<TKey, TOptions, TResult>
    {
        /// <summary>
        /// Handle the request
        /// </summary>
        /// <param name="key"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public TResult Execute(TKey key, TOptions options);
    }
}
