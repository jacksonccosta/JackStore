using JackStore.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JackStore.Repository.Interface
{
    public interface IRepCategoriaProduto
    {
        Task<List<CategoriaProduto>> GetCategorias();
    }
}