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
    /// Логика взаимодействия для ProductEditPage.xaml
    /// </summary>
    public partial class ProductEditPage : Page
    {
        private Товар _currentTovar = new Товар();
        public ProductEditPage(Товар SelectedUser)
        {
            InitializeComponent();
            if (SelectedUser != null)
                _currentTovar = SelectedUser;
            DataContext = _currentTovar;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {

            if (_currentTovar.Id == 0)
            {
                WpfEntities.GetContext().Товар.Add(_currentTovar);
            }
                WpfEntities.GetContext().SaveChanges();
                AppFrame.Framer.Navigate(new ProductPage());
            
        }
    }
}
