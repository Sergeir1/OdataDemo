using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Demo.Models
{
    public class Trip
    {
        [Key]
        public String ID { get; set; }
        [Required]
        public String Name { get; set; }
    }
}