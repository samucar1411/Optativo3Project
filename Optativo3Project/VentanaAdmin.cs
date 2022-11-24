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
    public partial class VentanaAdmin : FormBase
    {
        public VentanaAdmin()
        {
            InitializeComponent();
        }

        private void VentanaAdmin_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuario WHERE Id_Usuario= " + VentanaLogin.Codigo;

            DataSet ds = VentanaLogin.DBConn(cmd);

            lblNomAdmin.Text = ds.Tables[0].Rows[0]["Nom_Usuario"].ToString().Trim();
            lblUsAdmin.Text = ds.Tables[0].Rows[0]["Account"].ToString().Trim();
            lblCodigo.Text = ds.Tables[0].Rows[0]["Id_Usuario"].ToString().Trim();

            string url = ds.Tables[0].Rows[0]["Fotos"].ToString().Trim();

            pictureBox1.Image = Image.FromFile(url);
        }

        private void VentanaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContenedorPrincipal contP = new ContenedorPrincipal();

            this.Hide();

            contP.Show();
        }
    }
}
