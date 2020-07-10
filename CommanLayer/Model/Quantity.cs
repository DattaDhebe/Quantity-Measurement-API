using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommanLayer
{
    public class Quantity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-z]*$")]
        public string MeasurementType { get; set; }

        [Required]
        [RegularExpression(@"^[A-Z][a-zA-Z]*$")]
        public string ConversionType { get; set; }
        /// <summary>
        /// value for input
        /// </summary>
        [Required]
        public double Value { get; set; }

        /// <summary>
        /// result for conversion
        /// </summary>
        public double Result { get; set; }

        /// <summary>
        /// date and time when result is generated
        /// </summary>
        public DateTime DateOfCreation { get; set; } = DateTime.Now;
    }
}
