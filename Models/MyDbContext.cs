using System.Collections.Generic;
using System.Xml;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Models
{
    public class MyDbContext: DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
    }

}
