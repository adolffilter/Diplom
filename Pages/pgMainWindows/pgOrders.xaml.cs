using diplomaISPr22_33_PankovEA.data.api.order;
using diplomaISPr22_33_PankovEA.data.api.order.model;
using diplomaISPr22_33_PankovEA.Windows.Add;
using diplomaISPr22_33_PankovEA.Windows.Edit;
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
        IEnumerable<Order> list;
        public pgOrders()
        {
            InitializeComponent();
            update();
        }

        void update()
        {
            var api = new OrderApi();
            list = api.GetAll(null, false);
            dgvOrder.ItemsSource = list;
        }

        private void clDel(object sender, RoutedEventArgs e)
        {
            Order del = (sender as Button).DataContext as Order;
            var api = new OrderApi();
            api.Delete(del.Id);
            NavigationService.Navigate(new pgOrders());
        }

        private void clChang(object sender, RoutedEventArgs e)
        {
            Order edit = (sender as Button).DataContext as Order;
            new wdEditOrders(edit).ShowDialog();
            update();
        }

        private void clOpenAddOrder(object sender, RoutedEventArgs e)
        {
            new pgAddOrder().ShowDialog();
            update();
        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            list = list.Where(p => p.Title.Contains(tbSerch.Text.ToLower()));
            dgvOrder.ItemsSource = list;
        }
    }
}
