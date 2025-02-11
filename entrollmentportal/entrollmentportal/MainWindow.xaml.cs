using entrollmentportal.BL;
using entrollmentportal.model;
using System.Windows;
using System.Windows.Controls;

namespace entrollmentportal
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


        private void btnreg_Click(object sender, RoutedEventArgs e)
        {
           
            int role;
            ComboBoxItem cmb = (ComboBoxItem)cmbrole.SelectedItem;
            if (cmb.Content.ToString() == "Staff")
            {
                role = 1;            
            }
            else
            {
                role = 2;
            }
            Reg reg = new();
            Student ostudent=new Student();
            ostudent.Username=txtusername.Text;
            ostudent.Password=pwspassword.Password;
            ostudent.Email=txtemail.Text;
            ostudent.mobilenumber = (int)Convert.ToInt64(txtmobilenumber.Text);
            ostudent.DOB =txtdob.Text;
            ostudent.address= txtaddress.Text;
            ostudent.role=role;
            int i = reg.Register(ostudent);
            if(i>=1)
            {
                MessageBox.Show("Register Successfully");
            }
            else
            {
                MessageBox.Show("Register Failed");
            }
            
            
            //string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Entrollment;Data Source=AYISHAPC\\SQLEXPRESS\r\n;encrypt=false";
            //SqlConnection sqlconn = new SqlConnection(sql);
            //sqlconn.Open();
            ////connection extablishment
            ////sql command

            //string query = $"insert into Register values('{txtusername.Text}','{pwspassword.Password}','{txtemail.Text}','{txtdob.Text}','{txtmobilenumber.Text}','{txtaddress.Text}',{role})";
            
            //SqlCommand ocmd = new SqlCommand(query, sqlconn);
            //int i= ocmd.ExecuteNonQuery();
            //MessageBox.Show("Register successfullly");
            //sqlconn.Close();
            //excute non query
        }

        private void btnlogin_Click(object sender, RoutedEventArgs e)
        {

            int role = 1;
            ComboBoxItem cmb = (ComboBoxItem)cmbloginrole.SelectedItem;
            if (cmb.Content.ToString() == "Staff")
            {
                role = 1;
            }
            else
            {
                role = 2;
            }
            //string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Entrollment;Data Source=AYISHAPC\\SQLEXPRESS\r\n;encrypt=false";
            //SqlConnection sqlconn = new SqlConnection(sql);
            //sqlconn.Open();
            //string query = $"select count(*) from register where password='{pwpassword.Password}'and role={role}";
            //SqlCommand ocmd = new SqlCommand(query, sqlconn);
            //int i = (int)ocmd.ExecuteScalar();
            Reg reg=new();
            Student ostudent =new Student();
            ostudent.Password=pwpassword.Password;
            ostudent.role = role;
            int i=(int)reg.logincheck(ostudent);
            {
                if (i >= 1)
                {
                    if (role == 1)
                    {
                        AdminDashboard oadmin = new AdminDashboard();
                        oadmin.Show();
                        this.Close();
                    }
                    else
                    {
                        StudentDashboard oadmin= new StudentDashboard(pwpassword.Password);
                        oadmin.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("login failed");
                }
            }


        }
    }
}