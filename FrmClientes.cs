using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;         // para ler o arquivo
using Newtonsoft.Json;   // para converter o JSON

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
            if (e.RowIndex < 0) return;
            txtID.Text = dtgClientes.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            txtNome.Text = dtgClientes.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
            txtEmail.Text = dtgClientes.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            txtSenha.Text = dtgClientes.Rows[e.RowIndex].Cells["PasswordHash"].Value.ToString();
            txtTelefone.Text = dtgClientes.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            txtEndereco.Text = dtgClientes.Rows[e.RowIndex].Cells["Address"].Value.ToString();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            //1º abrir a janela para escolher o arquivo
            OpenFileDialog abrirArquivo = new OpenFileDialog();
            abrirArquivo.Filter = "Arquivos JSON (*.json)|*.json";
            if (abrirArquivo.ShowDialog() != DialogResult.OK) return; //cancelou

            try
            {
                //2º ler o arquivo e converter o JSON para a classe UsuarioJson
                string conteudo = File.ReadAllText(abrirArquivo.FileName);
                UsuarioJson usuario = JsonConvert.DeserializeObject<UsuarioJson>(conteudo);

                //3º conferir se é mesmo um cliente
                if (usuario.UserType != "NormalUser")
                {
                    MessageBox.Show("Este arquivo não é de um cliente. Importe na tela de Entregadores.");
                    return;
                }

                //4º passar os dados para o objeto, igual ao botão Cadastrar
                objCliente.SetNome(usuario.NomeCompleto);
                objCliente.SetEmail(usuario.EmailUsuario);
                objCliente.SetSenha(usuario.PasswordUsuario);
                objCliente.SetTelefone(usuario.UserTelNumber);
                objCliente.SetEndereco(usuario.UserAdress);

                //5º salvar no banco e atualizar a tela
                objCliente.InserirCliente();
                MostrarDadosClientes();
                MessageBox.Show("Cadastro importado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar o arquivo:\n" + ex.Message);
            }
        }
    }
}
