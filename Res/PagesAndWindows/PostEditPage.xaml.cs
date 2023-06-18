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
    /// Логика взаимодействия для PostEditPage.xaml
    /// </summary>
    public partial class PostEditPage : Page
    {
        private Поставщики _currentPost = new Поставщики();
        public PostEditPage(Поставщики SelectedUser)
        {
            InitializeComponent();
            if (SelectedUser != null )
                _currentPost = SelectedUser;
            DataContext = _currentPost;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)    
        {
            if (_currentPost.Id == 0)
                WpfEntities.GetContext().Поставщики.Add(_currentPost);

            try
            {
                WpfEntities.GetContext().SaveChanges();
                AppFrame.Framer.Navigate(new PostPage());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
