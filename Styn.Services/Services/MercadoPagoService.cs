using Styn.Domain.DTOs;
using Styn.Domain.Entities;
using Styn.Infrastructure.Data;
using MercadoPago.Client.Payment;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Payment;
using MercadoPago.Resource.Preference;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Styn.Domain.Dtos;

namespace Styn.Application.Services
{
    public interface IMercadoPagoService
    {
        Task<Preference> GetPreferenceAsync(PreferenceRequestDto request);
        Task<bool> VerifyPayment(string paymentid, string status, string external);
    }
    public class MercadoPagoService : IMercadoPagoService
    {
        private readonly StynContext _context;
        private readonly IConfiguration _config;
        private readonly IAuthService _auth;

        public MercadoPagoService(StynContext context, IConfiguration config, IAuthService auth)
        {
            _context = context;
            _config = config;
            _auth = auth;
        }

        public async Task<bool> VerifyPayment(string paymentid, string status, string external)
        {
            try
            {
                var accessToken = _config["MercadoPago:AccessToken"];
                MercadoPagoConfig.AccessToken = accessToken;

                var paymentClient = new PaymentClient();

                // Obtener el pago por su id
                Payment payment = await paymentClient.GetAsync(long.Parse(paymentid));


                var pago = await _context.Pagos.FirstOrDefaultAsync(p => p.UserId.ToString() == external && p.Estado == "pending");
                if (status == "approved")
                {
                    pago.Estado = status;
                    await _context.SaveChangesAsync();
                    await _auth.AssignPayToUser(pago.UserId.ToString(),pago);

                }
                return true;

            }
            catch (Exception)
            {

                return false;
            }
        }
        public async Task<Preference> GetPreferenceAsync(PreferenceRequestDto request)
        {


            var accessToken = _config["MercadoPago:AccessToken"];
            MercadoPagoConfig.AccessToken = accessToken;

            var monto = 100;
            PreferenceRequest requestPreference = new PreferenceRequest();
            requestPreference.ExternalReference = request.UserId.ToString();
            requestPreference.Items = new List<PreferenceItemRequest>();

            PreferenceItemRequest newItem = new PreferenceItemRequest
            {
                Title = "Cuota Mensual",
                Quantity = 1,
                CurrencyId = "ARS",
                UnitPrice = monto
            };
            requestPreference.Items.Add(newItem);
            requestPreference.BackUrls = new PreferenceBackUrlsRequest
            {
                

            };
            requestPreference.AutoReturn = "approved";
            var client = new PreferenceClient();
            Preference preference = await client.CreateAsync(requestPreference);
            var pagosExisting = _context.Pagos.Where(p => p.UserId == request.UserId && p.Estado == "pending").ToList();
            _context.RemoveRange(pagosExisting);
            var pago = new Pago
            {
                FechaPago = DateTime.Now,
                UserId = request.UserId,
                Monto = monto

            };
            _context.Pagos.Add(pago);
            _context.SaveChanges();


            return preference;
        }
    }
}
