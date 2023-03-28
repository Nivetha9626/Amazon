using Microsoft.EntityFrameworkCore;

namespace Amazon.Infrastructure
{
    //it create object for us. we dont need to create it
    public class DbContextFactory : IApplicationDbContextFactory
    {
        private readonly string _connectionString;

        private ApplicationDbContext _dbContext;

        public DbContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ApplicationDbContext Get()
        {
            DbContextOptions<ApplicationDbContext> options;
            if (_dbContext != null)
            {
                return _dbContext;
            }

            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(_connectionString);
            options = optionsBuilder.Options;

            _dbContext = new ApplicationDbContext(options);
            return _dbContext;
        }

        public void Dispose()
        {
            _dbContext = null;
        }
    }
}