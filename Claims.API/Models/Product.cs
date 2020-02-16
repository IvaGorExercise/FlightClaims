using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claims.API.Models.Data
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public Client ClientName { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmoutCancellation { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal AmoutPerDayDellay { get; set; }

    }
}
