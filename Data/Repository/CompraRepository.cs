using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Data.SqlClient;

namespace Data.Repository
{
    public class CompraRepository
    {
        private readonly string _connectionString;

        public CompraRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Compra>> GetAllAsync()
        {
            var compras = new List<Compra>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand("ObtenerCompras", connection);
                command.CommandType = CommandType.StoredProcedure;

                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    var compra = new Compra
                    {
                        
                        IdCompra = reader.GetInt32(reader.GetOrdinal("IdCompra")),
                        IdCliente = reader.GetInt32(reader.GetOrdinal("IdCliente")),
                        IdArticulo = reader.GetInt32(reader.GetOrdinal("IdArticulo")),
                        Clientes = new Cliente
                        {
                            IdCliente = reader.GetInt32(reader.GetOrdinal("IdCliente")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            Apellidos = reader.GetString(reader.GetOrdinal("Apellidos")),
                            Direccion = reader.GetString(reader.GetOrdinal("Direccion"))
                        },
                        Articulos = new Articulo
                        {
                            IdArticulo = reader.GetInt32(reader.GetOrdinal("IdArticulo")),
                            Codigo = reader.GetString(reader.GetOrdinal("Codigo")),
                            Descripcion = reader.GetString(reader.GetOrdinal("Descripcion")),
                            Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),
                            Imagen = (byte[])reader["Imagen"],
                            Stock = reader.GetInt32(reader.GetOrdinal("Stock"))
                        },
                        Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha"))
                    };

                    compras.Add(compra);
                }
            }
            return compras;
        }
    }
}
