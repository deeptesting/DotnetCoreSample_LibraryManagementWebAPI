using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryDataAccess.DataEntityModel
{
    public partial class Student
    {
        public Student()
        {
            BookAssignments = new HashSet<BookAssignments>();
        }

        [Column("id")]
        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string StudentId { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(4)]
        public string ClassName { get; set; }
        [StringLength(400)]
        public string HomeAddress { get; set; }
        public int? Age { get; set; }
        public bool? IsActive { get; set; }

        public ICollection<BookAssignments> BookAssignments { get; set; }
    }
}
