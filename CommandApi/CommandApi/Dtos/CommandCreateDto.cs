using System;
using System.ComponentModel.DataAnnotations;

namespace CommandApi.Dtos
{
    public class CommandCreateDto
    {
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
