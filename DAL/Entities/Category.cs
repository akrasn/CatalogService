using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CategoryId { get; set; }
        //Name – required, plain text, max length = 50.
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        //Image – optional, URL.
        public string ImageUrl { get; set; }
        //Parent Category – optional
        public int ParentCategoryId { get; set; }

       // [ForeignKey("CategoryFK")]
        public ICollection<Product> Products { get; set; }
    }
}
