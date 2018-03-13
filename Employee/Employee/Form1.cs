using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Employee
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conObj = new SqlConnection();
            string id = textBox1.Text;
            string name = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox4.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "insert into EmployeeMaster(EmpID, EmpName, EmpPhone, EmpAddress) values('" + id + "','" + name + "','" + phone + "','" + address + "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = textBox1.Text;
            string name = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox4.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "update EmployeeMaster set EmpName='" + name + "', EmpPhone='" + phone + "', EmpAddress='" + address + "' where EmpID='" + id + "'";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";
                SqlCommand cmd = new SqlCommand(sqlQuery, conObj);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data updated");
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

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = textBox1.Text;
            string name = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox4.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select * from EmployeeMaster";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";

                SqlDataAdapter dp = new SqlDataAdapter(sqlQuery, conObj);
                DataTable dt = new DataTable();
                dp.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    DataView dv = new DataView();
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

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = textBox1.Text;
            string name = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox4.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "delete from EmployeeMaster where EmpID='" + id + "'";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";
                SqlCommand cmd = new SqlCommand(sqlQuery, conObj);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data deleted");
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

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = textBox1.Text;
            string name = textBox2.Text;
            string phone = textBox3.Text;
            string address = textBox4.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select * from EmployeeMaster where EmpID='"+textBox1.Text+"'";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";

                SqlDataAdapter dp = new SqlDataAdapter(sqlQuery, conObj);
                DataTable dt = new DataTable();
                dp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    textBox2.Text = dt.Rows[0]["EmpName"].ToString();
                    textBox3.Text = dt.Rows[0]["EmpPhone"].ToString();
                    textBox4.Text = dt.Rows[0]["EmpAddress"].ToString();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear(); 
        }
    }
}
