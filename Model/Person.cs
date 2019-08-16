using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace HR_Server.Model
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long PersonId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime CreatedDate { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }
        
        [MaxLength(150)]
        public string Position { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string Country { get; set; }

        [NotMapped]
        public IFormFile CV { get; set; }

        [Column(TypeName = "bit")]
        public bool IsCvUploaded { get; set; }

        [MaxLength(1000)]
        public string Experience { get; set; }

        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(150)]
        public string Other { get; set; }

        [MaxLength(250)]
        public string DiatomEnterviewees { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime InterviewDate { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }

        [Column(TypeName = "money")]
        public decimal Rate { get; set; }

        [MaxLength(150)]
        public string Status { get; set; }
    }
}