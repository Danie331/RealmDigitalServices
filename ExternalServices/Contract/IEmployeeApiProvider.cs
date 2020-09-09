
using Domain = DomainTypes.ExternalServiceTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExternalServices.Contract
{
    public interface IEmployeeApiProvider
    {
        Task<IEnumerable<Domain.Employee>> GetEmployeesAsync();
        Task<IEnumerable<int>> GetBirthdayWishExclusionsAsync();
    }
}
