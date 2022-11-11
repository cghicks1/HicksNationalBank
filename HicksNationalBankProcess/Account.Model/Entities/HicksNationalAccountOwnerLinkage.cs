using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Account.Model.Entities
{
    [Table("HicksNationalAccountOwnerLinkage", Schema = "Account")]
    public partial class HicksNationalAccountOwnerLinkage
    {
        [Key]
        public int Id { get; set; }
        public int? OwnerId { get; set; }
        public int? AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(HicksNationalAccount.HicksNationalAccountOwnerLinkages))]
        public virtual HicksNationalAccount Account { get; set; }
        [ForeignKey(nameof(OwnerId))]
        [InverseProperty(nameof(HicksNationalAccountOwner.HicksNationalAccountOwnerLinkages))]
        public virtual HicksNationalAccountOwner Owner { get; set; }
    }
}
