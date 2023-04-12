using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqlConnection sqcon=null;
        public Form1()
        {
            InitializeComponent();
            sqcon = new SqlConnection(ConfigurationManager.ConnectionStrings["CS"].ConnectionString);
            sqcon.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd= new SqlCommand($"Insert into[Table](Name,Surname,Age,Profession) Values(@Name,@Surname,@Age,@Profession)",sqcon);
            cmd.Parameters.AddWithValue("Name", textBox1.Text);
            cmd.Parameters.AddWithValue("Surname", textBox2.Text);
            cmd.Parameters.AddWithValue("Age", int.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("Profession", textBox4.Text);
            cmd.ExecuteNonQuery();
        }
    }
}
