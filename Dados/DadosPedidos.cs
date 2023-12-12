using MySql.Data.MySqlClient;
using RepresentanteMVC.ConexaoBanco;
using RepresentanteMVC.Interfaces;
using RepresentanteMVC.Models;
using System.Data;

namespace RepresentanteMVC.Dados
{
    public class DadosPedidos : ICrud<Pedidos>
    {
        public static int id;
        public bool VerificarRepresentante(Pedidos pedidos)
        {
           
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand sql = con.CreateCommand();
            var representantes = new Representante();
            try
            {
                con.Open();
                sql.CommandText = @$"SELECT * FROM Representante where id = {pedidos.Representante.Id}";
                MySqlDataReader dr = sql.ExecuteReader();

                while (dr.Read())
                {

                    representantes.Id = Convert.ToInt32(dr["id"]);
                    representantes.Cnpj = Convert.ToString(dr["cnpj"]);
                }
                
                if (representantes.Id != 0)
                {
                    if (pedidos.Representante.Cnpj == representantes.Cnpj)
                    {
                        id = representantes.Id;
                        return true;
                    }
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return false;


        }
        public bool Adicionar(Pedidos pedidos)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedido = con.CreateCommand();
            pedidos.status = true;

            try
            {
                con.Open();
                pedido.CommandText = "INSERT INTO Pedidos(data, valor, percentualComissao, representanteid, empresaid, lojaid, status) VALUES(@data, @valor, @percentualComissao, @representanteId, @empresaId, @lojaId, @status)";
                pedido.Parameters.Add("data", MySqlDbType.DateTime).Value = pedidos.Data;
                pedido.Parameters.Add("valor", MySqlDbType.Double).Value = pedidos.Valor;
                pedido.Parameters.Add("percentualComissao", MySqlDbType.Double).Value = pedidos.PercentualComissao;
                pedido.Parameters.Add("representanteID", MySqlDbType.Int64).Value = pedidos.RepresentanteId;
                pedido.Parameters.Add("EmpresaId", MySqlDbType.Int64).Value = pedidos.EmpresaId;
                pedido.Parameters.Add("LojaId", MySqlDbType.Int64).Value = pedidos.LojaId;
                pedido.Parameters.Add("status", MySqlDbType.Byte).Value = pedidos.status;

                pedido.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        public bool Editar(Pedidos pedidos)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedido = con.CreateCommand();
            try
            {
                con.Open();
                pedido.CommandText = "UPDATE Pedidos SET data = @data, valor = @valor, percentualComissao = @percentualComissao, @representanteid = representanteid, @empresaId = empresaid, @lojaid = lojaid WHERE id = @id";
                
                pedido.Parameters.Add("data", MySqlDbType.DateTime).Value = pedidos.Data;
                pedido.Parameters.Add("valor", MySqlDbType.Double).Value = pedidos.Valor;
                pedido.Parameters.Add("percentualComissao", MySqlDbType.Double).Value = pedidos.PercentualComissao;
                pedido.Parameters.Add("representanteID", MySqlDbType.Int64).Value = pedidos.RepresentanteId;
                pedido.Parameters.Add("EmpresaId", MySqlDbType.Int64).Value = pedidos.EmpresaId;
                pedido.Parameters.Add("LojaId", MySqlDbType.Int64).Value = pedidos.LojaId;
                pedido.Parameters.AddWithValue("id", pedidos.Id);
                pedido.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }
        public List<Pedidos> ConsultarTodos()
        {
            Pedidos pedidos;
            Console.WriteLine();
            List<Pedidos> pedidosList = new List<Pedidos>();
            
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedid = con.CreateCommand();

            try
            {
                con.Open();
                pedid.CommandText = $"SELECT * FROM Pedidos where RepresentanteID = {id}";       
                MySqlDataReader dr = pedid.ExecuteReader();

                while (dr.Read())
                {
                    Pedidos pedido = new Pedidos();
                    pedido.Id = Convert.ToInt32(dr["id"]);
                    pedido.Data = Convert.ToDateTime(dr["data"]);
                    pedido.Valor = Convert.ToDouble(dr["valor"]);
                    pedido.PercentualComissao = Convert.ToDouble(dr["percentualComissao"]);
                    pedido.RepresentanteId = (int)dr["representanteID"];
                    pedido.EmpresaId = (int)dr["EmpresaId"];
                    pedido.LojaId = (int)dr["LojaId"];

                    pedido.Empresa = new DadosEmpresa().ConsultarPorId((int)dr["EmpresaId"]);
                    pedido.Loja = new DadosLoja().ConsultarPorId((int)dr["LojaId"]);
                    pedido.Representante = new DadosRepresentante().ConsultarPorId((int)dr["RepresentanteId"]);
                    pedidosList.Add(pedido);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return pedidosList;
        }

        public Pedidos ConsultarPorId(int id)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedidos = con.CreateCommand();

            Pedidos pedido = new Pedidos();
            try
            {
                con.Open();
                pedidos.CommandText = "SELECT * FROM Pedidos WHERE id = @id";
                pedidos.Parameters.AddWithValue("id", id);
                MySqlDataReader dr = pedidos.ExecuteReader();

                while (dr.Read())
                {
                    pedido.Id = Convert.ToInt32(dr["id"]);
                    pedido.Data = Convert.ToDateTime(dr["data"]);
                    pedido.Valor = Convert.ToDouble(dr["valor"]);
                    pedido.PercentualComissao = Convert.ToDouble(dr["percentualComissao"]);
                    pedido.RepresentanteId = (int)dr["representanteID"];
                    pedido.EmpresaId = (int)dr["EmpresaId"];
                    pedido.LojaId = (int)dr["LojaId"];

                    pedido.Empresa = new DadosEmpresa().ConsultarPorId((int)dr["EmpresaId"]);
                    pedido.Loja = new DadosLoja().ConsultarPorId((int)dr["LojaId"]);
                    pedido.Representante = new DadosRepresentante().ConsultarPorId((int)dr["RepresentanteId"]);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return pedido;
        }

        public void Deletar(int id)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedidos = con.CreateCommand();
            bool del = false;
            try
            {
                con.Open();
                pedidos.CommandText = @$"Update Pedidos set status = @del where id = {id}";
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
