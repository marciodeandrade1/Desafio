using Entities;

namespace Desafio.Repositories
{
    public interface ILogradouroService
    {
        public Task<List<Logradouro>> GetLogradouroListAsync();
        public Task<IEnumerable<Logradouro>> GetLogradouroByIdAsync(int Id);
        public Task<int> AddLogradouroAsync(Logradouro logradouro);
        public Task<int> UpdateLogradouroAsync(Logradouro logradouro);
        public Task<int> DeleteLogradouroAsync(int Id);
    }
}
