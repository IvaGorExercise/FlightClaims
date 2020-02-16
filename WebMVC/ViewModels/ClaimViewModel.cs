using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVC.ViewModels.Annotations;

namespace WebMVC.ViewModels
{
    public class ClaimViewModel
    {
        [Required]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Email")]

        //[RegularExpression(@"\[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email Format")]
        public string Email { get; set; }

        [Required]
       // [RegularExpression(@"(0[1-9]|1[0-2])\/[0-9]{2}", ErrorMessage = "Expiration should match a valid MM/YY value")]
        [DisplayName("Policy number")]
        public string PolicyNumber { get; set; }

        [Required]
        [DisplayName("Flight number")]
        public string OriginalFlightNumber { get; set; }

        [Required]
        [DisplayName("Flight date")]
        [DateCheckAttribute(ErrorMessage = "Date shoul be max 45 days ago")]
        public DateTime OriginalFlightDate { get; set; }

        [DisplayName("New flight number")]
        public string NewFlightNumber { get; set; }

        [DisplayName("New flight date")]
        [DateCheckAttribute(ErrorMessage = "Date shoul be max 45 days ago")]
        public DateTime NewFlightDate { get; set; }

        [Required]
        public string Reason { get; set; }

        [Required]
        public string Consequence { get; set; }

        public IEnumerable<SelectListItem> ReasonList => GetResaon();
        public IEnumerable<SelectListItem> ConsequenceList { get; set; }



       public static IEnumerable<SelectListItem> GetResaon()
        {
            var items = new List<SelectListItem>();

            items.Add(new SelectListItem() { Value = null, Text = "Please select one", Selected = true });
            items.Add(new SelectListItem()
            {
                Value = "WEATHER",
                Text = "Weather"
            });
            items.Add(new SelectListItem()
            {
                Value = "TECHMECH",
                Text = "Technical Mechanical"
            });
            items.Add(new SelectListItem()
            {
                Value = "STAFFING",
                Text = "Staffing"
            });
            items.Add(new SelectListItem()
            {
                Value = "SECURITY",
                Text = "Security"
            });
            items.Add(new SelectListItem()
            {
                Value = "OTHER",
                Text = "Other"
            });

            return items;
        }

        public static IEnumerable<SelectListItem> GetConsequence()
        {
            var items = new List<SelectListItem>();

            items.Add(new SelectListItem() { Value = null, Text = "All", Selected = true });
            items.Add(new SelectListItem()
            {
                Value = "C",
                Text = "Consequence"
            });
            items.Add(new SelectListItem()
            {
                Value = "D",
                Text = "Delay"
            });

            return items;
        }

    }
}
