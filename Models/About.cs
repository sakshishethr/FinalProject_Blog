using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjeOT.Models
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }

        [StringLength(800)]   // max  800 karakter olabilir.
        public string AboutDetails { get; set; } // icerik

        [StringLength(800)]
        public string AboutDetails_2 { get; set; }

        [StringLength(140)]
        public string AboutImage { get; set; }

        [StringLength(140)]
        public string AboutImage_2 { get; set; }
    }
}
