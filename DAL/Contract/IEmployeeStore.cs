
using Domain = DomainTypes.DataStoreTypes;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DAL.Contract
{
    public interface IEmployeeStore
    {
        Task<IEnumerable<Domain.Employee>> GetAllAsync();
        Task UpdateSentDateAsync(int employeeId);
    }
}
