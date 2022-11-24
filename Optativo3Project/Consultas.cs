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
    public partial class Consultas : FormBase
    {
        public Consultas()
        {
            InitializeComponent();
        }


        public DataSet LlenarData(string tabla)
        {
            DataSet DS;

            string cmd = string.Format("SELECT * FROM " + tabla);
            DS = DBConn(cmd);

            return DS;


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

        private void button1_Click(object sender, EventArgs e)
        {
            if( dataGridView1.Rows.Count == 0 )
            {
                return;
            } else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }

}
