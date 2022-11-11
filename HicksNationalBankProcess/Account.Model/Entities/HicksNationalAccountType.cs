using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Account.Model.Entities
{
    [Table("HicksNationalAccountType", Schema = "ref")]
    public partial class HicksNationalAccountType
    {
        public HicksNationalAccountType()
        {
            HicksNationalAccounts = new HashSet<HicksNationalAccount>();
        }

        [Key]
        public int Id { get; set; }
        public bool IsChecking { get; set; }
        [Required]
        [StringLength(100)]
        public string AccountType { get; set; }
        public int? WithdrawalLimit { get; set; }

        [InverseProperty(nameof(HicksNationalAccount.AccountType))]
        public virtual ICollection<HicksNationalAccount> HicksNationalAccounts { get; set; }
    }
}
