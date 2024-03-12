using HelpDesk.Data;
using HelpDesk.MyFrame;
using System.Linq;
using System.Windows;

namespace HelpDesk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly HelpDeskDbContext _context;
        public MainWindow()
        {
            InitializeComponent();

            _context = new HelpDeskDbContext();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text) || string.IsNullOrEmpty(tbPassword.Text))
                return;

            var user = _context.Clients.SingleOrDefault(u => u.Login == tbLogin.Text && u.Password == tbPassword.Text);

            if (user != null)
            {
                MainFrame.Navigate(new PageUser(user.Id));
                spAutho.Visibility = Visibility.Hidden;

                MessageBox.Show("Вы авторизовались!", "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            var employee = _context.Employees.SingleOrDefault(u => u.Login == tbLogin.Text && u.Password == tbPassword.Text);

            if (employee != null)
            {
                MainFrame.NavigationService.Navigate(new PageAdmin());
                spAutho.Visibility = Visibility.Hidden;

                MessageBox.Show("Вы авторизовались!", "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            MessageBox.Show("Неправильно введён логин или пароль!", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}