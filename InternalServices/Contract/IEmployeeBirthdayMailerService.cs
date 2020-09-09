
using DomainTypes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternalServices.Contract
{
    public interface IEmployeeBirthdayMailerService
    {
        Task SendTodaysBirthdaysAsync();
        Task<IEnumerable<Employee>> GetActiveEmployeesAsync();
    }
}
