using ApiTesting2.Fixtures;
using ApiTesting2.Models;
using BoDi;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace ApiTesting2.Support
{
   
        [Binding]
        public sealed class Hooks
        {
            private readonly IObjectContainer objectContainer;
            private readonly SettingsFixture settings;
            private readonly ScenarioContext context;
            private Stopwatch stopwatch;

            public Hooks(IObjectContainer objectContainer, SettingsFixture settings, ScenarioContext context)
            {
                this.objectContainer = objectContainer;
                this.settings = settings;
                this.context = context;
                stopwatch = new Stopwatch();
            }
            // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

            [BeforeScenario("@messured")]
            public void BeforeScenarioWithTag()
            {
                stopwatch.Start();
            }

            [AfterScenario("@messured")]
            public void AfterScenario()
            {
                stopwatch.Stop();
                var responseTime = stopwatch.Elapsed.TotalMilliseconds;
                context.Add(Constants.RESPONSE_TIME_KEY, responseTime);
                //responseTime.Should().BeLessThan(settings.AppSettings.MinimumResponseTime);
                stopwatch.Reset();
            }
        }
}
