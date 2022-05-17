using CinemaPlatform.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaPlatform.DAL.EntityConfigurations
{
    public class PlaceStatusConfig : IEntityTypeConfiguration<PlaceStatus>
    {
        public void Configure(EntityTypeBuilder<PlaceStatus> builder)
        {
            builder.HasOne(p => p.Row)
                .WithMany(r => r.PlaceStatuses)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(p => p.Place)
                .WithMany(p => p.PlaceStatuses)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}
