using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDClientesEntregadores
{
    //Molde do arquivo pedido.json que o site baixa quando o cliente finaliza o pedido.
    //Os nomes das propriedades são IGUAIS aos do JSON, para o JsonConvert conseguir preencher.
    internal class PedidoJson
    {
        public string EmailUsuario { get; set; }
        public string DataPedido { get; set; }          // formato "AAAA-MM-DD HH:MM:SS"
        public List<ItemPedidoJson> Itens { get; set; } // lista com os produtos do pedido
        public decimal Total { get; set; }
    }
}
