using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyMicroservices.Order.Domain.Entities;

namespace UdemyMicroservices.Order.Persistence.Configuration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {


            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.Province).IsRequired().HasMaxLength(50);
            builder.Property(a => a.District).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Street).IsRequired().HasMaxLength(100);
            builder.Property(a => a.ZipCode).IsRequired().HasMaxLength(20);
            builder.Property(a => a.Line).IsRequired().HasMaxLength(200);



        }
    }
}
