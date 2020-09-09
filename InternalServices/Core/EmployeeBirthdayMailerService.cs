
using DAL.Contract;
using DomainTypes;
using ExternalServices.Contract;
using InternalServices.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalServices.Core
{
    public class EmployeeBirthdayMailerService : IEmployeeBirthdayMailerService
    {
        private readonly IEmployeeApiProvider _employeeApi;
        private readonly IEmployeeStore _store;
        private readonly ISmtpMailProvider _mailProvider;
        public EmployeeBirthdayMailerService(IEmployeeApiProvider employeeApi,
                                      IEmployeeStore store,
                                      ISmtpMailProvider mailProvider)
        {
            _employeeApi = employeeApi;
            _store = store;
            _mailProvider = mailProvider;
        }

        /// <summary>
        /// Ideally this should be split into separate queueing and sending functions 
        /// </summary>
        public async Task SendTodaysBirthdaysAsync()
        {
            var employees = await GetActiveEmployeesAsync();

            var today = DateTime.Today.Date;
            var todaysBirthdays = from e in employees
                                  where e.DateOfBirth.Date.Month == today.Month && e.DateOfBirth.Date.Day == today.Day
                                  select e;

            var leaplings = employees.Where(e => e.DateOfBirth.Month == 2 && e.DateOfBirth.Day == 29);
            todaysBirthdays = todaysBirthdays.Except(leaplings);
            if (!DateTime.IsLeapYear(today.Year) && today.Month == 3 && today.Day == 1)// Using the UK standard for leap calculation: leaplings birthday on 1st mar for non-leap year
            {
                todaysBirthdays = todaysBirthdays.Concat(leaplings);
            }

            foreach (var emp in todaysBirthdays)
            {
                if (emp.BirthdayWishLastSentDate.HasValue && emp.BirthdayWishLastSentDate.Value.Date == today)
                {
                    continue;
                }

                var mailMsg = new MailMessage { To = $"{emp.Name} {emp.LastName}", Subject = "Birthday Greetings", Body = $"Happy Birthday {emp.Name}", EmailAddress = emp.EmailAddress };
                await _mailProvider.SendEmailAsync(mailMsg);

                await _store.UpdateSentDateAsync(emp.Id);
            }
        }

        public async Task<IEnumerable<Employee>> GetActiveEmployeesAsync()
        {
            var employeesApi = await _employeeApi.GetEmployeesAsync();
            var exclusionsFromApi = await _employeeApi.GetBirthdayWishExclusionsAsync();

            var activeEmployees = employeesApi.Where(e => !e.EmploymentEndDate.HasValue) // Exclusion #1: The employee no longer works for Realm Digital
                                           .Where(e => e.EmploymentStartDate.HasValue) // Exclusion #2: The employee has not started working for Realm Digital 
                                           .Where(e => !exclusionsFromApi.Contains(e.Id)); // Exclusion #3: Or the employee has been specifically configured to not receive birthday wishes.

            var employeesData = await _store.GetAllAsync();

            // Combine lists and return a rich business object
            var results = from m in activeEmployees
                          join n in employeesData on m.Id equals n.EmployeeId
                          select new Employee
                          {
                              Id = n.EmployeeId,
                              Name = m.Name,
                              LastName = m.LastName,
                              DateOfBirth = m.DateOfBirth,
                              EmailAddress = n.EmailAddress,
                              BirthdayWishLastSentDate = n.BirthdayWishSentDate,
                              EmploymentEndDate = m.EmploymentEndDate,
                              EmploymentStartDate = m.EmploymentStartDate
                          };

            return results;
        }
    }
}
