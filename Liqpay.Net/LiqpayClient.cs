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
        public LiqpayClient(ILiqpayClientParams config)
        {
            _httpClient = config.HttpClient ?? new HttpClient();
        }
        public LiqpayClient(HttpClient client)
        {
            _httpClient = client;
        }

        public bool CheckSignature(string data, string signature)
        {
            throw new NotImplementedException();
        }

        public LiqpayResponse OnServerCallback(string data, string signature)
        {
            throw new NotImplementedException();
        }

        public async Task<LiqpayResponse> SendRequest(LiqpayRequest request)
        {
            throw new NotImplementedException();
        }

    }
}
