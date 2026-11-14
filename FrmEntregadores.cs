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
    public partial class FrmEntregadores : Form
    {
        public FrmEntregadores()
        {
            InitializeComponent();
        }

        Entregador objEntregador = new Entregador();

        private void FrmEntregadores_Load(object sender, EventArgs e)
        {
            MostrarDadosEntregadores();
        }
        private void MostrarDadosEntregadores()
        {
            dtgEntregadores.DataSource = objEntregador.ListarEntregadores(); //Preenche o DataGridView com os dados retornados do select
        }
        private void LimparDados()
        {
            txtID.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtTelefone.Clear();
            txtEndereco.Clear();
            txtPlaca.Clear();
            txtTipoVeiculo.Clear();
            chkAtivo.Checked = false;
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //1º armazenar em variaveis os valores preenchidos no formulario de entregadores
            string nomeEntregador = txtNome.Text;
            string EmailEntregador = txtEmail.Text;
            string SenhaEntregador = txtSenha.Text;
            string telefoneEntregador = txtTelefone.Text;
            string EnderecoEntregador = txtEndereco.Text;
            string PlacaEntregador = txtPlaca.Text;
            string TipoVeiculoEntregador = txtTipoVeiculo.Text;
            bool AtivoEntregador = chkAtivo.Checked;

            //2º atribuir os valores armazenados em variaveis aos atributos da classe, usando metodo set 
            objEntregador.SetNome(nomeEntregador);
            objEntregador.SetEmail(EmailEntregador);
            objEntregador.SetSenha(SenhaEntregador);
            objEntregador.SetTelefone(telefoneEntregador);
            objEntregador.SetEndereco(EnderecoEntregador);
            objEntregador.SetPlaca(PlacaEntregador);
            objEntregador.SetTipoVeiculo(TipoVeiculoEntregador);
            objEntregador.SetAtivo(AtivoEntregador);
            objEntregador.SetAvaliacao(5); //todo entregador novo começa com nota 5, igual ao site

            //3º

            objEntregador.InserirEntregador();
            MostrarDadosEntregadores();
            MessageBox.Show("Dados cadastrados com sucesso");

            LimparDados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //1º armazenar em variaveis os valores preenchidos no formulario de entregadores
            int idEntregador = int.Parse(txtID.Text);
            string nomeEntregador = txtNome.Text;
            string EmailEntregador = txtEmail.Text;
            string SenhaEntregador = txtSenha.Text;
            string telefoneEntregador = txtTelefone.Text;
            string EnderecoEntregador = txtEndereco.Text;
            string PlacaEntregador = txtPlaca.Text;
            string TipoVeiculoEntregador = txtTipoVeiculo.Text;
            bool AtivoEntregador = chkAtivo.Checked;

            //2º atribuir os valores armazenados em variaveis aos atributos da classe, usando metodo set 
            objEntregador.SetId(idEntregador);
            objEntregador.SetNome(nomeEntregador);
            objEntregador.SetEmail(EmailEntregador);
            objEntregador.SetSenha(SenhaEntregador);
            objEntregador.SetTelefone(telefoneEntregador);
            objEntregador.SetEndereco(EnderecoEntregador);
            objEntregador.SetPlaca(PlacaEntregador);
            objEntregador.SetTipoVeiculo(TipoVeiculoEntregador);
            objEntregador.SetAtivo(AtivoEntregador);

            //3º 

            objEntregador.AlterarEntregador();
            MostrarDadosEntregadores();
            MessageBox.Show("Dados alterados com sucesso");

            LimparDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int idEntregador = int.Parse(txtID.Text);
            objEntregador.SetId(idEntregador);
            objEntregador.ExcluirEntregador();
            MessageBox.Show("Dados excluidos com sucesso");
            MostrarDadosEntregadores();
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

        private void dtgEntregadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtID.Text = dtgEntregadores.Rows[e.RowIndex].Cells["UserID"].Value.ToString();
            txtNome.Text = dtgEntregadores.Rows[e.RowIndex].Cells["FullName"].Value.ToString();
            txtEmail.Text = dtgEntregadores.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            txtSenha.Text = dtgEntregadores.Rows[e.RowIndex].Cells["PasswordHash"].Value.ToString();
            txtTelefone.Text = dtgEntregadores.Rows[e.RowIndex].Cells["PhoneNumber"].Value.ToString();
            txtEndereco.Text = dtgEntregadores.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            txtPlaca.Text = dtgEntregadores.Rows[e.RowIndex].Cells["VehicleNumber"].Value.ToString();
            txtTipoVeiculo.Text = dtgEntregadores.Rows[e.RowIndex].Cells["VehicleType"].Value.ToString();
            chkAtivo.Checked = Convert.ToBoolean(dtgEntregadores.Rows[e.RowIndex].Cells["IsActive"].Value);
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

                //3º conferir se é mesmo um entregador
                if (usuario.UserType != "DeliveryPartner")
                {
                    MessageBox.Show("Este arquivo não é de um entregador. Importe na tela de Clientes.");
                    return;
                }

                //4º passar os dados para o objeto, igual ao botão Cadastrar
                objEntregador.SetNome(usuario.NomeCompleto);
                objEntregador.SetEmail(usuario.EmailUsuario);
                objEntregador.SetSenha(usuario.PasswordUsuario);
                objEntregador.SetTelefone(usuario.UserTelNumber);
                objEntregador.SetEndereco(usuario.UserAdress);
                objEntregador.SetTipoVeiculo(usuario.VehicleType);
                objEntregador.SetPlaca(usuario.VehicleNumber);
                objEntregador.SetAvaliacao(usuario.Rating);
                objEntregador.SetAtivo(true); //todo entregador novo começa ativo

                //5º salvar no banco e atualizar a tela
                objEntregador.InserirEntregador();
                MostrarDadosEntregadores();
                MessageBox.Show("Cadastro importado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar o arquivo:\n" + ex.Message);
            }
        }
    }
}
