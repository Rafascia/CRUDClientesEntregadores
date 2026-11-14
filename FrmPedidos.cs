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
    public partial class FrmPedidos : Form
    {
        public FrmPedidos()
        {
            InitializeComponent();
        }

        ImportadorPedido objImportador = new ImportadorPedido();
        Pedido objPedido = new Pedido();

        private void btnImportar_Click(object sender, EventArgs e)
        {
            //1º abrir a janela para escolher o arquivo
            OpenFileDialog abrirArquivo = new OpenFileDialog();
            abrirArquivo.Filter = "Arquivos JSON (*.json)|*.json";
            if (abrirArquivo.ShowDialog() != DialogResult.OK) return; //cancelou

            try
            {
                //2º ler o arquivo e converter o JSON para a classe PedidoJson
                string conteudo = File.ReadAllText(abrirArquivo.FileName);
                PedidoJson pedido = JsonConvert.DeserializeObject<PedidoJson>(conteudo);

                //3º conferir se é mesmo um pedido (arquivo de cadastro não tem itens)
                if (pedido.Itens == null || pedido.Itens.Count == 0)
                {
                    MessageBox.Show("Este arquivo não é de um pedido.");
                    return;
                }

                //4º gravar no banco e atualizar a tela
                objImportador.Importar(pedido);
                MostrarDadosPedido();
                MessageBox.Show("Pedido importado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao importar o arquivo:\n" + ex.Message);
            }
        }
        private void MostrarDadosPedido()
        {
            dtgPedidos.DataSource = objPedido.ListarPedidos(); 
            dtgPedidos.Columns["DeliveryPartnerID"].Visible = false; 
        }

        private void MostrarEntregadores()
        {
            cboEntregador.DataSource = objPedido.ListarEntregadoresAtivos(); 
            cboEntregador.DisplayMember = "FullName";  
            cboEntregador.ValueMember = "PartnerID";   
            cboEntregador.SelectedIndex = -1;         
        }

        private void LimparDados()
        {
            txtID.Clear();
            txtCliente.Clear();
            txtData.Clear();
            txtTotal.Clear();
            cboStatus.SelectedIndex = -1;
            cboEntregador.SelectedIndex = -1;
        }

        private void FrmPedidos_Load(object sender, EventArgs e)
        {
            MostrarDadosPedido();
            MostrarEntregadores();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            //se nenhum pedido foi selecionado na tabela, avisa e para aqui
            if (txtID.Text == "") { MessageBox.Show("Selecione um pedido na tabela!"); return; }

            //1º armazenar em variaveis os valores preenchidos no formulario de pedidos
            int idPedido = int.Parse(txtID.Text);
            double totalPedido = double.Parse(txtTotal.Text);
            string statusPedido = cboStatus.Text;
            int idEntregador = Convert.ToInt32(cboEntregador.SelectedValue); //se nao tiver nenhum escolhido, fica 0


            //2º atribuir os valores armazenados em variaveis aos atributos da classe, usando metodo set
            objPedido.SetId(idPedido);
            objPedido.SetTotal(totalPedido);
            objPedido.SetStatus(statusPedido);
            objPedido.SetIdEntregador(idEntregador);

            //3º

            objPedido.AlterarPedido();
            MostrarDadosPedido();
            MessageBox.Show("Dados alterados com sucesso");

            LimparDados();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "") { MessageBox.Show("Selecione um pedido na tabela!"); return; }

            int idPedido = int.Parse(txtID.Text);
            objPedido.SetId(idPedido);
            objPedido.ExcluirPedido();
            MessageBox.Show("Dados excluidos com sucesso");
            MostrarDadosPedido();
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

        private void dtgPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            txtID.Text = dtgPedidos.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();
            txtCliente.Text = dtgPedidos.Rows[e.RowIndex].Cells["Cliente"].Value.ToString();
            txtData.Text = dtgPedidos.Rows[e.RowIndex].Cells["OrderDate"].Value.ToString();
            txtTotal.Text = dtgPedidos.Rows[e.RowIndex].Cells["TotalAmount"].Value.ToString();
            cboStatus.Text = dtgPedidos.Rows[e.RowIndex].Cells["OrderStatus"].Value.ToString();

            if (dtgPedidos.Rows[e.RowIndex].Cells["DeliveryPartnerID"].Value == DBNull.Value)
            {
                cboEntregador.SelectedIndex = -1;
            }
            else
            {
                cboEntregador.SelectedValue = Convert.ToInt32(dtgPedidos.Rows[e.RowIndex].Cells["DeliveryPartnerID"].Value);
            }
        }
    }
}
