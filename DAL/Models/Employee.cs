using System;

namespace DAL.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? BirthdayWishSentDate { get; set; }
    }
}
