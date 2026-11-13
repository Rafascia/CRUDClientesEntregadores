using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDClientesEntregadores
{
    internal class Administrador
    {
        //ATRIBUTOS
        private string email, senha;

        //SETS
        public void SetEmail(string email)
        {
            this.email = email;
        }

        public void SetSenha(string senha)
        {
            this.senha = senha;
        }

        //GETS
        public string GetEmail()
        {
            return this.email;
        }

        public string GetSenha()
        {
            return this.senha;
        }

        //INSTANCIANDO A CLASSE CONEXÃO
        Conexao db = new Conexao();

        //VALIDAR LOGIN
        public bool ValidarLogin()
        {
            string consulta = $"SELECT u.UserID FROM Users u " +
                              $"INNER JOIN Admins a ON u.UserID = a.UserID " +
                              $"WHERE u.Email = '{email}' AND u.PasswordHash = '{senha}'";

            DataTable resultado = db.ExecutarConsulta(consulta);
            return resultado.Rows.Count > 0;
        }
    }
}
