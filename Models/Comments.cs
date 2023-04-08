using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjeOT.Models
{
    public class Comments
    {
        [Key]
        public int CommentsID { get; set; }

        [StringLength(60)]
        public string UserN { get; set; }  // userName

        [StringLength(60)]
        public string Email { get; set; }

        [StringLength(250)]
        public string CommentDetail { get; set; }

        public DateTime CommentDate { get; set; }

        public bool CommentStatus { get; set; }


        // Comments - Blog  Iliski 
        public int BlogID { get; set; }
        public Blog Blogs { get; set; }
    }
}
