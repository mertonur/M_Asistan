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

namespace M_Asistan
{
    public partial class DizilerForm : Form
    {




        public DizilerForm()
        {
            InitializeComponent();
        }

        private void DizilerForm_Load(object sender, EventArgs e)
        {
            Form1.form1.Debug("Diziler Form Açıldı");
            Form1.dizilerForm = this;
            guncelle();
            SetDefaultTexts();
        }

        public void guncelle()
        {

            Conn.conn.connection.Open();
            Conn.conn.da = new SqlDataAdapter("Select * From diziler", Conn.conn.connection);
            DataTable tablo = new DataTable();
            Conn.conn.da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            Conn.conn.connection.Close();



         
        }
        public void SetDefaultTexts()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            
        }
            public void Debug(string text)
        {
            Form1.form1.Debug(text);
        }
    }
}
