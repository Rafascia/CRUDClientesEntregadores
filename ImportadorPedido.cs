using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDClientesEntregadores
{
    //Classe que grava no banco um pedido lido do pedido.json
    internal class ImportadorPedido
    {
        Conexao db = new Conexao();

        //Procura o cliente pelo e-mail. Devolve o UserID, ou 0 se não achar.
        public int BuscarCliente(string email)
        {
            string consulta = $"SELECT UserID FROM Users WHERE Email = '{email}'";
            DataTable resultado = db.ExecutarConsulta(consulta);

            if (resultado.Rows.Count == 0) return 0;
            return Convert.ToInt32(resultado.Rows[0]["UserID"]);
        }

        //Confere se esse pedido já foi importado antes (mesmo cliente e mesma data/hora)
        public bool PedidoJaExiste(int idCliente, string data)
        {
            string consulta = $"SELECT OrderID FROM Orders WHERE UserID = {idCliente} AND OrderDate = '{data}'";
            DataTable resultado = db.ExecutarConsulta(consulta);
            return resultado.Rows.Count > 0;
        }

        //Grava o pedido na tabela Orders e os itens na tabela OrderDetails
        public void Importar(PedidoJson pedido)
        {
            //1º descobrir quem é o cliente pelo e-mail
            int idCliente = BuscarCliente(pedido.EmailUsuario);
            if (idCliente == 0)
            {
                throw new Exception($"Nenhum cliente com o e-mail {pedido.EmailUsuario}. Importe o cadastro dele primeiro na tela de Clientes.");
            }

            //2º não deixar importar o mesmo arquivo duas vezes
            if (PedidoJaExiste(idCliente, pedido.DataPedido))
            {
                throw new Exception("Este pedido já foi importado.");
            }

            //3º gravar o pedido (sem entregador ainda, status inicial Recebido)
            string inserirPedido = $"INSERT INTO Orders VALUES(null, {idCliente}, null, {pedido.Total.ToString().Replace(",", ".")}, 'Recebido', '{pedido.DataPedido}');";
            db.ExecutarComando(inserirPedido);

            //4º pegar o ID do pedido que acabou de ser criado (o maior OrderID)
            DataTable resultado = db.ExecutarConsulta("SELECT MAX(OrderID) AS OrderID FROM Orders");
            int idPedido = Convert.ToInt32(resultado.Rows[0]["OrderID"]);

            //5º gravar cada item do pedido, calculando o subtotal (quantidade x preço)
            foreach (ItemPedidoJson item in pedido.Itens)
            {
                decimal subtotal = item.Quantidade * item.PrecoUnitario;
                string inserirItem = $"INSERT INTO OrderDetails VALUES(null, {idPedido}, {item.ItemID}, {item.Quantidade}, {subtotal.ToString().Replace(",", ".")});";
                db.ExecutarComando(inserirItem);
            }
        }
    }
}
