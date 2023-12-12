using MySql.Data.MySqlClient;
using RepresentanteMVC.ConexaoBanco;
using RepresentanteMVC.Interfaces;
using RepresentanteMVC.Models;
using System.Data;


namespace RepresentanteMVC.Dados
{
    public class DadosRepresentante : ICrud<Representante>
    {
        public bool Adicionar(Representante representante)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand representes = con.CreateCommand();

            try
            {
                con.Open();
                representes.CommandText = "INSERT INTO Representante(razaoSocial, cnpj, core, fone, email, status) VALUES(@razaoSocial, @cnpj, @core, @fone, @email, @status)";
                representes.Parameters.Add("razaoSocial", MySqlDbType.VarString).Value = representante.RazaoSocial;
                representes.Parameters.Add("cnpj", MySqlDbType.VarString).Value = representante.Cnpj;
                representes.Parameters.Add("core", MySqlDbType.VarString).Value = representante.Core;
                representes.Parameters.Add("fone", MySqlDbType.VarString).Value = representante.Fone;
                representes.Parameters.Add("email", MySqlDbType.VarString).Value = representante.Email;
                representes.Parameters.Add("status", MySqlDbType.Bit).Value = representante.Status;
                representes.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        public bool Editar(Representante representante)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand representes = con.CreateCommand();

            try
            {
                con.Open();
                representes.CommandText = "UPDATE Representante SET razaoSocial = @razaoSocial, cnpj = @cnpj, core = @core, fone = @fone, email = @email, status = @status WHERE id = @id";
                representes.Parameters.Add("razaoSocial", MySqlDbType.VarString).Value = representante.RazaoSocial;
                representes.Parameters.Add("cnpj", MySqlDbType.VarString).Value = representante.Cnpj;
                representes.Parameters.Add("core", MySqlDbType.VarString).Value = representante.Core;
                representes.Parameters.Add("fone", MySqlDbType.VarString).Value = representante.Fone;
                representes.Parameters.Add("email", MySqlDbType.VarString).Value = representante.Email;
                representes.Parameters.Add("status", MySqlDbType.Bit).Value = representante.Status;
                representes.Parameters.AddWithValue("id", representante.Id);
                representes.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        public List<Representante> ConsultarTodos()
        {
            List<Representante> representante = new List<Representante>();

            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand represent = con.CreateCommand();

            try
            {
                con.Open();
                represent.CommandText = "SELECT * FROM Representante";
                MySqlDataReader dr = represent.ExecuteReader();

                while (dr.Read())
                {
                    Representante representantes = new Representante();
                    representantes.Id = Convert.ToInt32(dr["id"]);
                    representantes.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    representantes.Cnpj = Convert.ToString(dr["cnpj"]);
                    representantes.Core = Convert.ToString(dr["core"]);
                    representantes.Fone = Convert.ToString(dr["fone"]);
                    representantes.Email = Convert.ToString(dr["email"]);
                    representantes.Status = Convert.ToInt32(dr["status"]) == 1;
                    representante.Add(representantes);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return representante;
        }

        public List<Representante> ConsultarNomeId()
        {
            List<Representante> representante = new List<Representante>();

            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand sql = con.CreateCommand();

            try
            {
                con.Open();
                sql.CommandText = "SELECT * FROM Representante";
                MySqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {
                    var representantes = new Representante();
                    representantes.Id = Convert.ToInt32(dr["id"]);
                    representantes.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    representante.Add(representantes);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return representante;
        }

        public Representante ConsultarPorId(int id)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand represent = con.CreateCommand();

            Representante representante = new Representante();
            try
            {
                con.Open();
                represent.CommandText = "SELECT * FROM Representante WHERE id = @id";
                represent.Parameters.AddWithValue("id", id);
                MySqlDataReader dr = represent.ExecuteReader();

                while (dr.Read())
                {
                    representante.Id = Convert.ToInt32(dr["id"]);
                    representante.RazaoSocial = Convert.ToString(dr["razaoSocial"]);
                    representante.Cnpj = Convert.ToString(dr["cnpj"]);
                    representante.Core = Convert.ToString(dr["core"]);
                    representante.Fone = Convert.ToString(dr["fone"]);
                    representante.Email = Convert.ToString(dr["email"]);
                    representante.Status = Convert.ToInt32(dr["status"]) == 1;
                }
            }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    con.Close();
                }
                return representante;
        }

        public void Deletar(int id)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedidos = con.CreateCommand();
            bool del = false;
            try
            {
                con.Open();
                pedidos.CommandText = @$"Update Representante set status = @del where id = {id}";
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
