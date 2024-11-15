using Microsoft.AspNetCore.Mvc;
using SalaryPackagingCalculator.Models;

namespace SalaryPackagingCalculator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryPackageController : ControllerBase
    {
        // Constructor to inject the ApplicationDbContext
        public SalaryPackageController()
        {
        }

        [HttpPost, Route("")]
        public double CalculateLimit(SalaryDetailRequest request)
        {
            if (request.AnnualSalary <= 0 || string.IsNullOrEmpty(request.EmployerType) || string.IsNullOrEmpty(request.EmploymentType))
            {
                return 0; // Invalid input
            }

            double limit;
            switch (request.EmployerType)
            {
                case "Corporate":
                    limit = CalculateCorporateLimit(request.AnnualSalary, request.EmploymentType, request.HoursWorked);
                    break;
                case "Hospital":
                    limit = CalculateHospitalLimit(request.AnnualSalary, request.EmploymentType, request.IsEducated);
                    break;
                case "PBI":
                    limit = CalculatePBILimit(request.AnnualSalary, request.EmploymentType, request.IsEducated);
                    break;
                default:
                    return 0;
            }

            return Math.Max(0, limit);
        }

        private static double CalculateCorporateLimit(double salary, string employmentType, double hoursWorked)
        {
            if (employmentType == "Casual") 
                return 0;

            double limit = salary <= 100000
                ? salary * 0.01
                : 100000 * 0.01 + (salary - 100000) * 0.001;

            if (employmentType == "Part-time")
            {
                limit *= Math.Min(1, hoursWorked / 38);
            }

            return limit;
        }

        private static double CalculateHospitalLimit(double salary, string employmentType, bool educated)
        {
            double limit = Math.Max(10000, Math.Min(30000, salary * 0.2));
            
            if (educated)
            { 
                limit += 5000; 
            }

            if (employmentType == "Full-time")
            {
                limit += limit * 0.095 + salary * 0.012;
            }

            return limit;
        }

        private static double CalculatePBILimit(double salary, string employmentType, bool educated)
        {
            double limit;

            if (employmentType == "Casual")
            {
                limit = salary * 0.1;
            }
            else
            {
                limit = Math.Min(50000, salary * 0.3255);

                if (educated)
                {
                    limit += 2000 + salary * 0.01;
                }

                if (employmentType == "Part-time")
                {
                    limit *= 0.8;
                }
            }

            return limit;
        }
    }
}