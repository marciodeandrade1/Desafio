using Entities;

namespace Desafio.Repositories
{
    public interface IClienteService
    {
        public Task<List<Cliente>> GetClienteListAsync();
        public Task<IEnumerable<Cliente>> GetClienteByIdAsync(int Id);
        public Task<int> AddClienteAsync(Cliente cliente);
        public Task<int> UpdateClienteAsync(Cliente cliente);
        public Task<int> DeleteClienteAsync(int Id);
    }
}
