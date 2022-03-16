using Dapper;
using Microsoft.Data.SqlClient;
using Project.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Data.Service
{
    public class detallemuebleservice
    {
        private string ConnectionString;

        public detallemuebleservice (string connectionstring )
        {
            ConnectionString = connectionstring;

        }
        protected SqlConnection dbConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public async Task<IEnumerable<DetalleMueble>> filtro(int Cod_Pro, int Cod_Cat, int Cod_Col, int Desc_Pro, int Cod_Prov)
        {
            var db = dbConnection();
            var sql = "SELECT a.nom_pro, b.nom_cat, c.nom_col, a.desc_pro, d.nom_prov" +
                "FROM a=producto, b=categoria, c=color, d=proveedor " +
                "WHERE producto.id_pro=@Cod_Pro AND categoria.cod_cat=@Cod_Cat AND color.cod_col=@Cod_Col AND producto.desc_pro=@Desc_Pro AND proveedor.cod_prov=@Cod_Prov";
            return await db.QueryAsync<DetalleMueble>(sql.ToString(), new {Cod_Pro=Cod_Pro, Cod_Cat=Cod_Cat, Cod_Col = Cod_Col, Desc_Pro = Desc_Pro , Cod_Prov = Cod_Prov });
        }
    }
}
