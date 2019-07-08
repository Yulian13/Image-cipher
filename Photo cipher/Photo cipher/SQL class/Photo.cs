using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Photo_cipher
{
    public class Photo
    {
        public int Id { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [Column(TypeName = "text")]
        public string RightKey { get; set; }

        public int? CompositionId { get; set; }
        public Composition Composition { get; set; }

        public Photo() { }
    }
}
