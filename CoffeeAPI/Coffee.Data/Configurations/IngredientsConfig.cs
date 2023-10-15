using Coffee.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coffee.Data.Configurations;

public class IngredientsConfig : IEntityTypeConfiguration<IngredientsEntity>
{
    public void Configure(EntityTypeBuilder<IngredientsEntity> builder)
    {
        builder
            .HasOne(d => d.Coffee)
            .WithMany(p => p.Ingredients)
            .HasForeignKey(fk => fk.CoffeeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Ingredients_Coffee");
    }
}