using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TradingCompanyDataTransfer;

namespace aspApp.Models
{
    public class ProductViewModel
    {

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public CategoryDTO Category { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "CountInStock is required")]
        public int CountInStock { get; set; }

        [Required(ErrorMessage = "TimeOfAdd is required")]
        public DateTime TimeOfAdd { get; set; }
    }
}
