using FabulousStore.POC.Core.Abstractions.Utils;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FabulousStore.POC.Core.Utils
{
    internal class Dispatcher(IMediator mediator, ILogger<Dispatcher> logger) : IDispatcher
    {
        private readonly IMediator _mediator = mediator;
        private readonly ILogger _logger = logger;

        public async Task<TResult> SendAsync<T, TResult>(T @event)
            where T : IRequest<TResult>
        {
            _logger.LogDebug($"Event Triggered {typeof(T).FullName}");

            return await _mediator.Send(@event);
        }

        public Task PublishAsync<T>(T @event)
            where T : INotification
        {
            _logger.LogDebug($"Event Published {typeof(T).FullName}");

            return _mediator.Publish(@event);
        }
    }
}
