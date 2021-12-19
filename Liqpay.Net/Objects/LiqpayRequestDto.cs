using System;
using System.Collections.Generic;
using System.Text;

namespace Liqpay.Net.Objects
{
    public class LiqpayRequestDto
    {
        public LiqpayRequestDto(string data, string signature)
        {
            this.data = data ?? throw new ArgumentNullException(nameof(data));
            this.signature = signature ?? throw new ArgumentNullException(nameof(signature));
        }

        public string data { get; set; }
        public string signature { get; set; }
    }
}
