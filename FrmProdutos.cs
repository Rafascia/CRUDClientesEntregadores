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
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        Produtos objProduto = new Produtos();

        private void MostrarDadosProdutos()
        {
            dtgProdutos.DataSource = objProduto.ListarProdutos(); //Preenche o DataGridView com os dados retornados do select
        }

        private void LimparDados()
        {
            txtID.Clear();
            txtNome.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            chkDisponivel.Checked = false;
        }

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            MostrarDadosProdutos();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //se nenhum produto foi selecionado na tabela, avisa e para aqui
            if (txtID.Text == "") { MessageBox.Show("Selecione um produto na tabela!"); return; }

            //1º armazenar em variaveis os valores preenchidos no formulario de produtos
            int idProduto = int.Parse(txtID.Text);
            string nomeProduto = txtNome.Text;
            string descricaoProduto = txtDescricao.Text;
            double precoProduto = double.Parse(txtPreco.Text);
            bool disponivelProduto = chkDisponivel.Checked;


            //2º atribuir os valores armazenados em variaveis aos atributos da classe, usando metodo set 
            objProduto.SetId(idProduto);
            objProduto.SetNome(nomeProduto);
            objProduto.SetDescricao(descricaoProduto);
            objProduto.SetPreco(precoProduto);
            objProduto.SetDisponivel(disponivelProduto);

            //3º 

            objProduto.AlterarProduto();
            MostrarDadosProdutos();
            MessageBox.Show("Dados alterados com sucesso");

            LimparDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //se nenhum produto foi selecionado na tabela, avisa e para aqui
            if (txtID.Text == "") { MessageBox.Show("Selecione um produto na tabela!"); return; }

            int idProduto = int.Parse(txtID.Text);
            objProduto.SetId(idProduto);
            objProduto.ExcluirProduto();
            MessageBox.Show("Dados excluidos com sucesso");
            MostrarDadosProdutos();
            LimparDados();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparDados();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtID.Text = dtgProdutos.Rows[e.RowIndex].Cells["ItemID"].Value.ToString();
            txtNome.Text = dtgProdutos.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            txtDescricao.Text = dtgProdutos.Rows[e.RowIndex].Cells["Description"].Value.ToString();
            txtPreco.Text = dtgProdutos.Rows[e.RowIndex].Cells["Price"].Value.ToString();
            chkDisponivel.Checked = Convert.ToBoolean(dtgProdutos.Rows[e.RowIndex].Cells["IsAvailable"].Value);
        }
    }
}
