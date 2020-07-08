using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommanLayer.Models
{
    public class Compare
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public double First_Value { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string First_Value_Unit { get; set; }

        [Required]
        public double Second_Value { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string Second_Value_Unit { get; set; }

        public string Result { get; set; }

        public DateTime DateOnCreation { get; set; } = DateTime.Now;
    }
}