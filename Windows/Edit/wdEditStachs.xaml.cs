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

namespace diplomaISPr22_33_PankovEA.Windows.Edit
{
    /// <summary>
    /// Interaction logic for wdEditStachs.xaml
    /// </summary>
    public partial class wdEditStachs : Window
    {
        List<WarehouseState> theList = Enum.GetValues(typeof(WarehouseState)).Cast<WarehouseState>().ToList();
        List<WarehouseState> roles;
        WarehouseOrder WarehouseOrder;
        public wdEditStachs(WarehouseOrder warehouseOrder)
        {
            this.WarehouseOrder = warehouseOrder;
            InitializeComponent();
            DataContext = WarehouseOrder;
            ;
            cbRole.ItemsSource = theList;

        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            if (cbRole.SelectedItem != null)
            {
                var api = new OrderApi();
                api.UpdateWarehouseState(WarehouseOrder.Id, theList[cbRole.SelectedIndex]);
                Close();

            }
            else
                cbRole.BorderBrush = Brushes.Red;
        }
    }
}
