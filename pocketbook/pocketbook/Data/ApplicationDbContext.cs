using Microsoft.EntityFrameworkCore;
using pocketbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pocketbook.Data
{
    public class ApplicationDbContext :DbContext
    {
        //the db set property will tell ef core that we have
        // a table that needs to be created if doesnt exist
        public virtual DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {

        }
    }
}
