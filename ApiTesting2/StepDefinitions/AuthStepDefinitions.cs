using ApiTesting2.Apis;
using ApiTesting2.Fixtures;
using ApiTesting2.Models;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace ApiTesting2.StepDefinitions
{
    [Binding]
    [Collection("Settings collection")]
    public class AuthStepDefinitions : RefitFixture<IAuthApi>
    {
        private readonly ScenarioContext scenarioContext;
        private readonly SettingsFixture settings;

        public AuthStepDefinitions(ScenarioContext scenarioContext, SettingsFixture settings)
        {
            this.scenarioContext = scenarioContext;
            this.settings = settings;
        }

        [Given(@"Admin username is (.*)")]
        public void GivenAdminUsername(RandomisedValue randomizedValue)
        {
            scenarioContext.Add(Constants.USERNAME_KEY, randomizedValue.StringValue);
        }

        [When(@"Create admin api is called")]
        public async Task WhenCreateAdminApiIsCalled()
        {
            var token = await GetRestClient(settings.AppSettings.BaseAddress, scenarioContext)
                .CreateAdmin(new CreateUserRequest
                {
                    username = scenarioContext.Get<string>(Constants.USERNAME_KEY),
                    password = scenarioContext.Get<string>(Constants.PASSWORD_KEY),
                    extra = scenarioContext.Get<string>(Constants.USERNAME_KEY)
                });

            scenarioContext.Add(Constants.ACCESS_TOKEN_KEY, token?.Content?.AccessToken);
            scenarioContext.Add(Constants.STATUS_CODE_KEY, token?.StatusCode);
        }

        [Given(@"A new admin is created with username (.*) and password (.*)")]
        public async Task GivenANewAdminIsCreated(RandomisedValue randomizedValue, string password)
        {
            var token = await GetRestClient(settings.AppSettings.BaseAddress, scenarioContext)
                .CreateAdmin(new CreateUserRequest
                {
                    username = randomizedValue.StringValue,
                    password = password,
                    extra = randomizedValue.StringValue
                });

            scenarioContext.Add(Constants.ACCESS_TOKEN_KEY, token?.Content?.AccessToken);
            scenarioContext.Add(Constants.STATUS_CODE_KEY, token?.StatusCode);
        }
        [Given(@"the password is blank ""(.*)""")]
        [Given(@"Admin password is (.*)")]
        public void GivenAdminPasswordIsPass(string password)
        {
            scenarioContext.Add(Constants.PASSWORD_KEY, password);
        }

        [Given(@"the user already exists")]
        public string user()
        {
            string user = scenarioContext.Get<string>(Constants.USERNAME_KEY);
            return user;
        }
        [Given(@"the password is valid")]
        public string pass()
        {
            string pass = scenarioContext.Get<string>(Constants.PASSWORD_KEY);
            return pass;
        }

        [When(@"login admin api is called")]
        public async Task WhenLoginAdminApiIsCalled()
        {
            string adminUsername = user();
            string adminPassword = pass();
            var token = await GetRestClient(settings.AppSettings.BaseAddress, scenarioContext)
            .Login(new LoginRequest
            {
                username = adminUsername,
                password = adminPassword
            });
        }
    }
}
