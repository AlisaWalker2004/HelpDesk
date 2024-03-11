using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelpDesk.MyFrame
{
    /// <summary>
    /// Логика взаимодействия для PageUser.xaml
    /// </summary>
    public partial class PageUser : Page
    {
        AndreevaHelpDeskEntities entities;
        public PageUser()
        {
            InitializeComponent();
            cbTypeOfIncident.ItemsSource = AndreevaHelpDeskEntities.GetContext().TypeOfIncidents.ToList();
        }

        private void btnAddIncident_Click(object sender, RoutedEventArgs e)
        {
            var idTypeOfIncident = entities.TypeOfIncidents.Where(x=>x.TypeOfIncident1 == cbTypeOfIncident.Text);
            //var a = new List<Incident>()
            //{
            //    new Incident() { Description = ComboVaccinations.Text + " "+ txtProblem.Text, id_Docors = idDoctorRandom.Next(1, kolDoctor), id_TypeOfService = idTypeOfService,
            //    id_PassportOfTheAnimal = idAnimalCombo, Date = dpDateZapis.SelectedDate.Value}
            // };
        }
    }
}
