using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace MVCCURD.Models
{
    public class Company
    {
        [Required]
        public string Id { get; set; }

        [Required]

        public string Name { get; set; }
        // [DataType(DataType.Password)]
    }
}