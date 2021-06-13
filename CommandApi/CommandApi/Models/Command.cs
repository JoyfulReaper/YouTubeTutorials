using System;
using System.ComponentModel.DataAnnotations;


namespace CommandApi.Models
{
    public class Command
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(2500)]
        [Required]
        public string HowTo { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Line { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Platform { get; set; }
    }
}
