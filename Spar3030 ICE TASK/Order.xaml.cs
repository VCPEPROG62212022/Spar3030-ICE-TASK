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

namespace Spar3030_ICE_TASK
{
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>
    public partial class Order : Page
    {
        public Order()
        {
            InitializeComponent();
            DbConnect db = new DbConnect();

            foreach (var item in db.GetCat())
            {
                cmbFoodCat.Items.Add(item);
            }
            
        }

        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmbFoodCat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DbConnect db = new DbConnect();
            List<Product> p = db.GetProducts(cmbFoodCat.SelectedItem.ToString());
            foreach (var item in p)
            {
                lstOutput.Items.Add(item.ProductName + " R" + item.ProductPrice);
            }
        }
    }
}
