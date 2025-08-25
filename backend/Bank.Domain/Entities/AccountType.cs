using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Domain.Entities
{
    public class AccountType
    {
        public int AccountTypeId { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
