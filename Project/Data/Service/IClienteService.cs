using Project.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.Data.Service
{
    public interface IClienteService
    {
        Task<bool> ClienteInsert(Cliente cliente);

        Task<bool> ClienteDelete(int id);

        Task<IEnumerable<Cliente>> GetAllClientes();

        Task<Cliente> GetCliente(int id_cli);

        Task<bool> UpdateCliente(Cliente cliente);
    }
}