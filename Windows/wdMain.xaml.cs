using diplomaISPr22_33_PankovEA.Pages.pgMainWindows;
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

    }
}
