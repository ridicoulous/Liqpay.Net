using Liqpay.Net.Interfaces;
using Liqpay.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Liqpay.Net
{
    public class LiqpayClient : ILiqpayClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger? _logger;
        private readonly ILiqpayClientParams _config;
        public LiqpayClient(ILiqpayClientParams config)
        {
            _config = config;
            _logger = _config.Logger;
            _httpClient = config.HttpClient ?? new HttpClient();
        }

        public bool CheckSignature(string data, string signature)
        {
            _logger.LogTrace("Checking signature {sig} for data {data}", signature, data);
            bool result = signature.Equals(data.CreateSignature(_config.PrivateKey));
            if (!result)
            {
                _logger.LogError("Signature {sig} for data {data} was not valid", signature, data);
            }
            return result;

        }
        public LiqpayResponse OnServerCallback(string data, string signature)
        {
            if (!CheckSignature(data, signature))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<LiqpayResponse>(data.DecodeBase64());
        }
        public (string data, string signature) GenerateRequest(LiqpayRequest request)
        {
            var data = JsonConvert.SerializeObject(request).ToBase64String();
            var signature = data.CreateSignature(_config.PrivateKey);
            return (data, signature);
        }
        public async Task<LiqpayResponse> SendRequest(LiqpayRequest request)
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage() { Content = new StringContent(JsonConvert.SerializeObject(request)) });
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError("Liqpay API call was unsuccesful: [{body}] {@resp}", response.Content.ReadAsStringAsync().Result, response);
                return null;
            }
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LiqpayResponse>(result);
        }

    }
}
