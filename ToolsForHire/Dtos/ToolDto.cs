using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToolsForHire.Models;

namespace ToolsForHire.Dtos
{
    public class ToolDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(1, 20)]
        public int NoInStock { get; set; }

        public byte CategoryTypeId { get; set; }

        public CategoryTypeDto CategoryType { get; set; }
    }
}