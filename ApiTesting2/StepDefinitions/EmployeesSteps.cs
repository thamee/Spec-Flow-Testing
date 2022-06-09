using ApiTesting2.Apis;
using ApiTesting2.Fixtures;
using ApiTesting2.Models;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;
using ApiTesting2.Support;

namespace ApiTesting2.StepDefinitions
{
    [Binding]
    [Collection("Settings Collection")]
    public class EmployeesStepDefinitions : RefitFixture<IEmployeeApi>
    {
        private readonly ScenarioContext context;
        private readonly SettingsFixture settings;

        public EmployeesStepDefinitions(ScenarioContext context, SettingsFixture settings)
        {
            this.context = context;
            this.settings = settings;
        }

        [When(@"Get Employee list api is called")]
        public async Task WhenGetEmployeeListApiIsCalled()
        {
            var employees = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                    .GetEmployees();
            context.Remove(Constants.STATUS_CODE_KEY);
            context.Add(Constants.STATUS_CODE_KEY, employees?.StatusCode);

        }
        [Given(@"ModelState is correct")]
        public void GivenModelStateIsCorrect()
        {
        }
        [When(@"Add Employee list api is called")]
        public async Task  WhenAddEmployeeListApiIsCalled()
        {
            var request = new CreateEmployeeRequest
            {
                id = Transformations.GenerateNumber(),
                employee_name = Transformations.GenerateName(10),
                employee_salary = 100000,
                employee_age = 28,
                profile_image = null
            };
            var employee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                    .CreateEmployee(request);
            context.Remove(Constants.STATUS_CODE_KEY);
            context.Add(Constants.STATUS_CODE_KEY, employee?.StatusCode);
            context.Add(Constants.ERROR, employee?.Content?.id >= 0);
            context.Remove(Constants.EMPLOYEEID);
        }

        [When(@"Get Employee By Id api is called\((.*)\)")]
        public async Task WhenGetEmployeeByIdApiIsCalled(int id)
        {
            var employee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .GetEmployeeById(id);
            context.Remove(Constants.STATUS_CODE_KEY);
            context.Add(Constants.STATUS_CODE_KEY, employee?.StatusCode);
        }



        [When(@"Delete  Employee  api is called\((.*)\)")]
        public async Task WhenDeleteEmployeeApiIsCalled(int id)
        {
            var employee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                    .DeleteEmployee(id);
            context.Remove(Constants.STATUS_CODE_KEY);
            context.Add(Constants.STATUS_CODE_KEY, employee?.StatusCode);
        }

        [When(@"Update  Employee list api is called\((.*),(.*),(.*),(.*),(.*)\)")]
        public async Task WhenUpdateEmployeeListApiIsCalled(int Id, string employee_name, int employee_salary, int employee_age, string profile_image)
        {
            var request = new UpdateEmployeRequest
            {
                id = Id,
                employee_name = employee_name,
                salary = employee_salary,
                age = employee_age,
                profile_image = profile_image
            };
            var updatedemployee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                    .UpdateEmployee(request);
            var employee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .GetEmployeeById(Id);
            context.Remove(Constants.STATUS_CODE_KEY);
            context.Add(Constants.STATUS_CODE_KEY, updatedemployee?.StatusCode);
            context.Remove(Constants.ERROR);
            context.Add(Constants.ERROR, employee?.Content?.employee_name != employee_name);

        }
        

 




    }
}
