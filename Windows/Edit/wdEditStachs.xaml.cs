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
        WarehouseOrder WarehouseOrder;
        public wdEditStachs(WarehouseOrder warehouseOrder)
        {
            this.WarehouseOrder = warehouseOrder;
            InitializeComponent();
            DataContext = WarehouseOrder;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            var api = new OrderApi();
            api.UpdateWarehouseState(WarehouseOrder.Id, WarehouseState.ON_WAREHOUSE);
            Close();
        }
    }
}
