using diplomaISPr22_33_PankovEA.data.api.user;
using diplomaISPr22_33_PankovEA.Pages.pgMainWindows;
using DiplomaOborotovIS.data.api.model.user;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace diplomaISPr22_33_PankovEA.Windows
{
    /// <summary>
    /// Interaction logic for wdMain.xaml
    /// </summary>
    public partial class wdMain : Window
    {
        public wdMain()
        {
            InitializeComponent();
            frMain.Navigate(new pgStachs());
            update();
        }

        void update()
        {
            var api = new UserApi();
            User user = api.getUser();
            DataContext = user;
            tbGetUser.Text = user.LastName + " " + user.FirstName;
        }

        SolidColorBrush color = (SolidColorBrush)(new BrushConverter().ConvertFrom("#E2F263"));

        private void clOpenPageStack(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new pgStachs());
            BtBorderTransparent();
            btOpenPageStack.BorderBrush = color;
        }

        private void clOpenPageOrder(object sender, RoutedEventArgs e)
        {
            frMain.Navigate(new pgOrders());
            BtBorderTransparent();
            btOpenPageOrder.BorderBrush = color;
        }

        void BtBorderTransparent()
        {
            btOpenPageStack.BorderBrush = Brushes.Transparent;
            btOpenPageOrder.BorderBrush = Brushes.Transparent;
        }

        void downloadImage()
        {
            OpenFileDialog openFile = new OpenFileDialog { Filter = "Jpeg files|*.jpg|All file|*.*" };

            if (openFile.ShowDialog() == true)
            {
                //User.Photo = File.ReadAllBytes(openFile.FileName);

                var api = new UserApi();
                var uri = new Uri(openFile.FileName);
                var bitmap = new BitmapImage(uri);
                api.updatePhoto(File.ReadAllBytes(openFile.FileName));
                ImageProfile.ImageSource = bitmap;


            }
        }

        private void mdDownloadImage(object sender, MouseButtonEventArgs e)
        {
            downloadImage();
        }

        private void clLeft(object sender, RoutedEventArgs e)
        {
                var api = new UserApi();
            api.SignOut();
            Close();
        }
    }
}
