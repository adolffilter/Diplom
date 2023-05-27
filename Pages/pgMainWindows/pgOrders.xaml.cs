using diplomaISPr22_33_PankovEA.data.api.order;
using diplomaISPr22_33_PankovEA.data.api.order.model;
using diplomaISPr22_33_PankovEA.Windows.Add;
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

namespace diplomaISPr22_33_PankovEA.Pages.pgMainWindows
{
    /// <summary>
    /// Interaction logic for pgOrders.xaml
    /// </summary>
    public partial class pgOrders : Page
    {
        public pgOrders()
        {
            InitializeComponent();
            update();
        }

        void update()
        {
            var api = new OrderApi();
            IEnumerable<Order> list = api.GetAll();
            dgvOrder.ItemsSource = list;
        }

        private void clDel(object sender, RoutedEventArgs e)
        {

        }

        private void clChang(object sender, RoutedEventArgs e)
        {

        }

        private void clOpenAddOrder(object sender, RoutedEventArgs e)
        {
            new pgAddOrder().ShowDialog();
            update();
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {

        }
    }
}
