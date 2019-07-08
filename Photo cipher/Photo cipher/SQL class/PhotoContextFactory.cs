using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photo_cipher
{
    class PhotoContextFactory : IDbContextFactory<PhotoContext>
    {
        public PhotoContext Create()
        {
            return new PhotoContext("DefaultConnection");
        }
    }
}
