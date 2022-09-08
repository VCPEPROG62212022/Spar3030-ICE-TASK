using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Spar3030_ICE_TASK
{
    public interface Connections
    {
        public void AddUser(String Name, String Surname, String Address,
            String Email, String PhoneNumber, String PasswordNULL);
        public Boolean CheckLogin(String Email,String Password);

        public String[] GetCat();//Gets Different types of products
        public Product[] GetProducts(String Cat);

        public Boolean AddOrder(int[] Item, Boolean[] Packed);
        public String[] GetOrderNo();
        public String[] GetOrderStatus();


    }
}
