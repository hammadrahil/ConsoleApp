using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Csharp.Entites.Model
{
    public class CarCompany
    {
        [Key]
        public Guid CarID { get; set; }

        [Required]
        public string CarName { get; set; } = string.Empty;

    }
}
