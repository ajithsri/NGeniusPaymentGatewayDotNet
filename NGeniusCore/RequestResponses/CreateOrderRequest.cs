using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGeniusCore
{
    public class CreateOrderRequest
    {
        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("merchantAttributes")]
        public MerchantAttributes MerchantAttributes { get; set; }

        [JsonProperty("merchantOrderReference")]
        public string MerchantOrderReference { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }

    public class Amount
    {
        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("value")]
        public int Value { get; set; }
    }

    public class MerchantAttributes
    {
        [JsonProperty("redirectUrl")]
        public string RedirectUrl { get; set; }

        [JsonProperty("cancelUrl")]
        public string CancelUrl { get; set; }        

        [JsonProperty("skipConfirmationPage")]
        public bool SkipConfirmationPage { get; set; }

        [JsonProperty("skip3DS")]
        public bool Skip3DS { get; set; }
    }
}
