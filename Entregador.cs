using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // SO ACEITA QUE PRECISA E MANDA JUNTO

namespace CRUDClientesEntregadores
{
    internal class Entregador
    {
        private int id;
        private string nome, email, senha, telefone, endereco, tipoVeiculo, placa;
        private bool ativo;

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

        public void SetTipoVeiculo(string tipoVeiculo)
        {
            this.tipoVeiculo = tipoVeiculo;
        }

        public void SetPlaca(string placa)
        {
            this.placa = placa;
        }

        public void SetAtivo(bool ativo)
        {
            this.ativo = ativo;
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
        public string GetTipoVeiculo()
        {
            return this.tipoVeiculo;
        }
        public string GetPlaca()
        {
            return this.placa;
        }
        public bool GetAtivo()
        {
            return this.ativo;
        }

        Conexao db = new Conexao();

        //INSERT
        public void InserirEntregador()
        {
            string inserir = $"INSERT INTO Users VALUES(null, '{nome}', '{email}', '{senha}', '{telefone}', '{endereco}', 'DeliveryPartner', NOW()); " +
                             $"INSERT INTO DeliveryPartners VALUES(null, LAST_INSERT_ID(), '{tipoVeiculo}', '{placa}', null, {ativo});";
            db.ExecutarComando(inserir);
        }

        // UPDATE 
        public void AlterarEntregador()
        {
            string alterar = $"UPDATE Users SET FullName = '{nome}', Email = '{email}', PasswordHash = '{senha}', PhoneNumber = '{telefone}', Address = '{endereco}' WHERE UserID = {id}; " +
                             $"UPDATE DeliveryPartners SET VehicleType = '{tipoVeiculo}', VehicleNumber = '{placa}', IsActive = {ativo} WHERE UserID = {id};";
            db.ExecutarComando(alterar);
        }

        // DELETE
        public void ExcluirEntregador()
        {
            string excluir = $"DELETE FROM DeliveryPartners WHERE UserID = {id}; " +
                             $"DELETE FROM Users WHERE UserID = {id};";
            db.ExecutarComando(excluir);
        }

        //MOSTRAR OS ENTREGADORES
        public DataTable ListarEntregadores()
        {
            string consulta = "SELECT u.UserID, u.FullName, u.Email, u.PasswordHash, u.PhoneNumber, u.Address, " +
                              "d.VehicleType, d.VehicleNumber, d.Rating, d.IsActive " +
                              "FROM Users u INNER JOIN DeliveryPartners d ON u.UserID = d.UserID " +
                              "WHERE u.UserType = 'DeliveryPartner' ORDER BY u.FullName";
            return db.ExecutarConsulta(consulta); //select executando e retornando o resultado
        }
    }
}
