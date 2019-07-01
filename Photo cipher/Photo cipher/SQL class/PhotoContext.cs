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
        public PhotoContext () : base("DefaultConnection") { }

        public DbSet<Photo> Photos { get; set; }
        public DbSet<Composition> Compositions { get; set; }
    }
}
