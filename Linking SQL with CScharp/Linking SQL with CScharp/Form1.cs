using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linking_SQL_with_CScharp
{
    public partial class Form1 : Form
    {
        SqlConnection connectionVar = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\w_ara\Downloads\ProductDB.mdf;Integrated Security=True;Connect Timeout=30");
        
        public Form1()
        {
            InitializeComponent();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            connectionVar.Open();

            SqlCommand commandVar = connectionVar.CreateCommand();
            commandVar.CommandType = CommandType.Text;
            commandVar.CommandText = "SELECT * FROM Product";
            
            commandVar.ExecuteNonQuery(); // Executes

            DataTable dataTableVar = new DataTable();
            SqlDataAdapter dataAdapterVar = new SqlDataAdapter(commandVar);
            dataAdapterVar.Fill(dataTableVar);

            foreach (DataRow dataRowVar in dataTableVar.Rows)
            {
                //labelFeedback.Text = dataRowVar["email"].ToString();
                MessageBox.Show(dataRowVar["Description"].ToString() + "  " +dataRowVar["Units_On_Hand"].ToString());
            }


            connectionVar.Close();

            MessageBox.Show("Success");
        }

        private void InsertButton_Click(object sender, EventArgs e)
        {
            connectionVar.Open();

            SqlCommand commandVar = connectionVar.CreateCommand();
            commandVar.CommandType = CommandType.Text;
            commandVar.CommandText = "INSERT INTO Product values('10-41','Sausage','1','9999')";

            commandVar.ExecuteNonQuery(); // Executes

            connectionVar.Close();

            MessageBox.Show("Insert Successfully");
        }
    }
}
