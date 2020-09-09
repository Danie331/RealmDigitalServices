
using AutoMapper;
using DAL.Contract;
using DomainTypes.DataStoreTypes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Core
{
    public class EmployeeStore : IEmployeeStore
    {
        private readonly IMapper _mapper;
        private readonly AssessmentContext _context;
        public EmployeeStore(AssessmentContext context,
                            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            try
            {
                var employees = await _context.Employee.AsNoTracking().ToArrayAsync();
                return _mapper.Map<IEnumerable<Employee>>(employees);
            }
            catch (Exception ex)
            {
                // Log
                throw;
            }
        }

        public async Task UpdateSentDateAsync(int employeeId)
        {
            try
            {
                var entity = await _context.Employee.FirstAsync(e => e.EmployeeId == employeeId);
                entity.BirthdayWishSentDate = DateTime.Today.Date;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log
                throw;
            }
        }
    }
}
