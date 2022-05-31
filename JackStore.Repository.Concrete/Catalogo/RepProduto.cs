using JackStore.Data.Domain;
using JackStore.Data.Mapping;
using JackStore.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using JackStore.Common;

namespace JackStore.Repository.Concrete
{
    public class RepProduto : IRepProduto
    {
        private ApplicationDbContext _dbContext;

        public RepProduto(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Produto>> GetProdutos(string slug)
        {
            var query = _dbContext.Produtos.AsQueryable();

            if (!string.IsNullOrEmpty(slug))
            {
                var categorias = await _dbContext.Categorias.Select(x => new { x.Id, x.Nome}).ToListAsync();
                var categoria = categorias.FirstOrDefault(x => x.Nome.GetSlug() == slug.ToLower());

                if(categoria != null)
                    query = query.Where(x => x.IdCategoria == categoria.Id);
            }
            return await query.ToListAsync();
        }
    }
}