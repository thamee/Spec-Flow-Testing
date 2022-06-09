using ApiTesting2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ApiTesting2.Support
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly ScenarioContext context;

        public AuthHeaderHandler(ScenarioContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = string.Empty;

            if (context.ContainsKey(Constants.ACCESS_TOKEN_KEY))
            {
                token = context.Get<string>(Constants.ACCESS_TOKEN_KEY);
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
