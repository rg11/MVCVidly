using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter Customer Name")]
        [StringLength(255)]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }


        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

                                
        [Required]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }


        public string Title
        {
            get
            {
                return (Id > 0) ? "Edit Customer View" : "New Customer View";
            }
        }

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Birthdate = customer.Birthdate;
            IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            MembershipTypeId = customer.MembershipTypeId;
        }
    }
}