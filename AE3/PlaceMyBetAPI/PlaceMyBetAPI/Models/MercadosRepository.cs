using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBetAPI.Models
{
    public class MercadosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=acceso_datos;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);

            return con;
        }

        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                Mercado mer = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetDouble(6));
                    mer = new Mercado(res.GetInt32(0), res.GetInt32(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetDouble(6));
                    mercados.Add(mer);
                }

                con.Close();
                return mercados;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";

            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();

                MercadoDTO mer = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetInt32(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetDouble(6));
                    mer = new MercadoDTO(res.GetDouble(2), res.GetDouble(3), res.GetDouble(4));
                    mercados.Add(mer);
                }

                con.Close();
                return mercados;
            }
            catch (MySqlException)
            {
                Debug.WriteLine("Se ha producido un error de conexión.");
                return null;
            }
        }

        internal void SaveMercadoNuevo(Mercado mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert";
        }

        internal void UpdateMercadoExistente(int id, Mercado mercado)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "update";
        }
    }
}