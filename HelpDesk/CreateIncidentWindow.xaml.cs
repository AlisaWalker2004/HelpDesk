using HelpDesk.Data;
using HelpDesk.Data.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace HelpDesk
{
    /// <summary>
    /// Логика взаимодействия для CreateIncidentWindow.xaml
    /// </summary>
    public partial class CreateIncidentWindow : Window
    {
        private readonly int _clientId;
        private readonly int _incidentTypeId;
        public CreateIncidentWindow(int userId, int incidentId)
        {
            InitializeComponent();
            _clientId = userId;
            _incidentTypeId = incidentId;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var context = new HelpDeskDbContext();

            var type = context.IncidentTypes.Single(i => i.Id == _incidentTypeId);

            var issueCut = tittleTb.Text.Substring(0, 8);

            var user = context.Clients.Single(c => c.Id == _clientId);

            var random = new Random();

            var employeeId = random.Next(1, 3);

            var time = type.SolutionTime ?? TimeSpan.FromMinutes(20);

            var priority = new TimeSpan(time.Ticks / user.Priority);

            var incident = new Incident()
            {
                ClientId = _clientId,
                EmployeeId = employeeId,
                IncidentTypeId = type.Id,
                Title = tittleTb.Text,
                Description = descriptionTb.Text,
                CalculatedSolutionTime = DateTime.Now.AddMinutes(priority.Minutes),
            };

            context.Incidents.Add(incident);

            context.SaveChanges();

            incident.Number = $"{type.Name}-{issueCut}-{incident.Id}";

            context.Incidents.AddOrUpdate(incident);

            context.SaveChanges();

            Close();
        }
    }
}
