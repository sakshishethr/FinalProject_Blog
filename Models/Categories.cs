using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebProjeOT.Models
{
    public class Categories
    {
        [Key]
        public int CategoriesID { get; set; }

        


        // Categories  -  Blog Iliski

        [StringLength(30)]
        public string CategoriesName { get; set; }

        [StringLength(500)]
        public string CategoryDescription { get; set; }
        public ICollection<Blog> Blogs { get; set; } 
    }
}
