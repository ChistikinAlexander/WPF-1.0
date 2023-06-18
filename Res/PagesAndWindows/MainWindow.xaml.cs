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
using WPF_1._0.Res.DataBase;
using WPF_1._0.Res.PagesAndWindows;

namespace WPF_1._0
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public User CurrentUser { get; private set; }
        public MainWindow(User currentUser)
        {
            InitializeComponent();
            AppConnect.bdModel = new WpfEntities();
            AppFrame.Framer = MainFrame;
            MainFrame.Navigate(new StartPage());
            CurrentUser = currentUser;
            DataContext = this;
        }

       
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton== MouseButtonState.Pressed) { DragMove();}
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void GoToReg_Click(object sender, RoutedEventArgs e)
        {
            new LoginWin().Show();
            this.Close();
        }

        private void PostBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PagePostupleniy());
        }

        private void ProdBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProductPage());
        }

        private void CorpBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new PostPage());
        }

        private void ZakazBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ZakazPage());
        }

        private void HumanInfo_Click(object sender, RoutedEventArgs e)
        {
           
            MainFrame.Navigate(new AccountPage(CurrentUser));
        }
    }
}
