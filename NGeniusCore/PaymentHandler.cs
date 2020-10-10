using Newtonsoft.Json;
using RestSharp;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;


namespace NGeniusCore
{
    public class PaymentHandler
    {
        /// <summary>
        /// Get the payment URL from NGenius.
        /// </summary>
        /// <param name="context">The payment context.</param>
        /// <param name="configuration">The payment configuration.</param>
        /// <returns></returns>
        public virtual string GetPaymentUrl(NGeniusConfiguration configuration, OrderInfo  order)
        {
            var token = GetAccessToken(configuration);
            var url = CreateOrder(configuration, token, order);

            return url;
        }

        /// <summary>
        /// Get the payment status from NGenius.
        /// </summary>
        /// <param name="context">The Http context.</param>
        /// <param name="configuration">The payment configuration.</param>
        /// <param name="reference">NGenius order reference.</param>
        /// <returns></returns>
        public virtual string GetPaymentStatus(HttpContextBase context, NGeniusConfiguration configuration)
        {
            var reference = context.Request.QueryString[NGeniusConstants.ApiQueryStringRef];

            var token = GetAccessToken(configuration);
            var url = new Uri(GetPaymentBaseUrl(configuration), string.Format(NGeniusConstants.ApiUrl.OrderStatus, configuration.OutletId, reference));

            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", string.Format(NGeniusConstants.ApiauthorizationMode.Bearer, token));
            request.AddHeader("accept", NGeniusConstants.ApiPaymentAcceptJson);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var status = JsonConvert.DeserializeObject<OrderStatusResponse>(response.Content);

                return status.Embedded.Payment.First().State;
            }
            else
            {
                throw new Exception("Error while getting the order status", response.ErrorException);
            }
        }

        /// <summary>
        /// Request an access token
        /// </summary>
        /// <param name="configuration">The payment configuration.</param>
        /// <returns>Returns the authentication key from BPoint.</returns>
        private string GetAccessToken(NGeniusConfiguration configuration)
        {
            var url = new Uri(GetPaymentBaseUrl(configuration), NGeniusConstants.ApiUrl.AccessToken);
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", NGeniusConstants.ApiIdentityAcceptJson);
            request.AddHeader("content-type", NGeniusConstants.ApiIdentityAcceptJson);
            request.AddHeader("authorization", string.Format(NGeniusConstants.ApiauthorizationMode.Basic, configuration.APIKey));
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var token = JsonConvert.DeserializeObject<AccessTokenResponse>(response.Content);
                return token.AccessToken;
            }
            else
            {
                throw new Exception("Error while getting the token", response.ErrorException);
            }
        }

        /// <summary>
        /// Create order in PSP side.
        /// </summary>
        /// <param name="context">The payment context.</param>
        /// <param name="configuration">The payment configuration.</param>
        /// <param name="token"></param>
        /// <returns></returns>
        private string CreateOrder(NGeniusConfiguration configuration, string token, OrderInfo orderInfo)
        {
            var order = new CreateOrderRequest()
            {
                Action = NGeniusConstants.ApiOrderType.SALE,
                Amount = orderInfo.Amount,
                MerchantAttributes = new MerchantAttributes()
                {
                    RedirectUrl = configuration.RedirectUrl,
                    CancelUrl = configuration.CancelUrl,
                    SkipConfirmationPage = configuration.SkipConfirmationPage,
                    Skip3DS = configuration.Skip3DS
                },
                EmailAddress = "ajith@ajith.com"
            };

            var url = new Uri(GetPaymentBaseUrl(configuration), string.Format(NGeniusConstants.ApiUrl.CreateOrder, configuration.OutletId));

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", NGeniusConstants.ApiPaymentAcceptJson);
            request.AddHeader("content-type", NGeniusConstants.ApiPaymentAcceptJson);
            request.AddHeader("authorization", "Bearer " + token);
            var requestBody = JsonConvert.SerializeObject(order);
            request.AddParameter(NGeniusConstants.ApiPaymentAcceptJson, requestBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.Created)
            {
                var orderResponse = JsonConvert.DeserializeObject<CreateOrderResponse>(response.Content);
                return orderResponse.Links.Payment.Href.AbsoluteUri;
            }
            else
            {
                throw new Exception("Error while creating the order", response.ErrorException);
            }
        }

        /// <summary>
        /// Read the web hook data.
        /// </summary>
        /// <param name="context">The Http Context Base</param>
        /// <returns></returns>
        public virtual WebHookNotification GetWebHookNotification(HttpContextBase context)
        {
            var jsonResponse = string.Empty;
            context.Request.InputStream.Position = 0;
            var inputStream = new StreamReader(context.Request.InputStream);
            jsonResponse = inputStream.ReadToEnd();

            var notification = JsonConvert.DeserializeObject<WebHookNotification>(jsonResponse);

            return notification;
        }

        /// <summary>
        /// COnvert the Sana language code to PSP.
        /// </summary>
        /// <param name="languageId">THe language code.</param>
        /// <returns></returns>
        private string ConvertLanguageCode(int languageId)
        {
            switch (languageId)
            {
                case 1033: return NGeniusConstants.ApiLanguageCode.EN;
                case 1036: return NGeniusConstants.ApiLanguageCode.FR;
                case 1025: return NGeniusConstants.ApiLanguageCode.AR;
                default: return NGeniusConstants.ApiLanguageCode.EN;
            }
        }

        /// <summary>
        /// Get the payment URL.
        /// </summary>
        /// <param name="configuration">The payment configuration.</param>
        /// <returns></returns>
        private Uri GetPaymentBaseUrl(NGeniusConfiguration configs)
        {
            if (!configs.IsTest)
                return new Uri("https://api-gateway.ngenius-payments.com/");
            else
                return new Uri("https://api-gateway.sandbox.ngenius-payments.com/");
        }
    }
}