using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Models
{
    public class AccountShowModel
    {
        public int Id { get; set; } 
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
    }
}
