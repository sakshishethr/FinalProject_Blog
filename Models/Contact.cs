using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjeOT.Models
{
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string SName { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(60)]
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
