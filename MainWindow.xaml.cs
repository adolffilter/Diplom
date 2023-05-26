using diplomaISPr22_33_PankovEA.data.api.user;
using diplomaISPr22_33_PankovEA.Windows;
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

namespace diplomaISPr22_33_PankovEA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void clEnterSystem(object sender, RoutedEventArgs e)
        {
            var api = new UserApi();
            var response = api.auth(new DiplomaOborotovIS.data.api.model.user.AuthBody
            {
                Login = tbLoginUser.Text,
                Password = pbPasswordUser.Password
            });
            if (response.Access_token != "")
            {
                Application.Current.MainWindow.Hide();
                new wdMain().ShowDialog();
                Application.Current.MainWindow.Close();
                tbLoginUser.Text = "";
                pbPasswordUser.Password = "";
            }
            else
                MessageBox.Show("Error");
        }
    }
}
