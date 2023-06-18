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

namespace WPF_1._0.Res.PagesAndWindows
{
    /// <summary>
    /// Логика взаимодействия для ZakazPage.xaml
    /// </summary>
    public partial class ZakazPage : Page
    {
        public ZakazPage()
        {
            InitializeComponent();
            DataGridZakaz.ItemsSource = WpfEntities.GetContext().Заказ.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Framer.Navigate(new ZakazEditPage((sender as Button).DataContext as Заказ));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var DeleteRow = DataGridZakaz.SelectedItems.Cast<Заказ>().ToList();
            WpfEntities.GetContext().Заказ.RemoveRange(DeleteRow);
            WpfEntities.GetContext().SaveChanges();
            AppFrame.Framer.Navigate(new ZakazPage());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Framer.Navigate(new ZakazEditPage((sender as Button).DataContext as Заказ));
        }
    }
}
