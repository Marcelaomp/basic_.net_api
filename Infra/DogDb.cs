namespace Infra;
using Microsoft.EntityFrameworkCore;
using Domain;

public class DogDb : DbContext
{
    public DogDb(DbContextOptions<DogDb> options) : base(options) {}

    public DbSet<Dog> Dogs {get; set;} = null!;  
}