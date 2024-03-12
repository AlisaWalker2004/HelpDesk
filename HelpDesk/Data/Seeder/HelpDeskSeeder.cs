using HelpDesk.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDesk.Data.Seeder
{
    public class HelpDeskSeeder
    {
        private HelpDeskDbContext _context;
        public HelpDeskSeeder(HelpDeskDbContext context)
        {
            _context = context;
        }

        public async void SeedAll()
        {
            await SeedIncidentTypes();

            await SeedDepartments();

            await SeedClients();

            await SeedEmployees();

            await SeedIncidents();
        }

        public async Task SeedEmployees()
        {
            if (_context.Employees.Any())
                return;

            var employees = new List<Employee>()
            {
                new Employee()
                {
                    Type = "Сотрудник аппаратного обеспечения",
                    Password = "password",
                    Login = "login"
                },
                new Employee()
                {
                    Type = "Сотрудник программного обеспечения",
                    Password = "login",
                    Login = "password"
                },
                new Employee()
                {
                    Type = "Системный администратор",
                    Login = "hack",
                    Password = "hack",
                },
            };

            _context.Employees.AddRange(employees);

            await _context.SaveChangesAsync();
        }
        public async Task SeedIncidentTypes()
        {
            if (_context.IncidentTypes.Any())
                return;

            var types = new List<IncidentType>()
            {
                new IncidentType()
                {
                    Name = "Аппаратные",
                    SolutionTime = TimeSpan.FromMinutes(45)
                },
                new IncidentType()
                {
                    Name = "Программные",
                    SolutionTime = TimeSpan.FromMinutes(15)

                },
                new IncidentType()
                {
                    Name = "Доступа",
                    SolutionTime = TimeSpan.FromMinutes(30)
                },
                new IncidentType()
                {
                    Name = "Переферии",
                    SolutionTime = TimeSpan.FromMinutes(20)
                },
                new IncidentType()
                {
                    Name = "Другое",
                    SolutionTime = null
                }
            };

            _context.IncidentTypes.AddRange(types);

            await _context.SaveChangesAsync();
        }
        public async Task SeedDepartments()
        {
            if (_context.Departments.Any())
                return;

            var departments = new List<Department>()
            {
                new Department()
                {
                    Name = "IT центр"
                },
                new Department()
                {
                    Name = "Компания"
                },
                new Department()
                {
                    Name = "Учебная часть"
                }
            };

            _context.Departments.AddRange(departments);

            await _context.SaveChangesAsync();
        }
        public async Task SeedClients()
        {
            if (_context.Clients.Any())
                return;

            var clients = new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    FirstName = "Яна",
                    LastName = "Цветкова",
                    Patronimyc = "Максимовна",
                    Post = "Директор",
                    DepartmentId = 2,
                    Priority = 8,
                    Login = "YaYa",
                    Password = "YaYa"
                },
                new Client()
                {
                    Id = 2,
                    FirstName = "Клим",
                    LastName = "Пономарёва",
                    Patronimyc = "Александровна",
                    Post = "Бухгалтер",
                    DepartmentId = 3,
                    Priority = 4,
                    Login = "KliKl",
                    Password= "KliKl"
                },
                new Client()
                {
                    Id = 3,
                    FirstName = "Давид",
                    LastName = "Константинов",
                    Patronimyc = "Алексеевич",
                    Post = "Программист",
                    DepartmentId = 1,
                    Priority = 1,
                    Login = "DavDav",
                    Password = "DavDav"
                },
            };

            _context.Clients.AddRange(clients);

            await _context.SaveChangesAsync();
        }
        public async Task SeedIncidents()
        {
            if (_context.Incidents.Any())
                return;

            var incidents = new List<Incident>()
            {
                new Incident()
                {
                    ClientId = 1,
                    EmployeeId = 1,
                    Number = "Программные-Виндовс-1",
                    Title = "Не запускается виндовс",
                    IncidentTypeId = 1,
                    Solution = "Позовите на помощь",
                    IsSolved = true,
                },
                new Incident()
                {
                    ClientId = 2,
                    EmployeeId = 2,
                    Number = "Программные-linux-2",
                    Title = "Не запускается linux",
                    IncidentTypeId = 1,
                    Solution = "Позовите на помощь",
                    IsSolved = true,
                },
            };

            _context.Incidents.AddRange(incidents);

            await _context.SaveChangesAsync();
        }
    }
}