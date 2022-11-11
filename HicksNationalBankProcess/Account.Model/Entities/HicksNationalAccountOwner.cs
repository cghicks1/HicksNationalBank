using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Account.Model.Entities
{
    [Table("HicksNationalAccountOwner", Schema = "Account")]
    public partial class HicksNationalAccountOwner
    {
        public HicksNationalAccountOwner()
        {
            HicksNationalAccountOwnerLinkages = new HashSet<HicksNationalAccountOwnerLinkage>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }

        [InverseProperty(nameof(HicksNationalAccountOwnerLinkage.Owner))]
        public virtual ICollection<HicksNationalAccountOwnerLinkage> HicksNationalAccountOwnerLinkages { get; set; }
    }
}
