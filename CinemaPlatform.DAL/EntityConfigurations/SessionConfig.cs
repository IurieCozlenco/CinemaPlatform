using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CinemaPlatform.DAL.EntityConfigurations
{
    public class SessionConfig : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(x => x.Date)
                .HasColumnType("date");

            builder.Property(x => x.DefaultPrice)
                .HasColumnType("money");

            builder.HasOne(x => x.Hall)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.HallId)
                .IsRequired(false);

            builder.HasOne(x => x.Film)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.FilmId)
                .IsRequired(true);
        }
    }
}
