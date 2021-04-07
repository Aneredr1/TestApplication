using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestApplication.Model
{
    public class User
    {
        [Key] [Required]
        public int User_Id { get; set; }

        [MaxLength(150)] [Required]
        public string Login { get; set; }

        [Required]
        public string Pass { get; set; }
    }
}
