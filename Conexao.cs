using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Pacote de funções de Conexao com My sql


namespace CRUDClientesEntregadores
{
    internal class Conexao
    {
        //criação do objeto de conexão

        MySqlConnection conn;

        private void Conectar()
        {
            string dadosConexao = "Persist security info = false; server = localhost; database = DarLustan; uid = root; pwd =;";

            try
            {
                conn = new MySqlConnection(dadosConexao); //Estabelece a conexão
                conn.Open();
            }
            catch (MySqlException ex) //objeto ex: armazenar os dados da exceção ocorrida
            {
                throw new Exception($"A Conexão NÃo foi estabelecida: \n {ex.Message}");
            }
        }


        //Método capaz de executar qualquer instrução: INSERT, UPDATE ou DELETE.


        public void ExecutarComando(string sql) //sql é uma string contendo inserte ou upadate ou delete
        {
            Conectar();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conn);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                throw new Exception($"ERRO ao tentar executar {sql}\n{ex.Message}");
            }
            finally
            {
                conn.Close(); //fecha a conexão havendo ou não algum erro (exceção)
            }
        }

        //select
        public DataTable ExecutarConsulta(string query)
        {
            Conectar();


            try
            {
                DataTable dt = new DataTable();
                MySqlDataAdapter dados = new MySqlDataAdapter(query, conn);
                dados.Fill(dt);
                return dt;
            }
            catch (MySqlException ex)
            {
                throw new Exception($"Consulta não realizada.\n{query}\n{ex.Message}");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}