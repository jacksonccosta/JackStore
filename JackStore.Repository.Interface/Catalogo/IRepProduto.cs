using JackStore.Data.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JackStore.Repository.Interface
{
    public interface IRepProduto
    {
        Task<List<Produto>> GetProdutos(string slug);
    }
}