using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyNew.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        public string MembershipName { get; set; }

        public short SignUpFee { get; set; }

        public byte DurationInMonths { get; set; }

        public byte DiscountRate { get; set; }

        public enum MembershipTypeCode
        {
            Unknown= 0,
            PayAsYouGo=1,
            Monthy =2,
            Quaterly=3,
            Annually=4
        }
    }
}