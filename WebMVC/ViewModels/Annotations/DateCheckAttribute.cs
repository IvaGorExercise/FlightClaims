using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.ViewModels.Annotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class DateCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var dt = (DateTime)value;
            if (dt > DateTime.Now.Date.AddDays(-45) && dt <= DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }
    }
}
