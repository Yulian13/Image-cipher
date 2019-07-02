using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_cipher
{
    class PhotoContext : DbContext
    {
        public PhotoContext (string connect = "DefaultConnection") : base(connect) { }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Composition> Compositions { get; set; }
    }
}
