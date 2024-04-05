using FabulousStore.POC.Core.Events;
using FluentValidation;

namespace FabulousStore.POC.Core.EventValidators
{
    internal class TransactionHoldEventValidator : AbstractValidator<TransactionHoldEvent>
    {
        public TransactionHoldEventValidator()
        {
            // Add Validations
        }
    }
}
