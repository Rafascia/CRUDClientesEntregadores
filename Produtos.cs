using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDClientesEntregadores
{
    internal class Produtos
    {
        private int id;
        private string nome, descricao;
        private double preco;
        private bool disponivel;

        //SETS
        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }

        public void SetDescricao(string descricao)
        {
            this.descricao = descricao;
        }

        public void SetPreco(double preco)
        {
            this.preco = preco;
        }

        public void SetDisponivel(bool disponivel)
        {
            this.disponivel = disponivel;
        }


        //GETS 
        public int GetId()
        {
            return this.id;
        }

        public string GetNome()
        {
            return this.nome;
        }

        public string GetDescricao()
        {
            return this.descricao;
        }

        public double GetPreco()
        {
            return this.preco;
        }

        public bool GetDisponivel()
        {
            return this.disponivel;
        }

        Conexao db = new Conexao();

        //UPDATE
        public void AlterarProduto()
        {
            string alterar = $"UPDATE MenuItems SET Name = '{nome}', Description = '{descricao}', " + $"Price = {preco.ToString().Replace(",", ".")}, IsAvailable = {disponivel} WHERE ItemID = {id};";
            db.ExecutarComando(alterar);
        }

        //DELETE
        public void ExcluirProduto()
        {
            string excluir = $"DELETE FROM MenuItems WHERE ItemID = {id};";
            db.ExecutarComando(excluir);
        }

        //MOSTRAR OS PRODUTOS
        public DataTable ListarProdutos()
        {
            string consulta = "SELECT * FROM MenuItems ORDER BY ItemID";
            return db.ExecutarConsulta(consulta);
        }
    }
}
