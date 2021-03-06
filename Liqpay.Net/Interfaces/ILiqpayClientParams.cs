using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security;
using System.Text;

namespace Liqpay.Net.Interfaces
{
    public interface ILiqpayClientParams
    {
        ILogger? Logger { get; }
        HttpClient? HttpClient { get; }
        public string PublicKey { get; }
        public string PrivateKey { get; }
        public string BackendUrl { get; }
        public string FrontendUrl { get; }
        public bool IsSandbox { get; }

    }
}
