using Bank.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Application.DTO.Report
{
    public class ReportTransactionResponse
    {
        public string AccountNumber { get; internal set; }

        public string ClientName { get; internal set; }

        public DateTime DateTransaction { get; set; }

        public decimal Amount { get; set; }

        public decimal Balance { get; set; }

        public decimal InitialBalance { get; set; }
    }
}
