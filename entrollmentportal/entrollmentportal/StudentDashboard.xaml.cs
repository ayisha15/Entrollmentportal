using System.Windows;
using System.Windows.Controls;
using entrollmentportal.BL;
using entrollmentportal.model;
using Microsoft.Data.SqlClient;


namespace entrollmentportal
{
    /// <summary>
    /// Interaction logic for StudentDashboard.xaml
    /// </summary>
    public partial class StudentDashboard : Window

    {
        object userid;

        public StudentDashboard(string password)
        {
            InitializeComponent();
            Studentdash ostudentdash = new Studentdash();
            Student ostud=ostudentdash.getstudent(password);
            txtname.Text = ostud.Username;
            txtemail.Text = ostud.Email;  
            txtpassword.Password =ostud.Password;
            userid = ostud.Id;
            
            Student ostudent = new Student();
            ostudent.Password = password;
            object values = ostudentdash.Disablecheckin(ostudent);
            int count = (int)values;
            if (count > 0)
            {
                btncheckin.IsEnabled = false;
            }
            ////checkin disable
            //SqlConnection sqlconn1 = new SqlConnection(sql);
            //sqlconn1.Open();
            //string sqlquery = "select count(*) from studentcheckin WHERE password=@password and Checkin=@checkin";
            //SqlCommand ocmd1 = new SqlCommand(sqlquery,sqlconn1);
            //ocmd1.Parameters.AddWithValue("@password", password);
            //ocmd1.Parameters.AddWithValue("@checkin",DateTime.Now.Date);

        }

        private void btncheckin_Click(object sender, RoutedEventArgs e)
        {
            int Notes =rdbnotesyes.IsChecked==true ? 1 : 0;
            int Demo=rdbdemoyes.IsChecked==true ? 1 : 0;
            int project=rdbdone.IsChecked==true ? 1 : 0;

            DateTime formattedDate = Convert.ToDateTime(dpselectdate.SelectedDate);


            ComboBoxItem cmb = (ComboBoxItem)cmbcourses.SelectedItem;
            string sql = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Entrollment;Data Source=AYISHAPC\\SQLEXPRESS\r\n;encrypt=false";
            SqlConnection sqlconn = new SqlConnection(sql);
            sqlconn.Open();
            string query="insert into studentactivity values(@cmb,@Date,@Notes,@Demo,@Project,@dpselectdate,@userid)";

            SqlCommand ocmd = new SqlCommand(query, sqlconn);
            ocmd.Parameters.AddWithValue("@cmb", cmb.Content);
            ocmd.Parameters.AddWithValue("@Date", DateTime.Now.Date);
            ocmd.Parameters.AddWithValue("@Notes",Notes);
            ocmd.Parameters.AddWithValue("@Demo",Demo);
            ocmd.Parameters.AddWithValue("@Project",project);
            ocmd.Parameters.AddWithValue("@dpselectdate", formattedDate);
            ocmd.Parameters.AddWithValue("@userid",userid);
            ocmd.ExecuteNonQuery();
            MessageBox.Show("Update Successfully");
            sqlconn.Close();
          

        }

        private void btnsavechanges_Click(object sender, RoutedEventArgs e)
        {
            Studentdash studentdash = new Studentdash();
            Student ostud = new Student();
            ostud.Id = Convert.ToInt32(userid);
            ostud.Username=txtname.Text;
            ostud.Email = txtemail.Text;
            ostud.Password = txtpassword.Password;
            studentdash.updatestudent(ostud);
            MessageBox.Show("Update successfullly");

        }
    }
}
