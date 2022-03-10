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
    }
}
