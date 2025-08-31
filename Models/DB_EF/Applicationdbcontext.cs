using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinqQueryEf.Models.DB_EF
{
    public class Applicationdbcontext:DbContext
    {
        public Applicationdbcontext():base("Testdb") { }
        public DbSet<EmpDetails> EmpDetails { get; set; }
    }
}