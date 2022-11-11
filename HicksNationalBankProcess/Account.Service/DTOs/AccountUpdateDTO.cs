using System;
using System.Collections.Generic;
using System.Text;

namespace Account.Service.DTOs
{
    public class AccountUpdateDTO
    {
        public int AccountId { get; set; }
        public int? TransferAccountId { get; set; }
        public string AccountAction {get; set;}
        public decimal RenderedAmount { get; set; }

    }
}
