using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace StudentManagement
{
    public partial class Course : Form
    {
        public Course()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string cid = txtCC.Text;
            string cname = txtCN.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "insert into Course(CourseCode, CourseName) values('" + cid + "','" + cname + "')";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";
                SqlCommand cmd = new SqlCommand(sqlQuery, conObj);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conObj.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string cid = txtCC.Text;
            string cname = txtCN.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "update Course set CourseName='" + cname + "' where CourseCode='" + cid + "'";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";
                SqlCommand cmd = new SqlCommand(sqlQuery, conObj);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conObj.Close();
            }
        }

        private void btnGetOne_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string cid = txtCC.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select * from Course where CourseCode='" + cid + "'";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";

                SqlDataAdapter dp = new SqlDataAdapter(sqlQuery, conObj);
                DataTable dt = new DataTable();
                dp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtCN.Text = dt.Rows[0]["CourseName"].ToString();
                    
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conObj.Close();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string cid = txtCC.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "delete from Course where CourseCode='" + cid + "'";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";


                SqlCommand cmd = new SqlCommand(sqlQuery, conObj);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Deleted");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conObj.Close();
            }
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select * from Course";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";

                SqlDataAdapter dp = new SqlDataAdapter(sqlQuery, conObj);
                DataTable dt = new DataTable();
                dp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    Data_View dv = new Data_View();
                    dv.showtab(dt);
                    dv.Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conObj.Close();
            }
        }
    }
}
