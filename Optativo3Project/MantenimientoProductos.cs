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
    public partial class MantenimientoProductos : Mantenimiento
    {
        public MantenimientoProductos()
        {
            InitializeComponent();
        }

        public override bool Guardar()
        {
            try
            {
                string cmd = string.Format("EXEC ActualizarProductos '{0}', '{1}', '{2}'", txtIdPro.Text.Trim(), txtNomPro.Text.Trim(), txtPrecio.Text.Trim());
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Administracion;Integrated Security=True");
            
                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd, conn);

                DataSet ds = new DataSet();

                adapt.Fill(ds);

                conn.Close();

                MessageBox.Show("Se ha guardado correctamente");
                return true;

            } catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error", ex.Message);
                return false;
            }
        }

        public override void Eliminar()
        {
            try
            {
                string cmd = string.Format("EXEC EliminarProductos '{0}'", txtIdPro.Text.Trim());
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Administracion;Integrated Security=True");

                conn.Open();
                SqlDataAdapter adapt = new SqlDataAdapter(cmd, conn);

                DataSet ds = new DataSet();

                adapt.Fill(ds);

                conn.Close();

                MessageBox.Show("Se ha eliminado correctamente");
            } catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error", ex.Message);
            }
        }
    }
}
