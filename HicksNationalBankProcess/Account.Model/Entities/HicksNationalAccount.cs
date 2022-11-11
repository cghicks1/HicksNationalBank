using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Account.Model.Entities
{
    [Table("HicksNationalAccount", Schema = "Account")]
    public partial class HicksNationalAccount
    {
        public HicksNationalAccount()
        {
            HicksNationalAccountOwnerLinkages = new HashSet<HicksNationalAccountOwnerLinkage>();
        }

        [Key]
        public int Id { get; set; }
        public long? AccountNumber { get; set; }
        public int? AccountTypeId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Balance { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        [ForeignKey(nameof(AccountTypeId))]
        [InverseProperty(nameof(HicksNationalAccountType.HicksNationalAccounts))]
        public virtual HicksNationalAccountType AccountType { get; set; }
        [InverseProperty(nameof(HicksNationalAccountOwnerLinkage.Account))]
        public virtual ICollection<HicksNationalAccountOwnerLinkage> HicksNationalAccountOwnerLinkages { get; set; }
    }
}
