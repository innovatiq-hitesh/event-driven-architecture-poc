using FabulousStore.POC.Core.Events;
using FluentValidation;

namespace FabulousStore.POC.Core.EventValidators
{
    internal class TransactionFailedEventValidator : AbstractValidator<TransactionFailedEvent>
    {
        public TransactionFailedEventValidator()
        {
            // Add Validations
        }
    }
}
