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
    public partial class SIIForm : Form
    {
        public SIIForm()
        {
            InitializeComponent();
        }

        private void btnAQ_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = txtIDSII.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select ID,Exam,Year,Board,Result from StudentIdent where ID='" + id + "'";
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

        private void btnSR_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            string id = txtIDSII.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                string sqlQuery = "select * from StudentResult where ID='" + id + "'";
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
