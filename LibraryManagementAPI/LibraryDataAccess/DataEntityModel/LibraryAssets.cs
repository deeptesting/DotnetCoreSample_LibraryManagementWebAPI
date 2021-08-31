using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDataAccess.DataEntityModel
{
    public partial class LibraryAssets
    {
        [Column("id")]
        public long Id { get; set; }
        [StringLength(20)]
        public string BookId { get; set; }
        public int? Quantity { get; set; }
        public bool? IsActive { get; set; }

        public Book Book { get; set; }
    }
}
