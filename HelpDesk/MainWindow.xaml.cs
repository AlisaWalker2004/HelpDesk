using HelpDesk.MyFrame;
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

namespace HelpDesk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AndreevaHelpDeskEntities entities;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != String.Empty && tbPassword.Text != String.Empty)
            {
                var user = AndreevaHelpDeskEntities.GetContext().Employees.Where(u => u.Login == tbLogin.Text
                && u.Password == tbPassword.Text).FirstOrDefault();
                spAutho.Visibility = Visibility.Hidden;


                if (user == null)
                {
                    MessageBox.Show("Неправильно введён логин или пароль!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (user.Login == "AA1")
                {
                    MessageBox.Show("Вы авторизовались!", "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);
                    (App.Current as App).idUser = user.idSotr.ToString();
                    MainFrame.NavigationService.Navigate(new Uri("PageAdmin.xaml", UriKind.Relative));
                    return;
                }
                else
                {
                    MessageBox.Show("Вы авторизовались!", "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    MainFrame.Navigate(new PageUser());
                    return;
                }
            }
        }
    }
}
