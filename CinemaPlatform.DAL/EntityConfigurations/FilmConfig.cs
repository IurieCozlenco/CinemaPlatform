using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CinemaPlatform.DAL.EntityConfigurations
{
    public class FilmConfig : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {

            builder.Property(x => x.Title)
                .IsRequired(true)
                .HasMaxLength(256);

            builder.Property(x => x.StartDate)
                .HasColumnType("date");

            builder.Property(x => x.FinalDate)
                .HasColumnType("date");

        }
    }
}
