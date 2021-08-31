using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDataAccess.DataEntityModel
{
    public partial class BookAssignments
    {
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string AssignmentId { get; set; }
        [StringLength(50)]
        public string StudentId { get; set; }
        [StringLength(20)]
        public string BookId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AllotStartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AllotEndDate { get; set; }
        public bool? IsBookGiven { get; set; }
        public bool? IsReturned { get; set; }

        public Book Book { get; set; }
        public Student Student { get; set; }
    }
}
