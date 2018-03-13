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
    public partial class Form1 : Form
    {
        SIIForm siif = new SIIForm();
        StResForm strsf = new StResForm();
        Course c = new Course();
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = txtID.Text;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string exam = cmbExam.Text;
            string year = txtYear.Text;
            string board = cmbBoard.Text;
            string result = cmbResult.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "insert into StudentIdent(ID, Name, Phone, Address, Exam, Year, Board, Result) values('" + id + "','" + name + "','" + phone + "','" + address + "','" + exam + "','" + year + "','" + board + "','" + result + "')";
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
            string id = txtID.Text;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            string exam = cmbExam.Text;
            string year = txtYear.Text;
            string board = cmbBoard.Text;
            string result = cmbResult.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "update StudentIdent set Name='" + name + "', Phone='" + phone + "', Address='" + address + "', Year='" + year + "', Board='" + board + "', Result='" + result + "' where ID='" + id + "' and Exam='" + exam + "'";
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtYear.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = txtID.Text;
            string exam = cmbExam.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "delete from StudentIdent where ID='" + id + "' and Exam='" + exam + "'";
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
                string sqlQuery = "select * from StudentIdent";
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

        private void btnGetOne_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = txtID.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select * from StudentIdent where ID='" + id + "'";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";

                SqlDataAdapter dp = new SqlDataAdapter(sqlQuery, conObj);
                DataTable dt = new DataTable();
                dp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    txtName.Text = dt.Rows[0]["Name"].ToString();
                    txtPhone.Text = dt.Rows[0]["Phone"].ToString();
                    txtAddress.Text = dt.Rows[0]["Address"].ToString();
                    txtYear.Text = dt.Rows[0]["year"].ToString();
                    cmbExam.Text = dt.Rows[0]["Exam"].ToString();
                    cmbBoard.Text = dt.Rows[0]["Board"].ToString();
                    cmbResult.Text = dt.Rows[0]["Result"].ToString();
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

        private void btnSRE_Click(object sender, EventArgs e)
        {
            strsf.Show();
        }

        private void btnSII_Click(object sender, EventArgs e)
        {
            siif.Show();
        }

        private void btnAddCou_Click(object sender, EventArgs e)
        {
            c.Show();
        }
    }
}
