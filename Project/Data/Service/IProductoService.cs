using Project.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Data.Service
{
    public interface IProductoService
    {
        Task<bool> ProductoInsert(Producto producto);

        Task<IEnumerable<Producto>> GetAllProduct();

        Task<bool> UpdateProductos(Producto producto);
    }
}