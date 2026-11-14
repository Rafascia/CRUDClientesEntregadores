using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDClientesEntregadores
{
    //Molde de CADA item dentro da lista "Itens" do pedido.json
    internal class ItemPedidoJson
    {
        public int ItemID { get; set; }            // mesmo ID da tabela MenuItems (1 a 12)
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
