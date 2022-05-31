namespace JackStore.Data.Domain
{
    public class ImagemProduto : BaseEntity
    {
        public string NomeArquivo { get; set; }
        public bool Principal { get; set; }
    }
}