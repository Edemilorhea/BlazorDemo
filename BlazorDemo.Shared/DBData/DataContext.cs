using BlazorDemo.Shared.Model;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;

namespace BlazorDemo.Shared.DBData;

public class DataContext : DbContext
{
    public DbSet<Book> Book { get; set; }


    public DataContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<DataContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);

    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Book>().ToCollection("Book");
    }
}
