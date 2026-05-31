using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Csharp.Entites.Model
{
    public class CarCompany
    {
        [Key]
        public Guid CarID { get; set; }
        
        [Required]
        public string CarCompanyName { get; set; } = string.Empty;

        [ForeignKey("PersonEntityID")]
        public Guid PersonEntityID { get; set; }
        public PersonEntity PersonEntity { get; set; } = default!;
    }
}

