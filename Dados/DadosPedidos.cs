﻿using MySql.Data.MySqlClient;
using RepresentanteMVC.ConexaoBanco;
using RepresentanteMVC.Interfaces;
using RepresentanteMVC.Models;
using System.Data;

namespace RepresentanteMVC.Dados
{
    public class DadosPedidos : ICrud<Pedidos>
    {
        public bool Adicionar(Pedidos pedidos)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedido = con.CreateCommand();

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
                pedido.Parameters.Add("status", MySqlDbType.Bit).Value = pedidos.Status;
                pedido.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return true;
        }

        public bool Editar(Pedidos pedido)
        {
            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand sqlcomand = con.CreateCommand();

            try
            {
                con.Open();
                sqlcomand.CommandText = "UPDATE Pedidos SET data = @data, valor = @valor, percentualComissao = @percentualComissao, representanteid = @representanteId, empresaid = @empresaId, lojaid = @lojaId, status = @status WHERE id = @id";
                sqlcomand.Parameters.Add("data", MySqlDbType.DateTime).Value = pedido.Data;
                sqlcomand.Parameters.Add("valor", MySqlDbType.Double).Value = pedido.Valor;
                sqlcomand.Parameters.Add("percentualComissao", MySqlDbType.Double).Value = pedido.PercentualComissao;
                sqlcomand.Parameters.Add("RepresentanteId", MySqlDbType.Int64).Value = pedido.RepresentanteId;
                sqlcomand.Parameters.Add("EmpresaId", MySqlDbType.Int64).Value = pedido.EmpresaId;
                sqlcomand.Parameters.Add("LojaId", MySqlDbType.Int64).Value = pedido.LojaId;
                sqlcomand.Parameters.Add("status", MySqlDbType.Bit).Value = pedido.Status;
                sqlcomand.Parameters.AddWithValue("id", pedido.Id);
                sqlcomand.ExecuteNonQuery();
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
            List<Pedidos> pedidos = new List<Pedidos>();

            MySqlConnection con = ConexaoMySql.conectar();
            MySqlCommand pedid = con.CreateCommand();

            try
            {
                con.Open();
                pedid.CommandText = "SELECT * FROM Pedidos";
                MySqlDataReader dr = pedid.ExecuteReader();

                while (dr.Read())
                {
                    Pedidos pedido = new Pedidos();
                    pedido.Id = Convert.ToInt32(dr["id"]);
                    pedido.Data = Convert.ToDateTime(dr["data"]);
                    pedido.Valor = Convert.ToDouble(dr["valor"]);
                    pedido.PercentualComissao = Convert.ToDouble(dr["percentualComissao"]);
                    pedido.RepresentanteId = (int)dr["representanteId"];
                    pedido.EmpresaId = (int)dr["EmpresaId"];
                    pedido.LojaId = (int)dr["LojaId"];
					pedido.Status = Convert.ToInt32(dr["status"]) == 1;

					pedido.Empresa = new DadosEmpresa().ConsultarPorId((int)dr["EmpresaId"]);
                    pedido.Loja = new DadosLoja().ConsultarPorId((int)dr["LojaId"]);
                    pedido.Representante = new DadosRepresentante().ConsultarPorId((int)dr["RepresentanteId"]);
                    pedidos.Add(pedido);
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
            return pedidos;
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
                    pedido.RepresentanteId = (int)dr["representanteId"];
                    pedido.EmpresaId = (int)dr["EmpresaId"];
                    pedido.LojaId = (int)dr["LojaId"];
					pedido.Status = Convert.ToInt32(dr["status"]) == 1;

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
			MySqlCommand pedido = con.CreateCommand();
			bool del = false;
            try
			{
				con.Open();
                
                pedido.CommandText = @$"UPDATE Pedidos SET status = @del WHERE id = {id}";
				pedido.Parameters.Add("del", MySqlDbType.Byte).Value = del;
				pedido.ExecuteNonQuery();
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
