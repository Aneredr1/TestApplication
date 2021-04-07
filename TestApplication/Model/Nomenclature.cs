using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace TestApplication.Model
{
    public class Nomenclature
    {
        [Key] [Required]
        public int Nomenclature_Id { get; set; }

        [MaxLength(150)] [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime FromDate { get; set; }

        [Required]
        public DateTime ToDate { get; set; }
    }
}
