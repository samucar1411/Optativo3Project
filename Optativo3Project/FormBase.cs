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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseas salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                this.Close();
            }
        }

        public virtual void Eliminar()
        {

        }

        public virtual Boolean Guardar()
        {
            return false;
        }

        public virtual  void Nuevo()
        {

        }

        public virtual void Consultar()
        {

        }
    }
}
