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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        //instanciar a classe Administrador
        Administrador objAdmin = new Administrador();

        //botão do olho: alterna entre mostrar e esconder a senha
        private void btnMostrarSenha_Click(object sender, EventArgs e)
        {
            if (txtSenha.PasswordChar == '*')
            {
                txtSenha.PasswordChar = '\0'; //'\0' = nenhum caractere, ou seja, mostra o texto normal
            }
            else
            {
                txtSenha.PasswordChar = '*';  //volta a esconder com asteriscos
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //1º passar o que foi digitado para o objeto
            objAdmin.SetEmail(txtEmail.Text);
            objAdmin.SetSenha(txtSenha.Text);

            try
            {
                //2º perguntar ao banco se existe um administrador com esse e-mail e senha
                if (objAdmin.ValidarLogin())
                {
                    //3º login certo: esconde o login e abre a tela principal
                    this.Hide();
                    FrmPrincipal telaPrincipal = new FrmPrincipal();
                    telaPrincipal.ShowDialog(); //o código "espera" aqui até a tela principal ser fechada
                    this.Close();               //quando o principal fechar, fecha o login e o programa termina
                }
                else
                {
                    //login errado: avisa, limpa a senha e volta o cursor para ela
                    MessageBox.Show("E-mail ou senha inválidos!", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSenha.Clear();
                    txtSenha.Focus();
                }
            }
            catch (Exception ex)
            {
                //erro de conexão (ex.: WampServer desligado)
                MessageBox.Show("Não foi possível conectar ao banco de dados:\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
