using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Framework.Infrastructures.Data.Commands.Common;

public class OutBoxEventItemConfig : IEntityTypeConfiguration<OutBoxEventItem>
{
    public void Configure(EntityTypeBuilder<OutBoxEventItem> builder)
    {
        builder.Property((OutBoxEventItem c) => c.AccuredByUserId).HasMaxLength(255);
        builder.Property((OutBoxEventItem c) => c.EventName).HasMaxLength(255);
        builder.Property((OutBoxEventItem c) => c.AggregateName).HasMaxLength(255);
        builder.Property((OutBoxEventItem c) => c.EventTypeName).HasMaxLength(500);
        builder.Property((OutBoxEventItem c) => c.AggregateTypeName).HasMaxLength(500);
        builder.Property((OutBoxEventItem c) => c.TraceId).HasMaxLength(100);
        builder.Property((OutBoxEventItem c) => c.SpanId).HasMaxLength(100);
        builder.ToTable("OutBoxEventItems", "dbo");
    }
}