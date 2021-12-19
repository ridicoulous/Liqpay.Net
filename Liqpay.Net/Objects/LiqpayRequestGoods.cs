using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Liqpay.Net.Objects
{
    public class LiqpayRequestGoods
    {

        [JsonProperty("amount")]
        public double Amount { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
        [JsonProperty("unit")]
        public string Unit { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }

    }
}
