using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ToolsForHire.Models;

namespace ToolsForHire.ViewModels
{
    public class ToolFormViewModel
    {
        public IEnumerable<CategoryType> CategoryTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name="Number in Stock")]
        [Range(1, 20)]
        [Required]
        public int? NoInStock { get; set; }

        [Display(Name = "Category")]
        [Required]
        public byte? CategoryTypeId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Tool" : "New Tool";
            }
        }

        public ToolFormViewModel()
        {
            Id = 0;
        }

        public ToolFormViewModel(Tool tool)
        {
            Id = tool.Id;
            Name = tool.Name;
            NoInStock = tool.NoInStock;
            CategoryTypeId = tool.CategoryTypeId;
        }


    }
}