using Project.Data.Model;
using System.Threading.Tasks;

namespace Project.Data.Service
{
    public interface IClienteService
    {
        Task<bool> ClienteInsert(Cliente cliente);
    }
}