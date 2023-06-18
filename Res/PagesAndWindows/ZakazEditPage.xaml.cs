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
    /// Логика взаимодействия для ZakazEditPage.xaml
    /// </summary>
    public partial class ZakazEditPage : Page
    { 
        private Заказ _currentZakaz = new Заказ();
        public ZakazEditPage(Заказ SelectedUser)
        {
            InitializeComponent();
            if (SelectedUser != null ) 
                _currentZakaz = SelectedUser;
            DataContext = _currentZakaz;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder error = new StringBuilder();
            if (error.Length > 0 ) 
            {
                MessageBox.Show( error.ToString() );
                return;
            }
            if (_currentZakaz.Id == 0)
                WpfEntities.GetContext().Заказ.Add(_currentZakaz);
            try
            {
                WpfEntities.GetContext().SaveChanges();
                AppFrame.Framer.Navigate(new ZakazPage());
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.Message.ToString() );
            }
        }
    }
}
