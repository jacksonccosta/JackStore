using JackStore.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JackStore.Data.Mapping
{
    public class ProdutoMap : BaseEntityMap<Produto>
    {
        public override void Configure(EntityTypeBuilder<Produto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Preco).HasPrecision(7, 2).IsRequired();

            builder.Property(x => x.QuantidadeEstoque).HasPrecision(4).IsRequired();
            builder.Property(x => x.Garantia).HasPrecision(4).IsRequired();
            builder.Property(x => x.TipoGarantia).IsRequired();

            builder.Property(x => x.IdCategoria).IsRequired();
            builder.HasOne(x => x.Categoria).WithMany().HasForeignKey(x => x.IdCategoria);

            builder.Property(x => x.IdLoja).IsRequired();
            builder.HasOne(x => x.Loja).WithMany().HasForeignKey(x => x.IdLoja);

            builder.Property(e => e.Imagens).HasConversion(
                v => JsonConvert.SerializeObject(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                v => JsonConvert.DeserializeObject<List<ImagemProduto>>(v, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}