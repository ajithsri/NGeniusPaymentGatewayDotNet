using Newtonsoft.Json;

namespace NGeniusCore
{
    public class WebHookNotification
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("order")]
        public CreateOrderResponse Order { get; set; }
    }
}
