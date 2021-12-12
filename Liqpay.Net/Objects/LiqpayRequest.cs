using Liqpay.Objects.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Liqpay.Net.Objects
{
    public class LiqpayRequest
    {
        [JsonPropertyName("version")]
        public int Version { get; set; }
        [JsonPropertyName("public_key")]
        public string PublicKey { get; set; }
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
        [JsonPropertyName("card_token")]
        public string CardToken { get; set; }
        [JsonPropertyName("ip")]
        public string IP { get; set; }
        [JsonPropertyName("prepare")]
        public string Prepare { get; set; }
        [JsonPropertyName("paytypes")]
        public LiqPayRequestPayType? PayTypes { get; set; }
        [JsonPropertyName("action")]
        public LiqPayRequestAction? Action { get; set; }
        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("sandbox")]
        public string Sandbox { get; set; }
        [JsonIgnore]
        public bool IsSandbox
        {
            get
            {
                return Sandbox == "1";
            }
            set
            {
                Sandbox = value ? "1" : null;
            }
        }
        [JsonPropertyName("order_id")]
        public string OrderId { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("action_payment")]
        public LiqPayRequestActionPayment? ActionPayment { get; set; }
        [JsonPropertyName("expired_date")]
        public DateTime? ExpiredDate { get; set; }
        [JsonPropertyName("goods")]
        public List<LiqpayRequestGoods> Goods { get; set; }
        [JsonPropertyName("language")]
        public LiqPayRequestLanguage? Language { get; set; }
        [JsonPropertyName("subscribe_periodicity")]
        public string SubscribePeriodicity { get; set; }
        public string Subscribe { get; set; }

        [JsonIgnore]
        public bool IsSubscribe
        {
            get { return Subscribe == "1"; }
            set { Subscribe = value ? "1" : "0"; }
        }

        [JsonPropertyName("subscribe_date_start")]
        public string SubscribeDateStart { get; set; }

        [JsonPropertyName("result_url")]
        public string ResultUrl { get; set; }
        [JsonPropertyName("server_url")]
        public string ServerUrl { get; set; }

        [JsonIgnore]
        public IDictionary<string, string> OtherParams { get; set; } = new Dictionary<string, string>();

    }
}
