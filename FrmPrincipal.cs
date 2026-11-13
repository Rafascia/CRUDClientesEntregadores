using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDClientesEntregadores
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmClientes TelaClientes = new FrmClientes();
            TelaClientes.ShowDialog();
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SO TA AK PQ EU CLIQUEI ERRADO
        }

        private void eNTREGADORESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEntregadores TelaEntregadores = new FrmEntregadores();
            TelaEntregadores.ShowDialog();
        }
    }
}
