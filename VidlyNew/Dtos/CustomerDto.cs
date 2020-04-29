using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VidlyNew.Models;

namespace VidlyNew.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } 
        
        //[Min18YearsIfMember]
        public DateTime Birthdate { get; set; } 

        public bool IsSubscribedToNewsletter { get; set; }     

        [Required]        
        public byte MembershipTypeId { get; set; }

        public MembershipDto MembershipType { get; set; }
    }
}