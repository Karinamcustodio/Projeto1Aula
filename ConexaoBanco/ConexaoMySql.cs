using MySql.Data.MySqlClient;

namespace RepresentanteMVC.ConexaoBanco
{
    public class ConexaoMySql
    {
        public static MySqlConnection conectar()
        {
            string stringConexao = "Server=localhost;Database=bd_prack;Uid=root;Pwd=admin";
            MySqlConnection connection = new MySqlConnection(stringConexao);
            return connection;
        }
    }
}
