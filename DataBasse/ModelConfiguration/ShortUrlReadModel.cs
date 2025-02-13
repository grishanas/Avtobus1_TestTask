using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBasse.ModelConfiguration
{
    internal class ShortUrlReadModel:IEntityTypeConfiguration<UrlInfo>
    {
        public void Configure(EntityTypeBuilder<UrlInfo> entityTypeBuilder) 
        {
            entityTypeBuilder.HasKey(c => c.shortUrl);

            entityTypeBuilder.Property<string>(c => c.Url).IsRequired().HasMaxLength(100);
            entityTypeBuilder.Property<DateTime>(c=>c.DateCreation).IsRequired();
            entityTypeBuilder.Property<string>(c => c.shortUrl).HasMaxLength(9);
            entityTypeBuilder.Property<uint>(c => c.ClicksNumber);
        }

    }
}
