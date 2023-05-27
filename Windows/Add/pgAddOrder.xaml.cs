using diplomaISPr22_33_PankovEA.data.api.order;
using diplomaISPr22_33_PankovEA.data.api.provider;
using diplomaISPr22_33_PankovEA.data.api.provider.model;
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
    /// Interaction logic for pgAddOrder.xaml
    /// </summary>
    public partial class pgAddOrder : Window
    {
        List<Provider> providers;
        public pgAddOrder()
        {
            InitializeComponent();
            var api = new ProviderApi();
            providers = api.GetAll();
            cbProvider.ItemsSource = providers;

        }

        private void clSave(object sender, RoutedEventArgs e)
        {
            if (cbProvider.ItemsSource != null)
            {

                var api = new OrderApi();
                api.Add(new data.api.order.model.CreateOrder
                {
                    Description = tbDescription.Text,
                    Title = tbTitle.Text,
                    ProviderId = providers[cbProvider.SelectedIndex].Id
                });
                Close();
            }
            else
                cbProvider.BorderBrush = Brushes.Red;
        }
    }
}
