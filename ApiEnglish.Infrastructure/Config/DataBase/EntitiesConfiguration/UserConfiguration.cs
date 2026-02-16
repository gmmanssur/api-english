using ApiEnglish.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ApiEnglish.Infrastructure.Config.DataBase.EntitiesConfiguration
{
    public sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            
            builder.HasKey(e => e.Sequencial);
            builder.Property(e => e.Sequencial).HasColumnName("user_sequencial").ValueGeneratedOnAdd();
            builder.Property(e => e.Name).HasColumnName("user_name").IsRequired().HasMaxLength(100);
            builder.Property(e => e.Username).HasColumnName("user_username").IsRequired().HasMaxLength(50);
            builder.Property(e => e.Email).HasColumnName("user_email").IsRequired().HasMaxLength(100);
            builder.Property(e => e.PasswordHash).HasColumnName("user_hash_password").IsRequired();
            builder.Property(e => e.CreatedAt).HasColumnName("user_created_at").IsRequired();
            builder.Property(e => e.Active).HasColumnName("user_active").IsRequired();
        }
    }
}