
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WPF_1._0.Res.DataBase;

namespace WPF_1._0.Res.PagesAndWindows
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        public ProductPage()
        {
            InitializeComponent();
            DataGridProduct.ItemsSource = WpfEntities.GetContext().Товар.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Framer.Navigate(new ProductEditPage((sender as Button).DataContext as Товар));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var DeleteRow = DataGridProduct.SelectedItems.Cast<Товар>().ToList();
            WpfEntities.GetContext().Товар.RemoveRange(DeleteRow);
            WpfEntities.GetContext().SaveChanges();
            AppFrame.Framer.Navigate(new ProductPage());
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Framer.Navigate(new ProductEditPage((sender as Button).DataContext as Товар));
        }
    }
}
