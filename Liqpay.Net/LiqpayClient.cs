using Liqpay.Net.Interfaces;
using Liqpay.Net.Objects;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Liqpay.Net
{
    public class LiqpayClient : ILiqpayClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger? _logger;
        private readonly ILiqpayClientParams _config;
        private const string ServerServerUrl = "request";
        private const string ClientServerUrl = "3/checkout";
        private readonly JsonSerializerSettings _jsonSettings = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
        public LiqpayClient(ILiqpayClientParams config)
        {
            _config = config;
            _logger = _config.Logger;
            _httpClient = config.HttpClient ?? new HttpClient();
            _httpClient.BaseAddress = new Uri("https://www.liqpay.ua/api/");
        }

        public bool CheckSignature(string data, string signature)
        {
            _logger?.LogTrace("Checking signature {sig} for data {data}", signature, data);
            bool result = signature.Equals(data.CreateSignature(_config.PrivateKey));
            if (!result)
            {
                _logger?.LogError("Signature {sig} for data {data} was not valid", signature, data);
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
            request.IsSandbox = _config.IsSandbox;

            var data = JsonConvert.SerializeObject(request, _jsonSettings).ToBase64String();
            var signature = data.CreateSignature(_config.PrivateKey);
            return (data, signature);
        }
        public async Task SendRequest(LiqpayRequest request)
        {
            var dataSign = GenerateRequest(request);
            await SendRequest(new Dictionary<string, string>() { { "data", dataSign.data }, { "signature", dataSign.signature } });
        }

        private async Task SendRequest(Dictionary<string, string> request)
        {       
            var req = new HttpRequestMessage(HttpMethod.Post, ServerServerUrl) { Content = new FormUrlEncodedContent(request) };
            var res = await _httpClient.SendAsync(req);
            if (res.IsSuccessStatusCode)
            {
                _logger?.LogTrace("Request {@req} was successfully sended", request);
                return;
            }
            else
            {
                var error = await res.Content.ReadAsStringAsync();
                _logger?.LogError("Catched error at sending {@request} to server-server url: {error}", request, error);
            }
        }


    }
}
