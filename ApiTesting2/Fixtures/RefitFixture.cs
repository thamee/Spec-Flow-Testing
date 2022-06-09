using ApiTesting2.Support;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ApiTesting2.Fixtures
{
    public class RefitFixture<TRefitApi> : IDisposable
    {
        public TRefitApi GetRestClient(string baseAddress, ScenarioContext context) =>
           RestService.For<TRefitApi>(new HttpClient(new AuthHeaderHandler(context))
           {
               BaseAddress = new Uri(baseAddress)
           }
           );

        public void Dispose()
        {
        }
    }
}
