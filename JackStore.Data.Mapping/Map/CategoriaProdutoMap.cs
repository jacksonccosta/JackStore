using JackStore.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JackStore.Data.Mapping
{
    public class CategoriaProdutoMap : BaseEntityMap<CategoriaProduto>
    {
        public override void Configure(EntityTypeBuilder<CategoriaProduto> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        }
    }
}