using MySql.Data.MySqlClient;
using RepresentanteMVC.ConexaoBanco;
using RepresentanteMVC.Interfaces;
using RepresentanteMVC.Models;
using System.Data;

namespace RepresentanteMVC.Dados
{
    public class DadosLoja : ICrud<Loja>
    {
        public bool Adicionar(Loja loja)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand lojas = con.CreateCommand();

            try
            {
                con.Open();
                lojas.CommandText = "INSERT INTO Loja(razaoSocial, cnpj, inscEstadual, fone, email, CEP, rua, numero, bairro, cidade, status) VALUES(@razaoSocial, @cnpj, @inscEstadual, @fone, @email, @cep, @rua, @numero, @bairro, @cidade, @status)";
                lojas.Parameters.Add("razaoSocial", MySqlDbType.VarString).Value = loja.RazaoSocial;
                lojas.Parameters.Add("cnpj", MySqlDbType.VarString).Value = loja.Cnpj;
                lojas.Parameters.Add("inscEstadual", MySqlDbType.VarString).Value = loja.InscEstadual;
                lojas.Parameters.Add("fone", MySqlDbType.VarString).Value = loja.Fone;
                lojas.Parameters.Add("email", MySqlDbType.VarString).Value = loja.Email;
                lojas.Parameters.Add("CEP", MySqlDbType.VarString).Value = loja.Cep;
                lojas.Parameters.Add("rua", MySqlDbType.VarString).Value = loja.Rua;
                lojas.Parameters.Add("numero", MySqlDbType.VarString).Value = loja.Numero;
                lojas.Parameters.Add("bairro", MySqlDbType.VarString).Value = loja.Bairro;
                lojas.Parameters.Add("cidade", MySqlDbType.VarString).Value = loja.Cidade;
                lojas.Parameters.Add("status", MySqlDbType.Bit).Value = loja.Status;
                lojas.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        public bool Editar(Loja loja)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand lojas = con.CreateCommand();

            try
            {
                con.Open();
                lojas.CommandText = "UPDATE Loja SET razaoSocial = @razaoSocial, cnpj = @cnpj, inscEstadual = @inscEstadual, fone = @fone, email = @email, CEP = @cep, rua = @rua, numero = @numero, bairro = @bairro, cidade = @cidade, status = @status WHERE id = @id";
                lojas.Parameters.Add("razaoSocial", MySqlDbType.VarString).Value = loja.RazaoSocial;
                lojas.Parameters.Add("cnpj", MySqlDbType.VarString).Value = loja.Cnpj;
                lojas.Parameters.Add("inscEstadual", MySqlDbType.VarString).Value = loja.InscEstadual;
                lojas.Parameters.Add("fone", MySqlDbType.VarString).Value = loja.Fone;
                lojas.Parameters.Add("email", MySqlDbType.VarString).Value = loja.Email;
                lojas.Parameters.Add("CEP", MySqlDbType.VarString).Value = loja.Cep;
                lojas.Parameters.Add("rua", MySqlDbType.VarString).Value = loja.Rua;
                lojas.Parameters.Add("numero", MySqlDbType.VarString).Value = loja.Numero;
                lojas.Parameters.Add("bairro", MySqlDbType.VarString).Value = loja.Bairro;
                lojas.Parameters.Add("cidade", MySqlDbType.VarString).Value = loja.Cidade;
                lojas.Parameters.Add("status", MySqlDbType.Bit).Value = loja.Status;
                lojas.Parameters.AddWithValue("id", loja.Id);
                lojas.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        public List<Loja> ConsultarTodos()
        {
            List<Loja> loja = new List<Loja>();

            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand loj = con.CreateCommand();

            try
            {
                con.Open();
                loj.CommandText = "SELECT * FROM Loja";
                MySqlDataReader dr = loj.ExecuteReader();

                while (dr.Read())
                {
                    Loja lojas = new Loja();
                    lojas.Id = Convert.ToInt32(dr["id"]);
                    lojas.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    lojas.Cnpj = Convert.ToString(dr["cnpj"]);
                    lojas.InscEstadual = Convert.ToString(dr["inscEstadual"]);
                    lojas.Fone = Convert.ToString(dr["fone"]);
                    lojas.Email = Convert.ToString(dr["email"]);
                    lojas.Cep = Convert.ToString(dr["CEP"]);
                    lojas.Rua = Convert.ToString(dr["rua"]);
                    lojas.Numero = Convert.ToString(dr["numero"]);
                    lojas.Bairro = Convert.ToString(dr["bairro"]);
                    lojas.Cidade = Convert.ToString(dr["cidade"]);
                    lojas.Status = Convert.ToInt32(dr["status"]) == 1;
                    loja.Add(lojas);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return loja;
        }

        public List<Loja> ConsultarNomeId()
        {
            List<Loja> loja = new List<Loja>();

            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand loj = con.CreateCommand();

            try
            {
                con.Open();
                loj.CommandText = "SELECT * FROM Loja";
                MySqlDataReader dr = loj.ExecuteReader();

                while (dr.Read())
                {
                    var lojas = new Loja();
                    lojas.Id = Convert.ToInt32(dr["id"]);
                    lojas.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    loja.Add(lojas);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return loja;
        }
        
        public Loja ConsultarPorId(int id)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand loja = con.CreateCommand();

            Loja lojas = new Loja();
            try
            {
                con.Open();
                loja.CommandText = "SELECT * FROM Loja WHERE id = @id";
                loja.Parameters.AddWithValue("id", id);
                MySqlDataReader dr = loja.ExecuteReader();

                while (dr.Read())
                {
                    lojas.Id = Convert.ToInt32(dr["id"]);
                    lojas.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    lojas.Cnpj = Convert.ToString(dr["cnpj"]);
                    lojas.InscEstadual = Convert.ToString(dr["inscEstadual"]);
                    lojas.Fone = Convert.ToString(dr["fone"]);
                    lojas.Email = Convert.ToString(dr["email"]);
                    lojas.Cep = Convert.ToString(dr["CEP"]);
                    lojas.Rua = Convert.ToString(dr["rua"]);
                    lojas.Numero = Convert.ToString(dr["numero"]);
                    lojas.Bairro = Convert.ToString(dr["bairro"]);
                    lojas.Cidade = Convert.ToString(dr["cidade"]);
                    lojas.Status = Convert.ToInt32(dr["status"]) == 1;
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return lojas;
        }

        public void Deletar(int id)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedidos = con.CreateCommand();
            bool del = false;
            try
            {
                con.Open();
                pedidos.CommandText = @$"Update Loja set status = @del where id = {id}";
                pedidos.Parameters.Add("del", MySqlDbType.Byte).Value = del;
                pedidos.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return;
        }
    }
}
