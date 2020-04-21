using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyNew.Models
{
    public class Min18YearsIfMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == (byte)MembershipType.MembershipTypeCode.Unknown  ||
                customer.MembershipTypeId== (byte)MembershipType.MembershipTypeCode.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required");

            var age = DateTime.Today.Year - customer.Birthdate.Year;

           return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be 18 years old to be a member") ;
        }
    }
}