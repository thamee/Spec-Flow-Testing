using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ApiTesting2.Fixtures
{
    public class SettingsFixture : IDisposable
    {
        public readonly AppSettings AppSettings;

        public SettingsFixture()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{env}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            AppSettings = new AppSettings
            {
                BaseAddress = configuration["baseUrl"],
                MinimumResponseTime = int.Parse(configuration["minimumResponseTime"])
            };
        }

        public void Dispose()
        {
        }
    }
}
