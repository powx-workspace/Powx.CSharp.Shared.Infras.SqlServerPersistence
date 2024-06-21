using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Domain.Entities;
using Shared.Core.Domain.Rules.BaseEntityRules;

namespace Shared.Infras.SqlServerPersistence.EntityConfigs;

public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .Property(e => e.Id)
            .HasMaxLength(StringIdRule.MaxLen);

        builder
            .Property(e => e.CreatedAt);

        builder
            .Property(e => e.LastUpdatedAt)
            .IsRequired(false);
    }
}