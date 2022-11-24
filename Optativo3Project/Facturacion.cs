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
    public partial class Facturacion : Procesos
    {
        public Facturacion()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Facturacion_Load(object sender, EventArgs e)
        {

            DataSet ds;
            string cmd = "SELECT * FROM Usuario WHERE Id_Usuario=" + VentanaLogin.Codigo;

            ds = DBConn(cmd);

            labelAtiende.Text = ds.Tables[0].Rows[0]["Nom_Usuario"].ToString().Trim();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim()) == false)
            {
                try
                {
                    DataSet ds;

                    string cmd = "SELECT * FROM Cliente WHERE Id_Cliente = " + txtCodigo.Text.Trim();
                    ds = DBConn(cmd);

                    txtCliente.Text = ds.Tables[0].Rows[0]["Nom_Cliente"].ToString().Trim();

                    txtCodigoProducto.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ha ocurrido un error" + ex.Message);
                }
            }
        }
    }
}
