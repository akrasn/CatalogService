using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }
        //Name – required, plain text, max length = 50.
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        //Image – optional, URL.
        public string ImageUrl { get; set; }
        //Category – required, one item can belong to only one category.
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Price – required, money.
        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        //Amount – required, positive int.
        [Required]
        [Range(0, uint.MaxValue)]
        public uint Amount { get; set; }

    }
}