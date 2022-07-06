using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var softUniContext = new SoftUniContext();
            /*
            //03. Employees Full Information
            var output = GetEmployeesFullInformation(softUniContext);
            Console.WriteLine(output);

            //04. Employees with Salary Over 50 000
            var output = GetEmployeesWithSalaryOver50000(softUniContext);
            Console.WriteLine(output);

            //05. Employees from Research and Development
            var output = GetEmployeesFromResearchAndDevelopment(softUniContext);
            Console.WriteLine(output);

            //06. Adding a New Address and Updating Employee
            var output = AddNewAddressToEmployee(softUniContext);
            Console.WriteLine(output);

            //07. Employees and Projects
            var output = GetEmployeesInPeriod(softUniContext);
            Console.WriteLine(output);

            //08. Addresses by Town
            var output = GetAddressesByTown(softUniContext);
            Console.WriteLine(output);

            //09. Employee 147
            var output = GetEmployee147(softUniContext);
            Console.WriteLine(output);

            //10. Departments with More Than 5 Employees
            var output = GetDepartmentsWithMoreThan5Employees(softUniContext);
            Console.WriteLine(output);

            //11. Find Latest 10 Projects
            var output = GetLatestProjects(softUniContext);
            Console.WriteLine(output);

            //12. Increase Salaries
            var output = IncreaseSalaries(softUniContext);
            Console.WriteLine(output);

            //13.Find Employees by First Name Starting with "Sa"
            var output = GetEmployeesByFirstNameStartingWithSa(softUniContext);
            Console.WriteLine(output);

            //14. Delete Project by Id
            var output = DeleteProjectById(softUniContext);
            Console.WriteLine(output);
            */

            //15. Remove Town
            var output = RemoveTown(softUniContext);
            Console.WriteLine(output);
        }

        //15. Problem
        public static string RemoveTown(SoftUniContext context)
        {
            var townToDelete = "Seattle";
            var town = context.Towns
                .Include(a => a.Addresses)
                .FirstOrDefault(t => t.Name == townToDelete);

            var allAddressIds = town.Addresses
                .Select(a => a.AddressId).ToList();

            var employees = context.Employees
                .Where(e => e.AddressId.HasValue && allAddressIds.Contains(e.AddressId.Value))
                .ToList();

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            foreach (var addressId in allAddressIds)
            {
                var address = context.Addresses
                    .FirstOrDefault(a => a.AddressId == addressId);

                context.Addresses.Remove(address);
            }

            context.Towns.Remove(town);

            context.SaveChanges();

            var deletedAddresses = allAddressIds.Count;

            return $"{deletedAddresses} addresses in {townToDelete} were deleted";
        }

        //14. Problem
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectIdDelete = 2;

            var employeesToDelete = context.EmployeesProjects
                .Where(p => p.ProjectId == projectIdDelete);
            context.EmployeesProjects.RemoveRange(employeesToDelete);

            var deleteProject = context.Projects
                .FirstOrDefault(p => p.ProjectId == projectIdDelete);
            context.Projects.Remove(deleteProject);

            context.SaveChanges();

            var tenProjects = context.Projects
                .Select(p => p.Name)
                .Take(10)
                .ToList();

            return String.Join(Environment.NewLine, tenProjects);
        }

        //13. Problem
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employees = context.Employees
                .Where(e => EF.Functions.Like(e.FirstName, "sa%"))
                //.Where(e => e.FirstName.Substring(0, 2).ToLower() == "sa")
                .Select(e => new 
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //12. Problem
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var departments = new List<string>()
            {
                "Engineering",
                "Tool Design",
                "Marketing",
                "Information Services"
            };

            var employees = context.Employees
                .Where(d => departments.Contains(d.Department.Name))
                .ToList();

            foreach (var employee in employees)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Problem
        public static string GetLatestProjects(SoftUniContext context)
        {
            var lastProjects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var project in lastProjects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine($"{project.StartDate:M/d/yyyy h:mm:ss tt}");
            }

            return sb.ToString().TrimEnd();
        }

        //10. Problem
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Include(e => e.Employees)
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                { 
                    d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastName = d.Manager.LastName,
                    Employees = d.Employees.Select(e => new 
                    { 
                        e.FirstName,
                        e.LastName,
                        e.JobTitle})
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList()
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var depatment in departments)
            {
                sb.AppendLine($"{depatment.Name} – {depatment.ManagerFirstName} {depatment.ManagerLastName}");

                foreach (var employee in depatment.Employees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //09. Problem
        public static string GetEmployee147(SoftUniContext context)
        {
            var targetEmployee = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .OrderBy(p => p.Project.Name)
                        .Select(p => p.Project.Name)
                        .ToList()
                })
                .FirstOrDefault(e => e.EmployeeId == 147);

            var sb = new StringBuilder();
            sb.AppendLine($"{targetEmployee.FirstName} {targetEmployee.LastName} - {targetEmployee.JobTitle}");

            foreach (var project in targetEmployee.Projects)
            {
                sb.AppendLine(project);
            }


            return sb.ToString().TrimEnd();
        }

        //08. Problem
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeesCount = a.Employees.Count
                })
                .OrderByDescending(e => e.EmployeesCount)
                .ThenBy(t => t.TownName)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var addresse in addresses)
            {
                sb.AppendLine($"{addresse.AddressText}, {addresse.TownName} - {addresse.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();

        }

        //07. Problem
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees
                .Include(e => e.EmployeesProjects)
                .ThenInclude(p => p.Project)
                .Where(п => п.EmployeesProjects
                        .Any(p => p.Project.StartDate.Year >= 2001
                               && p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate,
                    }),
                })
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.ManagerFirstName} {employee.ManagerLastName}");

                foreach (var project in employee.Projects)
                {
                    string endDate = project.EndDate != null
                        ? $"{project.EndDate:M/d/yyyy h:mm:ss tt}"
                        : "not finished";

                    sb.AppendLine($"--{project.Name} - {project.StartDate:M/d/yyyy h:mm:ss tt} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //06. Problem
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var employeeNakov = context.Employees
                .FirstOrDefault(e => e.LastName == "Nakov");

            employeeNakov.AddressId = address.AddressId;
            context.SaveChanges();

            var empoyees = context.Employees
                .Select(e => new
                {
                    e.Address.AddressId,
                    e.Address.AddressText,
                })
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .ToList();

            var sb = new StringBuilder();
            foreach (var employeeAddress in empoyees)
            {
                sb.AppendLine(employeeAddress.AddressText);
            }

            return sb.ToString().TrimEnd();
        }


        //05. Problem
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var emplpoyee = context.Employees
                .Where(d => d.Department.Name.Equals("Research and Development"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name,
                    e.Salary,
                })
                .OrderBy(e => e.Salary)
                .ThenBy(e => e.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in emplpoyee)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Name} - ${employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //04. Problem
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var emplpoyees = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary,
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var emplpoyee in emplpoyees)
            {
                sb.AppendLine($"{emplpoyee.FirstName} - {emplpoyee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //03. Problem
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.EmployeeId)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            var result = sb.ToString().TrimEnd();
            return result;
        }
    }
}
