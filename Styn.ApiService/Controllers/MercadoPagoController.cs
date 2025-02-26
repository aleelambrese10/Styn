using MercadoPago.Client;
using MercadoPago.Client.Payment;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using Microsoft.AspNetCore.Mvc;


namespace STYN.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MercadoPagoController : ControllerBase
    {
        public MercadoPagoController()
        {
        }


        [HttpPost("/process_payment")]
        public async Task<IActionResult> Create(PaymentRequest request)
        {
           
            MercadoPagoConfig.AccessToken = "";

            var requestOptions = new RequestOptions();
            requestOptions.CustomHeaders.Add("Authorization", "Bearer " + MercadoPagoConfig.AccessToken);
            requestOptions.CustomHeaders.Add("Content-Type", "application/json");
            requestOptions.CustomHeaders.Add("x-idempotency-key", request.token);


            var paymentRequest = new PaymentCreateRequest
            {
                TransactionAmount = request.transaction_amount,
                Token = request.token,
                Installments = request.installments,
                PaymentMethodId = request.payment_method_id,
                Payer = new PaymentPayerRequest
                {
                    Email = request.payer.email
                },
                Description = "Compra en Styn"
            };

            var client = new PaymentClient();
            Payment payment = await client.CreateAsync(paymentRequest, requestOptions);

            return Ok(payment);
        }

        public class PaymentRequest
        {
            public string payment_method_id { get; set; }
            public decimal transaction_amount { get; set; }
            public PayerRequest payer { get; set; }
            public string token { get; set; }
            public int installments { get; set; }
        }

        public class PayerRequest
        {
            public string email { get; set; }
        }


    }
}

