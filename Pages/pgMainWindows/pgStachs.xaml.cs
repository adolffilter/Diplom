using diplomaISPr22_33_PankovEA.data.api.order;
using diplomaISPr22_33_PankovEA.data.api.order.model;
using diplomaISPr22_33_PankovEA.data.api.provider;
using diplomaISPr22_33_PankovEA.data.api.provider.model;
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
    /// Interaction logic for pgStachs.xaml
    /// </summary>
    public partial class pgStachs : Page
    {
        IEnumerable<WarehouseOrder> list;
        public pgStachs()
        {
            InitializeComponent();
            update();
        }
        void update()
        {
            var api = new OrderApi();
            list = api.GetWarehouseAll();
            dgvOrder.ItemsSource = list;
        }

        private void clOpenAddOrder(object sender, RoutedEventArgs e)
        {
            new wdAddEquipment().ShowDialog();
            update();
        }

        private void clDel(object sender, RoutedEventArgs e)
        {
            WarehouseOrder orderDel = (sender as Button).DataContext as WarehouseOrder;
            var api = new OrderApi();
            api.Delete(orderDel.Id);
            NavigationService.Navigate(new pgStachs());
        }

        private void clChang(object sender, RoutedEventArgs e)
        {
            WarehouseOrder orderEdit = (sender as Button).DataContext as WarehouseOrder;
            var api = new OrderApi();
            new wdEditStachs(orderEdit).ShowDialog();
            NavigationService.Navigate(new pgStachs());

        }

        private void tcSerch(object sender, TextChangedEventArgs e)
        {
            list = list.Where(p => p.Title.Contains(tbSerch.Text.ToLower()));
            dgvOrder.ItemsSource = list;
        }
    }
}
