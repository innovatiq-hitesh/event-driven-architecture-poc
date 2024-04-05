using FabulousStore.POC.Core.Abstractions.Services;
using FabulousStore.POC.Core.DomainTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FabulousStore.POC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionRequestDTO transactionRequestDTO)
        {
            await _paymentService.ExecuteTransactionAsync(transactionRequestDTO);
            return Ok();
        }
    }
}
