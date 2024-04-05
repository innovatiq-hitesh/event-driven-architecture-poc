using FabulousStore.POC.Core.Events;
using FluentValidation;

namespace FabulousStore.POC.Core.EventValidators
{
    internal class TransactionViolationEventValidator : AbstractValidator<TransactionViolationEvent>
    {
        public TransactionViolationEventValidator()
        {
            //Add Validation
        }
    }
}
