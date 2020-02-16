using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Claims.API.Models
{
     public class InterruptionResaon
      {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ReasonId { get; set; }
        public string Reason { get; set; }
        public bool Active { get; set; }
    }
}
