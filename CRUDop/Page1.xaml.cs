using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

namespace CRUDop
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
     CRUDopEntities _DB = new CRUDopEntities();
        public Page1()
        {
            InitializeComponent();
            CustomersDG.ItemsSource = _DB.Customer.ToList();
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        public void Blanck()
        {
            fstn.Text = lstn.Text = city.Text= address.Text = null;

        }
        private void Insertbut_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = new Customer();
            customer.First_Name = fstn.Text;
            var rec = _DB.Customer.FirstOrDefault(x => x.First_Name == fstn.Text);
            if (rec != null) 
            { MessageBox.Show("Change Your Name"); return; }
            customer.Last_Name = lstn.Text;
            customer.City = city.Text;
            customer.Cust_Address = address.Text;
            if(fstn.Text != null)
            _DB.Customer.Add(customer);
            _DB.SaveChanges();
            CustomersDG.ItemsSource = _DB.Customer.ToList();
            Blanck();
        }
        private void Deletebut_Click(object sender, RoutedEventArgs e)
        {
            //Customer customer = new Customer();
            //if (customer.First_Name != null)
            //{
            //    customer = _DB.Customer.FirstOrDefault(x => x.First_Name == fstn.Text);
            //    _DB.Customer.Remove(customer);
            //    _DB.SaveChanges();
            //    CustomersDG.ItemsSource = _DB.Customer.ToList();
            //    fstn.Text = null;
            //}
            //else { MessageBox.Show("There is no Customer With This Name"); }
            if (CustomersDG.SelectedItem is Customer customer)
            {
                _DB.Customer.Remove(customer);
                _DB.SaveChanges();
            }
            else { MessageBox.Show("Please select a row"); }
            //var rec =_DB.Customer.Remove(_DB.Customer.FirstOrDefault((x => x.First_Name == fstn.Text)));
            CustomersDG.ItemsSource = _DB.Customer.ToList();
        }
        private void Updatebut_Click(object sender, RoutedEventArgs e)
        {
            if (CustomersDG.SelectedItem is Customer customer)
            {  
                if (customer != null)
                {
                    customer.First_Name = fstn.Text;
                    customer.Last_Name = lstn.Text;
                    customer.City = city.Text;
                    customer.Cust_Address = address.Text;
                    _DB.Customer.AddOrUpdate(customer);
                    _DB.SaveChanges();
                    CustomersDG.ItemsSource = _DB.Customer.ToList();
                }
                else
                {
                    MessageBox.Show("please Register");
                }
            }
            //Customer customer = new Customer();
            //customer = _DB.Customer.FirstOrDefault(x => x.First_Name == fstn.Text);
            //if (customer != null)
            //{
            //    customer.First_Name = fstn.Text;
            //    customer.Last_Name = lstn.Text;
            //    customer.City = city.Text;
            //    customer.Cust_Address = address.Text;
            //    _DB.Customer.AddOrUpdate(customer);
            //    _DB.SaveChanges();
            //    CustomersDG.ItemsSource = _DB.Customer.ToList();
            //}
            //else
            //{
            //    MessageBox.Show("please Register");
            //}
        }
    }
}
