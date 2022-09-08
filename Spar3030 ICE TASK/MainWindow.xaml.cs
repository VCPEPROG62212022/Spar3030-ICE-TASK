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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            DbConnect db = new DbConnect();
            db.AddUser(txtName_Copy1.Text, txtSurname_Copy1.Text, txtAddress.Text
                , txtEmail_Copy1.Text, txtPhone.Text, txtPassword_Copy1.Text);
        }
    }
}
