using Microsoft.EntityFrameworkCore;

namespace EstoqueAtalaia.Models
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<ProductOutput> ProductOutputs { get; set; }

        public DbSet<OrdemDeServico> OrdemDeServicos { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

    }
}
