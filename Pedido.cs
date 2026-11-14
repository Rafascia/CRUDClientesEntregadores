using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDClientesEntregadores
{
    internal class Pedido
    {
        private int id, idEntregador;
        private string status;
        private double total;

        //SETS
        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetIdEntregador(int idEntregador)
        {
            this.idEntregador = idEntregador;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }

        public void SetTotal(double total)
        {
            this.total = total;
        }


        //GETS
        public int GetId()
        {
            return this.id;
        }

        public int GetIdEntregador()
        {
            return this.idEntregador;
        }

        public string GetStatus()
        {
            return this.status;
        }

        public double GetTotal()
        {
            return this.total;
        }

        Conexao db = new Conexao();

        //UPDATE
        public void AlterarPedido()
        {
            string entregador = "null";
            if (idEntregador != 0) entregador = idEntregador.ToString();

            string alterar = $"UPDATE Orders SET OrderStatus = '{status}', DeliveryPartnerID = {entregador}, " +
                             $"TotalAmount = {total.ToString().Replace(",", ".")} WHERE OrderID = {id};";
            db.ExecutarComando(alterar);
        }

        //DELETE 
        public void ExcluirPedido()
        {
            string excluir = $"DELETE FROM Reviews WHERE OrderID = {id}; " +
                             $"DELETE FROM OrderDetails WHERE OrderID = {id}; " +
                             $"DELETE FROM Orders WHERE OrderID = {id};";
            db.ExecutarComando(excluir);
        }

        public DataTable ListarPedidos()
        {
            string consulta = "SELECT o.OrderID, u.FullName AS Cliente, o.OrderDate, o.TotalAmount, o.OrderStatus, o.DeliveryPartnerID, e.FullName AS Entregador " +
                              "FROM Orders o INNER JOIN Users u ON o.UserID = u.UserID " +
                              "LEFT JOIN DeliveryPartners d ON o.DeliveryPartnerID = d.PartnerID " +
                              "LEFT JOIN Users e ON d.UserID = e.UserID " +
                              "ORDER BY o.OrderDate DESC";
            return db.ExecutarConsulta(consulta);
        }

        public DataTable ListarEntregadoresAtivos()
        {
            string consulta = "SELECT d.PartnerID, u.FullName FROM DeliveryPartners d INNER JOIN Users u ON d.UserID = u.UserID " +
                              "WHERE d.IsActive = true ORDER BY u.FullName";
            return db.ExecutarConsulta(consulta);
        }
    }
}
