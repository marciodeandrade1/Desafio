using Desafio.Data;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repositories
{
    public class ClienteService : IClienteService
    {
        private readonly DbContextClass _dbContext;

        public ClienteService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Cliente>> GetClienteListAsync()
        {
            return await _dbContext.Clientes
                .FromSqlRaw("GetClienteList")
                .ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> GetClienteByIdAsync(int Id)
        {
            var param = new SqlParameter("@Id", Id);
  
            var clienteDetails = await Task.Run(() => _dbContext.Clientes
            .FromSqlRaw(@"exec GetClienteByID @Id", param).ToListAsync());
            return clienteDetails;
        }

        public async Task<int> AddClienteAsync(Cliente cliente)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@nome", cliente.Nome),
                new SqlParameter("@email", cliente.Email),
                new SqlParameter("@logotipo", cliente.Logotipo)
            };

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec AddNewCliente @nome, @email, @logotipo", parameter.ToArray()));

            return result;
           
        }
        public async Task<int> UpdateClienteAsync(Cliente cliente)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@nome", cliente.Nome),
                new SqlParameter("@email", cliente.Email),
                new SqlParameter("@logotipo", cliente.Logotipo)
            };

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateCliente @nome, @email, @logotipo", parameter.ToArray()));
            return result;
        }
        public async Task<int> DeleteClienteAsync(int Id)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteClienteByID {Id}"));
        }
    }
}
