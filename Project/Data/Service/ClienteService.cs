using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Project.Data.Model;

namespace Project.Data.Service
{
    public class ClienteService : IClienteService
    {
        //connection sql server
        private readonly SqlConnectionConfiguration _configuration;

        public ClienteService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ClienteInsert(Cliente cliente)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("id_cli", cliente.id_cli, DbType.Int32);
                parameters.Add("nom_cli", cliente.nom_cli, DbType.String);
                parameters.Add("apell_cli", cliente.apell_cli, DbType.String);
                parameters.Add("tel_cli", cliente.tel_cli, DbType.String);
                parameters.Add("email_cli", cliente.email_cli, DbType.String);
                parameters.Add("dir_cli", cliente.dir_cli, DbType.String);

                const string query = @"INSERT INTO Cliente(id_cli, nom_cli, apell_cli, tel_cli, 
                email_cli, dir_cli)
                VALUES (@id_cli, @nom_cli, @apell_cli, @tel_cli, @email_cli, @dir_cli)";
                await conn.ExecuteAsync(query, new { cliente.id_cli, cliente.nom_cli, 
                    cliente.apell_cli, cliente.tel_cli, cliente.email_cli, cliente.dir_cli },
                    commandType: CommandType.Text);
            }
            return true;
        }


        //eliminar cliente
        public async Task<bool> ClienteDelete(int id)
        {
            var conn = new SqlConnection(_configuration.Value);
                var query = @"DELETE FROM Cliente WHERE id_cli = @id";
                var result = await conn.ExecuteAsync(query.ToString(), new { id = id });
            return result > 0;
        }

        //listado clientes
        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            var conn = new SqlConnection(_configuration.Value);
            var query = "SELECT id_cli, nom_cli, apell_cli, tel_cli, email_cli, dir_cli FROM Cliente";
            return await conn.QueryAsync<Cliente>(query.ToString(), new { });
        }
        
        //seleccionar un cliente
        public async Task<Cliente> GetCliente(int id_cli)
        {
            var conn = new SqlConnection(_configuration.Value);
            var query = "SELECT id_cli, nom_cli, apell_cli, tel_cli, email_cli, dir_cli FROM Cliente WHERE id_cli = @id_cli";
            return await conn.QueryFirstOrDefaultAsync<Cliente>(query.ToString(), new { id_cli = id_cli });
        }


        //actualizar
        public async Task<bool> UpdateCliente(Cliente cliente)
        {
            var conn = new SqlConnection(_configuration.Value);
            var query = "UPDATE Cliente SET nom_cli = @nom_cli, apell_cli = @apell_cli, tel_cli = @tel_cli, email_cli = @email_cli, dir_cli = @dir_cli WHERE id_cli = @id_cli";
            var result = await conn.ExecuteAsync(query.ToString(), new
            {
                cliente.nom_cli,
                cliente.apell_cli,
                cliente.tel_cli,
                cliente.email_cli,
                cliente.dir_cli,
                cliente.id_cli
            });
            return result > 0;
        } 
    }
}
