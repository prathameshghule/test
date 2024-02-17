using System. ComponentModel.DataAnnotations;

namespace Project.Model
{
    public class Employee
    {
        [Key]
        public Guid EmpId { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }
        public String? MobileNumber { get; set; }
        public String? Gender { get; set; }
        public String? Address { get; set; }
        public String? Qualification { get; set; }
        public String? Designation { get; set; }

    }
}
