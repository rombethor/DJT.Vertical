namespace DJT.Vertical.Interfaces
{
    /// <summary>
    /// Async implementation of <see cref="IRequestHandler{TResult}"/>
    /// </summary>
    /// <typeparam name="TRes">Return type</typeparam>
    /// <param name="cancellationToken"></param>
    public abstract class AsyncRequestHandler<TRes>(CancellationToken cancellationToken)
        : IRequestHandler<Task<TRes>>
    {

        /// <summary>
        /// Execute the request
        /// </summary>
        /// <returns></returns>
        public abstract Task<TRes> Execute();
    }

    /// <summary>
    /// Async implementation of <see cref="IRequestHandler{TOptions, TResult}"/>
    /// </summary>
    /// <typeparam name="TOptions">Options object</typeparam>
    /// <typeparam name="TRes">Result type</typeparam>
    /// <param name="cancellationToken"></param>
    public abstract class AsyncRequestHandler<TOptions, TRes>(CancellationToken cancellationToken)
        : IRequestHandler<TOptions, Task<TRes>>
    {
        /// <summary>
        /// Execute the request
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public abstract Task<TRes> Execute(TOptions options);
    }

    /// <summary>
    /// Async Implementation of <see cref="IRequestHandler{TKey, TOptions, TResult}"/>
    /// </summary>
    /// <typeparam name="TKey">Key value for record</typeparam>
    /// <typeparam name="TOptions">Options object</typeparam>
    /// <typeparam name="TRes">Result type</typeparam>
    /// <param name="cancellationToken">Cancellation token</param>
    public abstract class AsyncRequestHandler<TKey, TOptions, TRes>(CancellationToken cancellationToken)
        : IRequestHandler<TKey, TOptions, Task<TRes>>
    {
        /// <summary>
        /// Execute the request
        /// </summary>
        /// <param name="key"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public abstract Task<TRes> Execute(TKey key, TOptions options);
    }


}
