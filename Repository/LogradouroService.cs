using Desafio.Data;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repositories
{
    public class LogradouroService : ILogradouroService
    {
        private readonly DbContextClass _dbContext;

        public LogradouroService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> AddLogradouroAsync(Logradouro logradouro)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Endereco", logradouro.Endereco),
                new SqlParameter("@Cidade", logradouro.Cidade),
                new SqlParameter("@Estado", logradouro.Estado),
                new SqlParameter("@Cep", logradouro.Cep)
            };

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewLogradouro @Endereco, @Cidade, @Estado, @Cep", parameter.ToArray()));

            return result;
        }

        public async Task<int> DeleteLogradouroAsync(int Id)
        {
            return await Task.Run(() =>
            {
                return _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteLogradouroByID {Id}");
            });
        }

        public async Task<IEnumerable<Logradouro>> GetLogradouroByIdAsync(int Id)
        {
            var param = new SqlParameter("@Id", Id);

            var logradouroDetails = await Task.Run(() => _dbContext.Logradouros
                            .FromSqlRaw(@"exec GetLogradouroByID @Id", param).ToListAsync());

            return logradouroDetails;
        }

        public async Task<List<Logradouro>> GetLogradouroListAsync()
        {
            return await _dbContext.Logradouros
               .FromSqlRaw<Logradouro>("GetLogradouroList")
               .ToListAsync();
        }

        public async Task<int> UpdateLogradouroAsync(Logradouro logradouro)
        {
            var parameter = new List<SqlParameter>
            {
                new SqlParameter("@Endereco", logradouro.Endereco),
                new SqlParameter("@Cidade", logradouro.Cidade),
                new SqlParameter("@Estado", logradouro.Estado),
                new SqlParameter("@Cep", logradouro.Cep)
            };

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec UpdateLogradouro @Endereco, @Cidade, @Estado, @Cep", parameter.ToArray()));

            return result;
        }
    }
}
