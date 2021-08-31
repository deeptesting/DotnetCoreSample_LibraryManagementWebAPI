using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDataAccess.DataEntityModel
{
    public partial class Book
    {
        public Book()
        {
            BookAssignments = new HashSet<BookAssignments>();
            LibraryAssets = new HashSet<LibraryAssets>();
        }

        [Column("id")]
        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string BookId { get; set; }
        [StringLength(100)]
        public string BookName { get; set; }
        [StringLength(100)]
        public string Author { get; set; }

        public ICollection<BookAssignments> BookAssignments { get; set; }
        public ICollection<LibraryAssets> LibraryAssets { get; set; }
    }
}
