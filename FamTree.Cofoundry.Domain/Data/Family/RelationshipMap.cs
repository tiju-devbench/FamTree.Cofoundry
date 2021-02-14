using Cofoundry.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FamTree.Cofoundry.Domain.Data.Family
{
    class RelationshipMap : IEntityTypeConfiguration<Relationship>
    {
        public void Configure(EntityTypeBuilder<Relationship> builder)
        {
            //builder.ToTable("Relationship", DbConstants.DefaultAppSchema);

            //builder.HasKey(e => new { e.CatCustomEntityId, e.UserId });

            //// Relationships
            //builder.HasOne(s => s.CatCustomEntity)
            //    .WithMany()
            //    .HasForeignKey(d => d.CatCustomEntityId);

            //builder.HasOne(s => s.User)
            //    .WithMany()
            //    .HasForeignKey(d => d.UserId);
        }
    }
}
