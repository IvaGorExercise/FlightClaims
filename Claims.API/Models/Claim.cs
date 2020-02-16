using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Claims.API.Models
{
   
    public class Claim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string ClaimCaseNumber {
            get
            {
                Random generator = new Random();
                String claimCaseNumber = generator.Next(0, 9999999).ToString("D7");
                claimCaseNumber = DateTime.Now.Day.ToString("D2") + DateTime.Now.Month.ToString("D2") + claimCaseNumber;
                return claimCaseNumber;
            }
        }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PolicyNumber { get; set; }
        public string OriginalFlightNumber { get; set; }
        public DateTime OriginalFlightDate { get; set; }
        public string InterruptionReason { get; set; }
        public string InterruptionConsequence { get; set; }
        public string NewFlightNumber { get; set; }
        public DateTime? NewFlightDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ClaimAmmount { get; set; }
        public bool? IsProcessed { get; set; }
        public bool? IsFinished { get; set; }

        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }


    }
}
