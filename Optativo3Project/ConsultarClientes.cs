using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Optativo3Project
{
    public partial class ConsultarClientes : Consultas
    {
        public ConsultarClientes()
        {
            InitializeComponent();
        }

        private void ConsultarClientes_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = LlenarData("Cliente").Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) == false ){
                try
                {
                    DataSet ds;
                    string cmd = string.Format("SELECT * FROM Cliente WHERE Nom_Cliente Like ('%" + textBox1.Text.Trim() + "%')");
                    ds = DBConn(cmd);

                    dataGridView1.DataSource = ds.Tables[0];
                } catch(Exception ex)
                {
                    MessageBox.Show("Ocurrió un error... {0}", ex.Message);
                }
            }
        }
    }
}
