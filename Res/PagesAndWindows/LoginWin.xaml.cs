using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_1._0.Res.DataBase;
using static WPF_1._0.MainWindow;

namespace WPF_1._0.Res.PagesAndWindows
{
    /// <summary>
    /// Логика взаимодействия для LoginWin.xaml
    /// </summary>
    public partial class LoginWin : Window
    {
        public User CurrentUser { get; private set; }
        public LoginWin()
        {
            InitializeComponent();
            AppConnect.bdModel = new WpfEntities();


        }
     

        private void CloseBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { this.DragMove(); }
        }

        private void LogoGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left) { this.DragMove(); }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TbPas.Password.Length > 0)
            {
                WaterMark.Visibility = Visibility.Collapsed;
            }
            else
            {
                WaterMark.Visibility = Visibility.Visible;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userObj = AppConnect.bdModel.Аккаунты.FirstOrDefault(x => x.Login == TbLog.Text && x.Password == TbPas.Password);
            if (userObj == null)
            {
                TbLog.BorderBrush = Brushes.Red;
                TbPas.BorderBrush = Brushes.Red;
                errlab.Opacity = 100;
                TbLog.Text = ("");
                TbPas.Password = ("");
            }
            else
            {
                switch (userObj.Role)
                {

                    case 2:

                        break;
                    case 1:
                        string username = userObj.Name;
                        string password = userObj.Password;
                        string login = userObj.Login;
                        CurrentUser = new User(username, password, login);
                        MainWindow userWindow = new MainWindow(CurrentUser);
                        userWindow.Show();
                        this.Close();
                        
                        break;
                    default:
                        MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                        break;

                }
            }

        }
    }
}
