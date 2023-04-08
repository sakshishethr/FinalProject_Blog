using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjeOT.Models
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }   // unique ID 

        [StringLength(60)]
        public string WriterN_S { get; set; } 

        [StringLength(300)]
        public string WriterAbout { get; set; } 

        [StringLength(50)]
        public string WriterTitle { get; set; }

        [StringLength(100)]
        public string ShortAbout { get; set; }

        [StringLength(50)]
        [EmailAddress(ErrorMessage = "please enter a valid mail adress")]
        public string Mail { get; set; }

        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(140)]
        public string WriterImage { get; set; } 

        public ICollection<Blog> Blogs { get; set; } 
}
