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
    public partial class Procesos : FormBase
    {
        public Procesos()
        {
            InitializeComponent();
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
