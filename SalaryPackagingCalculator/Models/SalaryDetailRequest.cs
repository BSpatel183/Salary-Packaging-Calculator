namespace SalaryPackagingCalculator.Models
{
    public class SalaryDetailRequest
    {
        public double AnnualSalary { get; set; }
        public string EmployerType { get; set; }
        public string EmploymentType { get; set; }
        public double HoursWorked { get; set; }
        public bool IsEducated { get; set; }
    }
}
