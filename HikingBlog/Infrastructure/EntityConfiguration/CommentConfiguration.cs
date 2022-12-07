using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NatureBlog.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NatureBlog.Infrastructure.EntityConfiguration
{
    public class CommentConfiguration: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> commentBuilder)
        {
            commentBuilder.HasKey(x => x.Id);

            commentBuilder.Property<string>(x => x.Text)
                .IsRequired()
                .HasMaxLength(300);

            commentBuilder.HasOne(x => x.Creator)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.Id);

            commentBuilder.HasOne(x => x.Destination)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.Id);
        }
    }
}
