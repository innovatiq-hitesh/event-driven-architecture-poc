using MediatR;

namespace FabulousStore.POC.Core.Abstractions.Utils
{
    public interface IDispatcher
    {
        Task<TResult> SendAsync<T, TResult>(T @event)
            where T : IRequest<TResult>;

        Task PublishAsync<T>(T @event)
            where T : INotification;
    }
}
