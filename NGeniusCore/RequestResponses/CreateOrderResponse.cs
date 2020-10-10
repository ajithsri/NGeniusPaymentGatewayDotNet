using System;
using Newtonsoft.Json;

namespace NGeniusCore
{
    public partial class CreateOrderResponse
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("_links")]
        public CreateOrderResponseLinks Links { get; set; }

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

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }

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

        [JsonProperty("merchantOrderReference")]
        public string MerchantOrderReference { get; set; }

        [JsonProperty("formattedAmount")]
        public string FormattedAmount { get; set; }

        [JsonProperty("formattedOrderSummary")]
        public FormattedOrderSummary FormattedOrderSummary { get; set; }

        [JsonProperty("_embedded")]
        public Embedded Embedded { get; set; }
    }

    public class Embedded
    {
        [JsonProperty("payment")]
        public Payment[] Payment { get; set; }
    }

    public class Payment
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("_links")]
        public PaymentLinks Links { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("amount")]
        public Amount Amount { get; set; }

        [JsonProperty("updateDateTime")]
        public DateTimeOffset UpdateDateTime { get; set; }

        [JsonProperty("outletId")]
        public Guid OutletId { get; set; }

        [JsonProperty("orderReference")]
        public Guid OrderReference { get; set; }

        [JsonProperty("merchantOrderReference")]
        public string MerchantOrderReference { get; set; }
    }

    public class PaymentLinks
    {
        [JsonProperty("cnp:china_union_pay_timeout")]
        public CnpPaymentLink CnpChinaUnionPayTimeout { get; set; }

        [JsonProperty("payment:china_union_pay")]
        public CnpPaymentLink PaymentChinaUnionPay { get; set; }

        [JsonProperty("self")]
        public CnpPaymentLink Self { get; set; }

        [JsonProperty("cnp:china_union_pay_results")]
        public CnpPaymentLink CnpChinaUnionPayResults { get; set; }

        [JsonProperty("payment:card")]
        public CnpPaymentLink PaymentCard { get; set; }

        [JsonProperty("curies")]
        public Cury[] Curies { get; set; }
    }

    public class CnpPaymentLink
    {
        [JsonProperty("href")]
        public Uri Href { get; set; }
    }

    public class Cury
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("href")]
        public string Href { get; set; }

        [JsonProperty("templated")]
        public bool Templated { get; set; }
    }

    public class CreateOrderResponseLinks
    {
        [JsonProperty("cnp:payment-link")]
        public CnpPaymentLink CnpPaymentLink { get; set; }

        [JsonProperty("payment-authorization")]
        public CnpPaymentLink PaymentAuthorization { get; set; }

        [JsonProperty("self")]
        public CnpPaymentLink Self { get; set; }

        [JsonProperty("tenant-brand")]
        public CnpPaymentLink TenantBrand { get; set; }

        [JsonProperty("payment")]
        public CnpPaymentLink Payment { get; set; }

        [JsonProperty("merchant-brand")]
        public CnpPaymentLink MerchantBrand { get; set; }
    }

    public class PaymentMethods
    {
        [JsonProperty("card")]
        public string[] Card { get; set; }

        [JsonProperty("apm")]
        public string[] Apm { get; set; }
    }
}
