using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public class PersonasDbcontext : DbContext
    {
        public DbSet<Personas> Personas { get; set; }

        public PersonasDbcontext(DbContextOptions<PersonasDbcontext> options)
                : base(options)
        {

        }
    }
}
