using Liqpay.Net.Converters;
using Liqpay.Objects.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liqpay.Net.Objects
{
    public  class LiqpayResponse
    {
        [JsonProperty("result")]
        public string Result { get; set; }
        [JsonProperty("action")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LiqPayResponseAction Action { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("href")]
        public string Href { get; set; }
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("order_id")]
        public string OrderId { get; set; }
        [JsonProperty("payment_id")]
        public long PaymentId { get; set; }
        [JsonProperty("transaction_id")]
        public long TransactionId { get; set; }
        [JsonProperty("receiver_type")]
        public string ReceiverType { get; set; }
        [JsonProperty("receiver_value")]
        public string ReceiverValue { get; set; }
        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public LiqPayResponseStatus Status { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
        [JsonProperty("err_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("err_description")]
        public string ErrorDescription { get; set; }
        [JsonProperty("invoice_id")]
        public int? InvoiceId { get; set; }
        [JsonProperty("refund_amount")]
        public decimal RefundAmount { get; set; }
        [JsonProperty("refund_date_last")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime? RefundDateLast { get; set; }
        [JsonProperty("create_date")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime CreateDate { get; set; }
    }
}
