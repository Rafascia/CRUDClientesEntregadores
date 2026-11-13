using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // SO ACEITA QUE PRECISA E MANDA JUNTO

namespace CRUDClientesEntregadores
{
    internal class Cliente
    {
        //BOTA OS ATRIBUTOS
        private int id;
        private string nome, email, senha, telefone, endereco;

        //SETS
        public void SetId(int id)
        {
            this.id = id;
        }

        public void SetNome(string nome)
        {
            this.nome = nome;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }
        public void SetSenha(string senha)
        {
            this.senha = senha;
        }
        public void SetTelefone(string telefone)
        {
            this.telefone = telefone;
        }
        public void SetEndereco(string endereco)
        {
            this.endereco = endereco;
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
        public string GetEmail()
        {
            return this.email;
        }
        public string GetSenha()
        {
            return this.senha;
        }
        public string GetTelefone()
        {
            return this.telefone;
        }
        public string GetEndereco()
        {
            return this.endereco;
        }

        //INSTANCIANDO A CLASSE CONEXÃO 
        Conexao db = new Conexao();

        //INSERT
        public void InserirCliente()
        {
            string inserir = $"INSERT INTO Users VALUES(null, '{nome}', '{email}', '{senha}', '{telefone}', '{endereco}' , 'NormalUser' , NOW());";
            db.ExecutarComando(inserir);
        }

        // UPDATE 
        public void AlterarCliente()
        {
            string alterar = $"UPDATE Users SET FullName = '{nome}', Email = '{email}', PasswordHash = '{senha}', PhoneNumber = '{telefone}', Address = '{endereco}' WHERE UserID = {id};";
            db.ExecutarComando(alterar);
        }

        // DELETE
        public void ExcluirCliente()
        {
            string excluir = $"DELETE FROM Users WHERE UserID = '{id}'";
            db.ExecutarComando(excluir);
        }

        //MOSTRAR OS CLIENTES
        public DataTable ListarClientes()
        {
            string consulta = $"SELECT * FROM Users WHERE UserType = 'NormalUser' ORDER BY FullName";
            return db.ExecutarConsulta(consulta); //select executando e retornando o resultado
        }
    }
}
