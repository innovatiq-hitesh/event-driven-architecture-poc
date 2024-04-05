using FabulousStore.POC.Core.Events;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FabulousStore.POC.Core.EventValidators
{
    internal class TransactionProcessEventValidator : AbstractValidator<TransactionProcessEvent>
    {
        public TransactionProcessEventValidator()
        {
            // Add Validations
        }
    }
}
