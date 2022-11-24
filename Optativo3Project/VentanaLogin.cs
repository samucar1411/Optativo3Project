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

namespace Optativo3Project
{
    public partial class VentanaLogin : Form
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }
        public static string Codigo = "";
        private void entrarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string cmd = string.Format("SELECT * FROM Usuario WHERE Account='{0}' AND Password ='{1}'", txtAccount.Text.Trim(), txtPass.Text.Trim());
                DataSet ds = DBConn(cmd);

                string cuenta = ds.Tables[0].Rows[0]["Account"].ToString().Trim();
                string pass = ds.Tables[0].Rows[0]["Password"].ToString().Trim();
                Codigo = ds.Tables[0].Rows[0]["Id_Usuario"].ToString().Trim();

                if (cuenta == txtAccount.Text.Trim() && pass == txtPass.Text.Trim())
                {
                    if (Convert.ToBoolean(ds.Tables[0].Rows[0]["Status_Admin"]) == true)
                    {
                        VentanaAdmin ventAd = new VentanaAdmin();
                        this.Hide();
                        ventAd.Show();
                    }
                    else
                    {
                        VentanaUser ventUser = new VentanaUser();
                        this.Hide();
                        ventUser.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Error en el login");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public static DataSet DBConn(string cmd)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Administracion;Integrated Security=True");
            conn.Open();
            SqlDataAdapter adapt = new SqlDataAdapter(cmd, conn);

            DataSet ds = new DataSet();

            adapt.Fill(ds);

            conn.Close();
            return ds;

        }
    }
}
