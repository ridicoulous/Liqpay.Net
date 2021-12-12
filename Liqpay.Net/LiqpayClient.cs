using Liqpay.Net.Interfaces;
using Liqpay.Net.Objects;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Liqpay.Net
{
    public class LiqpayClient : ILiqpayClient
    {
        private readonly HttpClient _httpClient;
        public LiqpayClient()
        {
            _httpClient = new HttpClient();
        }
        public LiqpayClient(HttpClient client)
        {
            _httpClient = client; 
        }
        public Task SendRequest(LiqpayRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
