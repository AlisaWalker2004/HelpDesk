using HelpDesk.Data;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Windows;

namespace HelpDesk
{
    /// <summary>
    /// Логика взаимодействия для CloseIncidentWindow.xaml
    /// </summary>
    public partial class CloseIncidentWindow : Window
    {
        private readonly int _incidentId;
        private readonly HelpDeskDbContext _context;

        public CloseIncidentWindow(int incidentId)
        {
            InitializeComponent();

            _incidentId = incidentId;
            _context = new HelpDeskDbContext();

            incidentNumber.Text = _context.Incidents.Single(i => i.Id == _incidentId).Number;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var incident = _context.Incidents.Single(i => i.Id == _incidentId);

            incident.Solution = solutionTb.Text;
            incident.ActualSolutionTime = System.DateTime.Now;
            incident.IsSolved = true;

            _context.Incidents.AddOrUpdate(incident);

            _context.SaveChanges();

            Close();
        }
    }
}
