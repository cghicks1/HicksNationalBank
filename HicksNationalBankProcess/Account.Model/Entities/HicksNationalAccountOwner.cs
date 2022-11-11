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
        [Key]
        public int Id { get; set; }
        public int? AccountId { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }

        [ForeignKey(nameof(AccountId))]
        [InverseProperty(nameof(HicksNationalAccount.HicksNationalAccountOwners))]
        public virtual HicksNationalAccount Account { get; set; }
    }
}
