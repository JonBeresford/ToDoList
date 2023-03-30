using api.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreInMemoryDbDemo
{
    public class StorageDbContext : DbContext
    {
        public DbSet<ToDoItemEntity> TwilioMessageEntities { get; set; }

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SmsMessages");
        }
       
       
    }
}
