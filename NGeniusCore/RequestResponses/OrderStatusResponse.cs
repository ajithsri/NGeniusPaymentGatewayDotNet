using System;
using Newtonsoft.Json;

namespace NGeniusCore
{
    public class OrderStatusResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("_links")]
        public OrderStatusResponseLinks Links { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("merchantDefinedData")]
        public FormattedOrderSummary MerchantDefinedData { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("merchantAttributes")]
        public MerchantAttributes MerchantAttributes { get; set; }

        [JsonProperty("reference")]
        public Guid Reference { get; set; }

        [JsonProperty("outletId")]
        public Guid OutletId { get; set; }

        [JsonProperty("createDateTime")]
        public DateTimeOffset CreateDateTime { get; set; }

        [JsonProperty("paymentMethods")]
        public PaymentMethods PaymentMethods { get; set; }

        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        [JsonProperty("formattedAmount")]
        public string FormattedAmount { get; set; }

        [JsonProperty("formattedOrderSummary")]
        public FormattedOrderSummary FormattedOrderSummary { get; set; }

        [JsonProperty("_embedded")]
        public OrderStatusResponseEmbedded Embedded { get; set; }
    }

    public partial class OrderStatusResponseEmbedded
    {
        [JsonProperty("payment")]
        public Payment[] Payment { get; set; }
    }
   
    public partial class AuthResponse
    {
        [JsonProperty("authorizationCode")]
        public string AuthorizationCode { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("resultCode")]
        public string ResultCode { get; set; }

        [JsonProperty("resultMessage")]
        public string ResultMessage { get; set; }

        [JsonProperty("mid")]
        public string Mid { get; set; }

        [JsonProperty("rrn")]
        public string Rrn { get; set; }
    }

    public partial class PaymentEmbedded
    {
        [JsonProperty("cnp:capture")]
        public CnpCapture[] CnpCapture { get; set; }
    }

    public partial class CnpCapture
    {
        [JsonProperty("_links")]
        public CnpCaptureLinks Links { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("createdTime")]
        public DateTimeOffset CreatedTime { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }

    public partial class CnpCaptureLinks
    {
        [JsonProperty("self")]
        public MerchantBrand Self { get; set; }
    }

    public partial class MerchantBrand
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public partial class PaymentMethod
    {
        [JsonProperty("expiry")]
        public string Expiry { get; set; }

        [JsonProperty("cardholderName")]
        public string CardholderName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pan")]
        public string Pan { get; set; }
    }

    public partial class The3Ds
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("eci")]
        public string Eci { get; set; }

        [JsonProperty("eciDescription")]
        public string EciDescription { get; set; }
    }

    public partial class FormattedOrderSummary
    {
    }

    public partial class OrderStatusResponseLinks
    {
        [JsonProperty("self")]
        public MerchantBrand Self { get; set; }

        [JsonProperty("tenant-brand")]
        public MerchantBrand TenantBrand { get; set; }

        [JsonProperty("merchant-brand")]
        public MerchantBrand MerchantBrand { get; set; }
    }
}
