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
    public partial class VentanaUser : FormBase
    {
        public VentanaUser()
        {
            InitializeComponent();
        }

        private void VentanaUser_Load(object sender, EventArgs e)
        {
            string cmd = "SELECT * FROM Usuario WHERE Id_Usuario= " + VentanaLogin.Codigo;

            DataSet ds = VentanaLogin.DBConn(cmd);

            lbl1.Text = ds.Tables[0].Rows[0]["Nom_Usuario"].ToString().Trim();
            lbl2.Text = ds.Tables[0].Rows[0]["Account"].ToString().Trim();
            lbl3.Text = ds.Tables[0].Rows[0]["Id_Usuario"].ToString().Trim();

            string url = ds.Tables[0].Rows[0]["Fotos"].ToString().Trim();

            pictureBox1.Image = Image.FromFile(url);
        }

        private void VentanaUser_FormClosed(object sender, FormClosedEventArgs e)
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
