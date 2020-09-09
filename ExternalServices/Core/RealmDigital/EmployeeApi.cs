
using AutoMapper;
using Domain = DomainTypes.ExternalServiceTypes;
using ExternalServices.Contract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Dto = ExternalServices.DTO;

namespace ExternalServices.Core.RealmDigital
{
    public class EmployeeApi : IEmployeeApiProvider
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeApiConfigurationProvider _employeeApiConfigurationProvider;
        private readonly HttpClient _httpClient;
        public EmployeeApi(IEmployeeApiConfigurationProvider employeeApiConfigurationProvider,
                           HttpClient httpClient,
                           IMapper mapper)
        {
            _employeeApiConfigurationProvider = employeeApiConfigurationProvider;
            _httpClient = httpClient;
            _mapper = mapper;

            _httpClient.BaseAddress = new Uri(_employeeApiConfigurationProvider.HostAddress);
        }

        public async Task<IEnumerable<int>> GetBirthdayWishExclusionsAsync()
        {
            try
            {
                var requestUri = "/do-not-send-birthday-wishes";
                var result = await _httpClient.GetStringAsync(requestUri);
                var responseContainer = JsonConvert.DeserializeObject<IEnumerable<int>>(result);

                return responseContainer;
            }
            catch (Exception ex)
            {
                // Log using default logging provider
                throw;
            }
        }

        public async Task<IEnumerable<Domain.Employee>> GetEmployeesAsync()
        {
            try
            {
                var requestUri = "/employees";
                var result = await _httpClient.GetStringAsync(requestUri);
                var responseContainer = JsonConvert.DeserializeObject<IEnumerable<Dto.Employee>>(result);

                return _mapper.Map<IEnumerable<Domain.Employee>>(responseContainer);
            }
            catch (Exception ex)
            {
                // Log using default logging provider
                throw;
            }
        }
    }
}
