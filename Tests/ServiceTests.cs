
using InternalServices.Contract;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Tests
{
    [TestFixture]
    public class ServiceTests
    {
        private IServiceProvider _serviceProvider;
        [SetUp]
        public void Setup()
        {
            _serviceProvider = new DependencyConfiguration().CreateServiceProvider();
        }

        [Test]
        public async Task Test_GetActiveEmployeesAsync()
        {
            var service = _serviceProvider.GetService<IEmployeeBirthdayMailerService>();

            await service.GetActiveEmployeesAsync();

            Assert.Pass();
        }

        [Test]
        public async Task Test_SendTodaysBirthdaysAsync()
        {
            var service = _serviceProvider.GetService<IEmployeeBirthdayMailerService>();

            await service.SendTodaysBirthdaysAsync();

            Assert.Pass();
        }
    }
}
