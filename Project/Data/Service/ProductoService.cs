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
    public class ProductoService : IProductoService
    {
        private readonly SqlConnectionConfiguration _configuration;

        public ProductoService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> ProductoInsert(Producto producto)
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                var parameters = new DynamicParameters();
                parameters.Add("id_pro", producto.id_pro, DbType.Int32);
                parameters.Add("prec_pro", producto.prec_pro, DbType.Int32);
                parameters.Add("disp_pro", producto.disp_pro, DbType.String);
                parameters.Add("prov_pro", producto.prov_pro, DbType.String);
                parameters.Add("cant_pro", producto.cant_pro, DbType.Int32);
                parameters.Add("nom_pro", producto.nom_pro, DbType.String);
                parameters.Add("gar_pro", producto.gar_pro, DbType.String);
                parameters.Add("desc_pro", producto.desc_pro, DbType.String);


                const string query = @"INSERT INTO Producto(id_pro, prec_pro, disp_pro, prov_pro, cant_pro, nom_pro, gar_pro, desc_pro)
                VALUES(@id_pro, @prec_pro, @disp_pro, @prov_pro, @cant_pro, @nom_pro, @gar_pro, @desc_pro)";
                await conn.ExecuteAsync(query, new { producto.id_pro, producto.prec_pro, producto.disp_pro, producto.prov_pro, producto.cant_pro, producto.nom_pro, producto.gar_pro, producto.desc_pro },
                   commandType: CommandType.Text);
            }
            return true;
        }


        //listar productos
        public async Task<IEnumerable<Producto>> GetAllProduct()
        {
            var conn = new SqlConnection(_configuration.Value);
            var query = "SELECT id_pro, prec_pro, disp_pro, prov_pro, cant_pro, nom_pro, nom_pro, gar_pro, desc_pro FROM Producto";
            return await conn.QueryAsync<Producto>(query.ToString(), new {});
        }

        //aptualizar productos
        public async Task<bool> UpdateProductos(Producto producto)
        {
            var conn = new SqlConnection(_configuration.Value);
            var query = "UPDATE Producto SET prec_pro=@prec_pro, disp_pro=@disp_pro, prov_pro=@prov_pro, cant_pro=@cant_pro, nom_pro=@nom_pro, gar_pro=@gar_pro, desc_pro=@desc_pro WHERE id_pro=id_pro";
            var result = await conn.ExecuteAsync(query.ToString(), new
            {
                producto.prec_pro,
                producto.disp_pro,
                producto.prov_pro,
                producto.cant_pro,
                producto.nom_pro,
                producto.gar_pro,
                producto.desc_pro,
                producto.id_pro
            });
            return result > 0;
        }
    }
}
