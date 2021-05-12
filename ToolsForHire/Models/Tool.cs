using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToolsForHire.Models
{
    public class Tool
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public int NoInStock { get; set; }

        public CategoryType CategoryType { get; set; }

        [Display(Name="Category")]
        [Required]
        public byte CategoryTypeId { get; set; }
    }
}