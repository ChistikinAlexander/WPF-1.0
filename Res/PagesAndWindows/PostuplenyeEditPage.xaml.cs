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
    /// Логика взаимодействия для PostuplenyeEditPage.xaml
    /// </summary>
    public partial class PostuplenyeEditPage : Page
    {
        private Поступления _currentPost = new Поступления();
        public PostuplenyeEditPage(Поступления SelectedUser)
        {
            InitializeComponent();
            if (SelectedUser != null )
                _currentPost = SelectedUser;
            DataContext = _currentPost;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentPost.Id == 0)
                WpfEntities.GetContext().Поступления.Add(_currentPost);

            try
            {
                WpfEntities.GetContext().SaveChanges();
                AppFrame.Framer.Navigate(new PagePostupleniy());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
