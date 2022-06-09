using ApiTesting2.Models;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace ApiTesting2.StepDefinitions
{
    [Binding]
    [Collection("Settings collection")]
    public class CommonStepDefinitions
    {
        private readonly ScenarioContext scenarioContext;

        public CommonStepDefinitions(ScenarioContext scenarioContext)
        {
            this.scenarioContext = scenarioContext;
        }

        [Then(@"Status code should be (.*)")]
        public void ThenStatusCodeShouldBe(int status)
        {
            var code = (int)scenarioContext.Get<HttpStatusCode>(Constants.STATUS_CODE_KEY);
            status.Should().Be(code);
        }


        [Then(@"response should have a valid access_token")]
        public void ThenResponseShouldHaveAValidAccess_Token()
        {
            var token = scenarioContext.Get<string>(Constants.ACCESS_TOKEN_KEY);
            token.Should().NotBeNullOrEmpty();
        }


        [Then(@"Response should not have Eror")]
        public void ThenResponseShouldNotHaveEror()
        {
            var error = scenarioContext.Get<bool>(Constants.ERROR);
            error.Should().BeFalse();
        }

        
    }
}
    