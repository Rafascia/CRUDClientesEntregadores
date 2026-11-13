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
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        Cliente objCliente = new Cliente();

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            MostrarDadosClientes();   
        }
        private void MostrarDadosClientes()
        {
            dtgClientes.DataSource = objCliente.ListarClientes(); //Preenche o DataGridView com os dados retornados do select
        }
        private void LimparDados()
        {
            txtID.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //1º armazenar em variaveis os valores preenchidos no formulario de clientes
            string nomeCliente = txtNome.Text;
            string EmailCliente = txtEmail.Text;
            string SenhaCliente = txtSenha.Text;
            string telefoneCliente = txtTelefone.Text;
            string EnderecoCliente = txtEndereco.Text;

            //2º atribuir os valores armazenados em variaveis aos atributos da classe, usando metodo set 
            objCliente.SetNome(nomeCliente);
            objCliente.SetEmail(EmailCliente);
            objCliente.SetSenha(SenhaCliente);
            objCliente.SetTelefone(telefoneCliente);
            objCliente.SetEndereco(EnderecoCliente);

            //3º 

            objCliente.InserirCliente();
            MostrarDadosClientes();
            MessageBox.Show("Dados cadastrados com sucesso");

            LimparDados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //1º armazenar em variaveis os valores preenchidos no formulario de clientes
            int idCliente = int.Parse(txtID.Text);
            string nomeCliente = txtNome.Text;
            string EmailCliente = txtEmail.Text;
            string SenhaCliente = txtSenha.Text;
            string telefoneCliente = txtTelefone.Text;
            string EnderecoCliente = txtEndereco.Text;


            //2º atribuir os valores armazenados em variaveis aos atributos da classe, usando metodo set 
            objCliente.SetId(idCliente);
            objCliente.SetNome(nomeCliente);
            objCliente.SetEmail(EmailCliente);
            objCliente.SetSenha(SenhaCliente);
            objCliente.SetTelefone(telefoneCliente);
            objCliente.SetEndereco(EnderecoCliente);

            //3º 

            objCliente.AlterarCliente();
            MostrarDadosClientes();
            MessageBox.Show("Dados alterados com sucesso");

            LimparDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(txtID.Text);
            objCliente.SetId(idCliente);
            objCliente.ExcluirCliente();
            MessageBox.Show("Dados excluidos com sucesso");
            MostrarDadosClientes();
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

        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dtgClientes.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            txtNome.Text = dtgClientes.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
            txtEmail.Text = dtgClientes.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            txtSenha.Text = dtgClientes.Rows[e.RowIndex].Cells["PasswordHash"].Value.ToString();
            txtTelefone.Text = dtgClientes.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            txtEndereco.Text = dtgClientes.Rows[e.RowIndex].Cells["Address"].Value.ToString();
        }
    }
}
