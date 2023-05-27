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
    /// Interaction logic for wdEditOrders.xaml
    /// </summary>
    public partial class wdEditOrders : Window
    {
        Order Order;
        public wdEditOrders(Order order)
        {
            this.Order = order;
            InitializeComponent();
            DataContext = Order;
        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            var api = new OrderApi();
            api.Update(Order.Id, new CreateOrder
            {
                Description = tbDescription.Text,
                ProviderId = Order.Provider.Id,
                Title = tbTitle.Text,
            });
        }
    }
}
