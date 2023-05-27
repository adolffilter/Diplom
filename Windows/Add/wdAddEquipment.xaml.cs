using diplomaISPr22_33_PankovEA.data.api.order;
using diplomaISPr22_33_PankovEA.data.api.order.model;
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

namespace diplomaISPr22_33_PankovEA.Windows.Add
{
    /// <summary>
    /// Interaction logic for wdAddEquipment.xaml
    /// </summary>
    public partial class wdAddEquipment : Window
    {
        List<Order> orders;
        public wdAddEquipment()
        {
            InitializeComponent();
            var api = new OrderApi();
            orders = api.GetAll(null, false);
            cbOrders.ItemsSource = orders;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            if (cbOrders.SelectedItem != null)
            {
                var api = new OrderApi();
                api.CreateOrderWarehouse(orders[cbOrders.SelectedIndex].Id, WarehouseState.ON_WAREHOUSE);
                Close();
            }
            else
                cbOrders.BorderBrush = Brushes.Red;
        }
    }
}
