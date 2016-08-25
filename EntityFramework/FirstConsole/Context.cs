using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstConsole
{
    public class Context:DbContext
    {
        public Context()
           : base("name=FirstConsole")
        {
        }

        public DbSet<Donator> Donators { get; set; }
        public DbSet<PayWay> PayWays { get; set; }
    }
}
