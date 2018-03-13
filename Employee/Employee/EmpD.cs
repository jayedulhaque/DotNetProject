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

namespace Employee
{
    public partial class EmpD : Form
    {
        public EmpD()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            dgvDetails.Rows.Add(cmbMonth.Text,txtSalary.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conObj = new SqlConnection();
            SqlTransaction txn=null;
            string id = txtId.Text;
            string name = txtName.Text;
            string phone = txtPhone.Text;
            string address = txtAddress.Text;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
                conObj.ConnectionString = connectionString;
                conObj.Open();
                txn = conObj.BeginTransaction();
                string sqlQuery = "insert into EmployeeMaster(EmpID, EmpName, EmpPhone, EmpAddress) values('" + id + "','" + name + "','" + phone + "','" + address + "')";
                //string sqlIns = "INSERT INTO EmployeeMaster (EmpID,EmpName,EmpPhone,EmpAddress) VALUES (@id,@name, @phone, @address)";
                SqlCommand cmd = new SqlCommand(sqlQuery, conObj,txn);
                cmd.ExecuteNonQuery();
                //MessageBox.Show("Data Saved");
                string detailsQry = string.Empty;
                foreach (DataGridViewRow gr in dgvDetails.Rows)
                {
                    string MonthName = gr.Cells[0].Value.ToString();
                    decimal salary = Convert.ToDecimal(gr.Cells[1].Value);

                    detailsQry = "insert into MonthlySalary values('" + txtId.Text + "','" + MonthName + "'," + salary + ")";
                    cmd = new SqlCommand(detailsQry,conObj,txn);
                    cmd.ExecuteNonQuery();
                }
                txn.Commit();
                MessageBox.Show("Data Saved");
            }
            catch (Exception ex)
            {
                txn.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conObj.Close();
            }
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
