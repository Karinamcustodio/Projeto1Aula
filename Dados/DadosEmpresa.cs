using MySql.Data.MySqlClient;
using RepresentanteMVC.ConexaoBanco;
using RepresentanteMVC.Interfaces;
using RepresentanteMVC.Models;
using System.Data;

namespace RepresentanteMVC.Dados
{
    public class DadosEmpresa : ICrud<Empresa>
    {
        public bool Adicionar(Empresa empresa)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand empresas = con.CreateCommand();

            try
            {
                con.Open();
                empresas.CommandText = "INSERT INTO Empresa(razaoSocial, cnpj, inscEstadual, fone, email, CEP, rua, numero, bairro, cidade, status) VALUES(@razaoSocial, @cnpj, @inscEstadual, @fone, @email, @cep, @rua, @numero, @bairro, @cidade, @status)";
                empresas.Parameters.Add("razaoSocial", MySqlDbType.VarString).Value = empresa.RazaoSocial;
                empresas.Parameters.Add("cnpj", MySqlDbType.VarString).Value = empresa.Cnpj;
                empresas.Parameters.Add("inscEstadual", MySqlDbType.VarString).Value = empresa.InscEstadual;
                empresas.Parameters.Add("fone", MySqlDbType.VarString).Value = empresa.Fone;
                empresas.Parameters.Add("email", MySqlDbType.VarString).Value = empresa.Email;
                empresas.Parameters.Add("cep", MySqlDbType.VarString).Value = empresa.Cep;
                empresas.Parameters.Add("rua", MySqlDbType.VarString).Value = empresa.Rua;
                empresas.Parameters.Add("numero", MySqlDbType.VarString).Value = empresa.Numero;
                empresas.Parameters.Add("bairro", MySqlDbType.VarString).Value = empresa.Bairro;
                empresas.Parameters.Add("cidade", MySqlDbType.VarString).Value = empresa.Cidade;
                empresas.Parameters.Add("status", MySqlDbType.Bit).Value = empresa.Status;
                empresas.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        public bool Editar(Empresa empresa)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand empresas = con.CreateCommand();

            try
            {
                con.Open();
                empresas.CommandText = "UPDATE Empresa SET razaoSocial = @razaoSocial, cnpj = @cnpj, inscEstadual = @inscEstadual, fone = @fone, email = @email, CEP = @cep, rua = @rua, numero = @numero, bairro = @bairro, cidade = @cidade, status = @status WHERE id = @id";
                empresas.Parameters.Add("razaoSocial", MySqlDbType.VarString).Value = empresa.RazaoSocial;
                empresas.Parameters.Add("cnpj", MySqlDbType.VarString).Value = empresa.Cnpj;
                empresas.Parameters.Add("inscEstadual", MySqlDbType.VarString).Value = empresa.InscEstadual;
                empresas.Parameters.Add("fone", MySqlDbType.VarString).Value = empresa.Fone;
                empresas.Parameters.Add("email", MySqlDbType.VarString).Value = empresa.Email;
                empresas.Parameters.Add("cep", MySqlDbType.VarString).Value = empresa.Cep;
                empresas.Parameters.Add("rua", MySqlDbType.VarString).Value = empresa.Rua;
                empresas.Parameters.Add("numero", MySqlDbType.VarString).Value = empresa.Numero;
                empresas.Parameters.Add("bairro", MySqlDbType.VarString).Value = empresa.Bairro;
                empresas.Parameters.Add("cidade", MySqlDbType.VarString).Value = empresa.Cidade;
                empresas.Parameters.Add("status", MySqlDbType.Bit).Value = empresa.Status;
                empresas.Parameters.AddWithValue("id", empresa.Id);
                empresas.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        public List<Empresa> ConsultarTodos()
        {
            List<Empresa> empresa = new List<Empresa>();

            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand empres = con.CreateCommand();

            try
            {
                con.Open();
                empres.CommandText = "SELECT * FROM Empresa";
                MySqlDataReader dr = empres.ExecuteReader();

                while (dr.Read())
                {
                    Empresa empresas = new Empresa();
                    empresas.Id = Convert.ToInt32(dr["id"]);
                    empresas.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    empresas.Cnpj = Convert.ToString(dr["cnpj"]);
                    empresas.InscEstadual = Convert.ToString(dr["inscEstadual"]);
                    empresas.Fone = Convert.ToString(dr["fone"]);
                    empresas.Email = Convert.ToString(dr["email"]);
                    empresas.Cep = Convert.ToString(dr["CEP"]);
                    empresas.Rua = Convert.ToString(dr["rua"]);
                    empresas.Numero = Convert.ToString(dr["numero"]);
                    empresas.Bairro = Convert.ToString(dr["bairro"]);
                    empresas.Cidade = Convert.ToString(dr["cidade"]);
                    empresas.Status = Convert.ToInt32(dr["status"]) == 1;
                    empresa.Add(empresas);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return empresa;
        }

        public List<Empresa> ConsultarNomeId()
        {
            List<Empresa> empresa = new List<Empresa>();

            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand empres = con.CreateCommand();

            try
            {
                con.Open();
                empres.CommandText = "SELECT * FROM Empresa";
                MySqlDataReader dr = empres.ExecuteReader();

                while (dr.Read())
                {
                    var empresas = new Empresa();
                    empresas.Id = Convert.ToInt32(dr["id"]);
                    empresas.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    empresa.Add(empresas);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return empresa;
        }
        
        public Empresa ConsultarPorId(int id)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand empresa = con.CreateCommand();

            Empresa empresas = new Empresa();
            try
            {
                con.Open();
                empresa.CommandText = "SELECT * FROM Empresa WHERE id = @id";
                empresa.Parameters.AddWithValue("id", id);
                MySqlDataReader dr = empresa.ExecuteReader();

                while (dr.Read())
                {
                    empresas.Id = Convert.ToInt32(dr["id"]);
                    empresas.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    empresas.Cnpj = Convert.ToString(dr["cnpj"]);
                    empresas.InscEstadual = Convert.ToString(dr["inscEstadual"]);
                    empresas.Fone = Convert.ToString(dr["fone"]);
                    empresas.Email = Convert.ToString(dr["email"]);
                    empresas.Cep = Convert.ToString(dr["CEP"]);
                    empresas.Rua = Convert.ToString(dr["rua"]);
                    empresas.Numero = Convert.ToString(dr["numero"]);
                    empresas.Bairro = Convert.ToString(dr["bairro"]);
                    empresas.Cidade = Convert.ToString(dr["cidade"]);
                    empresas.Status = Convert.ToInt32(dr["status"]) == 1;
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return empresas;
        }

        public void Deletar(int id)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedidos = con.CreateCommand();
            bool del = false;
            try
            {
                con.Open();
                pedidos.CommandText = @$"Update Empresa set status = @del where id = {id}";
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
