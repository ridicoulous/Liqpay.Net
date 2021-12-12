using System;
using System.Collections.Generic;
using System.Text;

namespace Liqpay.Net.Objects
{
    public class LiqpayRequestGoods
    {

        [JsonPropertyName("amount")]
        public double Amount { get; set; }
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("unit")]
        public string Unit { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
