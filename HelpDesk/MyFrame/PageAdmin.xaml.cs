using HelpDesk.Data;
using HelpDesk.Data.Entities;
using System.Linq;
using System.Windows.Controls;

namespace HelpDesk.MyFrame
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageAdmin : Page
    {
        private readonly HelpDeskDbContext _context;
        public PageAdmin()
        {
            InitializeComponent();
            _context = new HelpDeskDbContext();

            cbTypeOfIncident.ItemsSource = _context.IncidentTypes.ToList();

            incidentsLb.ItemsSource = _context.Incidents.ToList();
        }

        private void tbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            RefreshIncidents();
        }

        private void cbTypeOfIncident_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshIncidents();
        }

        private void RefreshIncidents()
        {
            var typeId = ((IncidentType)cbTypeOfIncident.SelectedItem).Id;
            var searchText = tbDescription.Text;

            incidentsLb.ItemsSource = _context.Incidents.Where(i => i.Type.Id == typeId && i.Title.Contains(searchText))
                .ToList();
        }

        private void btnCloseIncident_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var incidentId = ((Incident)(incidentsLb.SelectedItem)).Id;

            var window = new CloseIncidentWindow(incidentId);

            window.ShowDialog();
        }
    }
}
