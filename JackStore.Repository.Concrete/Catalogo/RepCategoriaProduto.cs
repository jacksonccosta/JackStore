using JackStore.Data.Domain;
using JackStore.Data.Mapping;
using JackStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace JackStore.Repository.Concrete
{
    public class RepCategoriaProduto : IRepCategoriaProduto
    {
        private ApplicationDbContext _dbContext;

        public RepCategoriaProduto(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoriaProduto>> GetCategorias()
        {
            return await _dbContext.Produtos.Select(c => c.Categoria).Distinct().ToListAsync();
        }
    }
}