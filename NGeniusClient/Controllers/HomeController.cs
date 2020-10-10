using NGeniusCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NGeniusClient.Controllers
{
    public class HomeController : Controller
    {
        PaymentHandler paymentHandler;
        NGeniusConfiguration configuration;
        public HomeController()
        {
            configuration = new NGeniusConfiguration()
            {
                IsTest = true,
                APIKey = "xxxxxxxxxxx",
                OutletId = "xxxxx",
                RedirectUrl = "http://sriajith.info/redirect",
                CancelUrl = "http://sriajith.info/cancel"
            };
            paymentHandler = new PaymentHandler();
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string amount)
        {
            var order = new OrderInfo()
            {
                Amount = new Amount()
                {
                    CurrencyCode = "AED",
                    Value = (int)(120.25 * NGeniusConstants.CurrencyMultiplicationFactor)
                }
            };
            var url = paymentHandler.GetPaymentUrl(configuration, order);
            return Redirect(url);
        }

        public ActionResult Success()
        {
            var status = paymentHandler.GetPaymentStatus(Request.RequestContext.HttpContext, configuration);

            if (status == NGeniusConstants.ApiResponseState.CAPTURED)
            {
                // Write the logc here.
            }

            return View();
        }

        [HttpPost]
        public ActionResult WebHookCallback()
        {
            var notification = paymentHandler.GetWebHookNotification(Request.RequestContext.HttpContext);

            if (notification.EventName == NGeniusConstants.ApiResponseState.CAPTURED)
            {
                // write ur logic here
            }

            return View();
        }

        public ActionResult Failed()
        {

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}