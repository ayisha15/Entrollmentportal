using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace entrollmentportal
{
    /// <summary>
    /// Interaction logic for AdminDashboard.xaml
    /// </summary>
    public partial class AdminDashboard : Window
    {
        public AdminDashboard()
        {
            InitializeComponent();
            string conn = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Entrollment;Data Source=AYISHAPC\\SQLEXPRESS\r\n;encrypt=false";
            SqlConnection sqlconn = new SqlConnection(conn);
            sqlconn.Open();
            string sqlquery = "select * from studentdetails";
            SqlCommand ocmd1 = new SqlCommand(sqlquery, sqlconn);
            SqlDataAdapter oda = new SqlDataAdapter(ocmd1);
            DataSet odata = new DataSet();
            oda.Fill(odata);
            lststudent.ItemsSource = odata.Tables[0].DefaultView;
            sqlconn.Close();


        }
    }
}
