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
        [When(@"Get Employee By Id api is called")]
        public async Task WhenGetEmployeeByIdApiIsCalled()
        {
            var request = new CreateEmployeeRequest
            {
                id = Transformations.GenerateNumber(),
                employee_name = Transformations.GenerateName(10),
                employee_salary = 100000,
                employee_age = 28,
                profile_image = null
            };
            await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .CreateEmployee(request);
            var employee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .GetEmployeeById(request.id);
            context.Remove(Constants.STATUS_CODE_KEY);
            context.Add(Constants.STATUS_CODE_KEY, employee?.StatusCode);
            context.Add(Constants.ERROR, employee?.Content?.id != request.id);
        }

        [When(@"Delete  Employee  api is called")]
        public async Task WhenDeleteEmployeeApiIsCalled()
        {
            var request = new CreateEmployeeRequest
            {
                id = Transformations.GenerateNumber(),
                employee_name = Transformations.GenerateName(10),
                employee_salary = 100000,
                employee_age = 28,
                profile_image = null
            };
            await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .CreateEmployee(request);
            var employee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .DeleteEmployee(request.id);
            var response = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .GetEmployeeById(request.id);
            context.Remove(Constants.STATUS_CODE_KEY);
            context.Add(Constants.STATUS_CODE_KEY, employee?.StatusCode);
            context.Add(Constants.ERROR, response?.Content?.id<=0);
        }

        [When(@"Update  Employee list api is called")]
        public async Task WhenUpdateEmployeeListApiIsCalled()
        {
            var createRequest = new CreateEmployeeRequest
            {
                id = Transformations.GenerateNumber(),
                employee_name = Transformations.GenerateName(10),
                employee_salary = 100000,
                employee_age = 28,
                profile_image = null
            };
            await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .CreateEmployee(createRequest);
            var request = new UpdateEmployeRequest
            {
                id = createRequest.id,
                employee_name = Transformations.GenerateName(10),
                salary = 70000,
                age = 29,
                profile_image = null
            };
            var updatedemployee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                    .UpdateEmployee(request);
            var employee = await GetRestClient(settings.AppSettings.BaseAddress, context)
                                   .GetEmployeeById(request.id);
            context.Remove(Constants.STATUS_CODE_KEY);
            context.Add(Constants.STATUS_CODE_KEY, updatedemployee?.StatusCode);
            context.Remove(Constants.ERROR);
            context.Add(Constants.ERROR, employee?.Content?.employee_name != request.employee_name);

        }
        

 




    }
}
