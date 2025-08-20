using MySql.Data.MySqlClient;
using System;
using System.Data.SqlClient;


namespace Projeto1
{
     class Conexao
    {
        MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=BDProjeto  ;user=root;pwd=12345678");
        public static string msg;
        public MySqlConnection ConnectarBD()
        {
            //tratamento de erros
            try 
            {
                con.Open(); //retorna a instancia

            }
            catch (Exception erro)
            {

                msg = "Ocorreu um erro ao se conectar" + erro.Message; 
            }
            return con;
        }

        public MySqlConnection DesConnectarBD()
        {
            try
            {
                con.Close();

            }
            catch (Exception erro)
            {

                msg = "Ocorreu um erro ao se desconectar" + erro.Message;
            }
            return con;
        }
    }
}
