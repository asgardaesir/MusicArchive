using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicArchive.Models
{
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        // review date

        // user information?

        public Guid Id { get; set; }
        public string ReviewText { get; set; }
        public float Rating { get; set; }
    }
}