namespace Project.Dto
{
    public class EmployeeDto
    {
        public Guid EmpId { get; set; }
        public String? Name { get; set; }
        public String? Email { get; set; }
        public String? MobileNumber { get; set; }
        public String? Gender { get; set; }
        public String? Address { get; set; }
        //public String? Qualification { get; set; }
       public String? Qualification { get; set; }
       public String? Designation { get; set; }
    }
    public class EmployeeRequestDto
    {
       // public Guid Id { get; set; }    
        public String? Name { get; set; }  = null;
        public String? Email { get; set; }
        public String? MobileNumber { get; set; }
        public String? Gender { get; set; }
        public String? Address { get; set; } = null; 
       // public String? Qualification { get;}
        public String? Qualification { get; set; }
        public String? Designation { get; set; }
    }


}

