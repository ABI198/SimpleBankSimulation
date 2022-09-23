using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Models
{
    public class SendMoneyTransferModel
    {
        public int SenderAccountId { get; set; }
        public int ReceiverAccountId { get; set; }
        public int Amount { get; set; }
    }
}
