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

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes TelaClientes = new FrmClientes();
            TelaClientes.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //SO TA AK PQ EU CLIQUEI ERRADO
        }

        private void btnEntregadores_Click(object sender, EventArgs e)
        {
            FrmEntregadores TelaEntregadores = new FrmEntregadores();
            TelaEntregadores.ShowDialog();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            FrmProdutos TelaProdutos = new FrmProdutos();
            TelaProdutos.ShowDialog();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            FrmPedidos TelaPedidos = new FrmPedidos();
            TelaPedidos.ShowDialog();
        }
    }
}
