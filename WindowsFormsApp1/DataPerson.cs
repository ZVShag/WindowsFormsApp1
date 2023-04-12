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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class DataPerson : Form
    {
        private DataTable dt=new DataTable();
        SqlConnection sqcon=null;
        public DataPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd=new SqlCommand();
            cmd.CommandText = "Select * from Table";
            cmd.Connection=sqcon;
            sqcon.Open();
            var reader=cmd.ExecuteReader();
            int line = 0;
            do 
            {
                while (reader.Read())
                {
                    
                    DataRow dr = dt.NewRow();
                    for (int i=0; i < reader.FieldCount; i++)
                    {
                       dr[i] = reader[i];
                    }
                    dt.Rows.Add(dr);
                }
            }while (reader.NextResult());
            dataGridView1.DataSource=dt;
            sqcon.Close();
            reader.Close();
        }

        private void DataPerson_Load(object sender, EventArgs e)
        {
            SqlConnection sqcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
            dt.Columns.Add("Id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Surname");
            dt.Columns.Add("Age");
            dt.Columns.Add("Profession");
            
        }
    }
}
