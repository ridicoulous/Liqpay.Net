using Liqpay.Net.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Liqpay.Net.Interfaces
{
    public interface ILiqpayClient
    {
        Task SendRequest(LiqpayRequest request);


        LiqpayResponse OnServerCallback(string data, string signature);
        bool CheckSignature(string data, string signature);
        (string data, string signature) GenerateRequest(LiqpayRequest request);
    }
}
