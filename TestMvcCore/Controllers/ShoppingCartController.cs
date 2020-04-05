using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using TestMvcCore.Models;
using TestMvcCore.Repository;

namespace TestMvcCore.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IOptions<PaymentExpressSettings> _optionsAccessor;
        private readonly PaymentExpressSettings _appSettings;

        public ShoppingCartController(IOptions<PaymentExpressSettings> optionsAccessor)
        {
            _optionsAccessor = optionsAccessor;
            _appSettings = optionsAccessor.Value;
        }

        public IActionResult Index()
        {
            var orderDb = new OrderDb();
            var order = orderDb.GetNewOrder();

            return View(order);
        }

        // GET: /ShoppingCart/Pay
        public ActionResult Pay(int id)
        {
            string currectScheme = Request.IsHttps ? Uri.UriSchemeHttps : Uri.UriSchemeHttp;

            var orderDb = new OrderDb();
            var order = orderDb.GetNewOrder();

            var paymentUrl = new PaymentUrl()
            {
                Success = Url.Action("PaymentSuccess", "ShoppingCart", null, currectScheme),
                Fail = Url.Action("PaymentFail", "ShoppingCart", null, currectScheme)
            };

            var paymentProvider = new PaymentProvider(_optionsAccessor);
            var hostOnlinePaymentUrl =
                paymentProvider.GetPaymentExpressHostUrl(paymentUrl, order);

            return Redirect(hostOnlinePaymentUrl);
        }

        // GET: /ShoppingCart/PaymentSuccess
        public ActionResult PaymentSuccess([FromQuery]string result)
        {
            var paymentProvider = new PaymentProvider(_optionsAccessor);
            var response = paymentProvider.GetPaymentExpressResponse(result);
            
            return View(response);
        }

        public ActionResult PaymentFail()
        {
            return View();
        }

    }
}