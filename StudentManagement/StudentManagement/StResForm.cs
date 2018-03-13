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
    public partial class StResForm : Form
    {
        public StResForm()
        {
            InitializeComponent();
        }
        public void Csub()
        {
            SqlConnection conObj = new SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery2 = "select CourseCode from Course";
                SqlDataAdapter dp2 = new SqlDataAdapter(sqlQuery2, conObj);
                DataTable dt2 = new DataTable();
                dp2.Fill(dt2);
                if (dt2.Rows.Count > 0)
                {
                    cmbSub.DataSource = dt2;
                    cmbSub.DisplayMember = "CourseCode"; // which display in the combo
                    cmbSub.ValueMember = "CourseCode";
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

        private void StResForm_Load(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select distinct ID from StudentIdent";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";

                SqlDataAdapter dp = new SqlDataAdapter(sqlQuery, conObj);
                DataTable dt = new DataTable();
                dp.Fill(dt);
               
                //cmbID.DataSource = dt;
                if (dt.Rows.Count > 0)
                {
                    cmbID.DataSource = dt;
                    cmbID.DisplayMember = "ID"; // which display in the combo
                    cmbID.ValueMember = "ID";
                    // which contain the value, both can be same but depends on you
                }
                
                // cmbID.SelectedValue = txtID.Text;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conObj.Close();
            }
            Csub();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = cmbID.Text;
            string year = cmbYear.Text;
            string sub = cmbSub.Text;
            string sem = cmbSemister.Text;
            string grade = cmbGrade.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "insert into StudentResult(ID,Year,Sub,Semister,Grade) values('" + id + "','" + year + "','" + sub + "','" + sem + "','" + grade + "')";
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
            string id = cmbID.Text;
            string year = cmbYear.Text;
            string sub = cmbSub.Text;
            string sem = cmbSemister.Text;
            string grade = cmbGrade.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "update StudentResult set Year='"+ year+"',Semister='"+sem+"',Grade='"+grade+"' where ID='" + id + "' and Sub='" + sub + "'";
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

        private void btnDel_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = cmbID.Text;
            string sub = cmbSub.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "delete from StudentResult where ID='" + id + "' and Sub='" + sub + "'";
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

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select * from StudentResult";
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
