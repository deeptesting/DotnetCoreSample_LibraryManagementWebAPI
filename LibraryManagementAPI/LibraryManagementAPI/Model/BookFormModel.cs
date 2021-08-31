using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagementAPI.Model
{
    public class BookFormModel
    {
        // [Required(ErrorMessage = "BookId is Required")]
        public string BookId { get; set; }

        [Required(ErrorMessage = "BookName is Required")]
        public string BookName { get; set; }

        [Required(ErrorMessage = "Author is Required")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Quantity is Required")]
        [Range(1, 200, ErrorMessage = "Invalid Quantity")]
        public int Quantity { get; set; }
    }
}
