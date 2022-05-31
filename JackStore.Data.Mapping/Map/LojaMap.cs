using JackStore.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JackStore.Data.Mapping
{
    public class LojaMap : BaseEntityMap<Loja>
    {
        public override void Configure(EntityTypeBuilder<Loja> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
        }
    }
}