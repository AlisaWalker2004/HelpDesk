using HelpDesk.Data;
using HelpDesk.Data.Entities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace HelpDesk.MyFrame
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        private readonly int _userId;
        private readonly HelpDeskDbContext _context;
        public PageUser(int userId)
        {
            InitializeComponent();
            _userId = userId;

            _context = new HelpDeskDbContext();

            cbTypeOfIncident.ItemsSource = _context.IncidentTypes.ToList();

            incidentsLb.ItemsSource = _context.Incidents.ToList();
        }

        private void btnAddIncident_Click(object sender, RoutedEventArgs e)
        {
            var window = new CreateIncidentWindow(_userId, cbTypeOfIncident.SelectedIndex + 1);

            window.ShowDialog();
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
    }
}
