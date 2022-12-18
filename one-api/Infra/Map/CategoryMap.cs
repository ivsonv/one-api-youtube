using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace one_api.Infra.Map
{
    public class CategoryMap
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Category> builder)
        {
            builder.ToTable("categories_tab"); // criar tabela no banco

            builder.HasKey(key => key.id); // definindo a chave primaria no banco de dados
        }

    }
}
