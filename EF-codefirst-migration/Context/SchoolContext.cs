using Microsoft.EntityFrameworkCore;

namespace EF_codefirst_migration.Context 
{
    public class SchoolContext : DbContext
    {
        /// <summary>Constructor with options to specify the datastore from outside this class</summary>
        /// <param name="options">Options like the datastore to use</param>
        public SchoolContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>Students table</summary>
        public DbSet<Student> Students { get; set; }
    }
}