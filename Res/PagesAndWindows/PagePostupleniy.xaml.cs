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
    /// Логика взаимодействия для PagePostupleniy.xaml
    /// </summary>
    public partial class PagePostupleniy : Page
    {
        public PagePostupleniy()
        {
            InitializeComponent();
            GridPost.ItemsSource = WpfEntities.GetContext().Поступления.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Framer.Navigate(new PostuplenyeEditPage((sender as Button).DataContext as Поступления));
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            var DeleteRow = GridPost.SelectedItems.Cast<Поступления>().ToList();
            WpfEntities.GetContext().Поступления.RemoveRange(DeleteRow);
            WpfEntities.GetContext().SaveChanges();
            AppFrame.Framer.Navigate(new PagePostupleniy());
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Framer.Navigate(new PostuplenyeEditPage((sender as Button).DataContext as Поступления));
        }
    }
}
