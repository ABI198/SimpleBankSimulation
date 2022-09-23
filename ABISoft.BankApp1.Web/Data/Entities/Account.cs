using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Data.Entities
{
    public class Account
    {
        public int Id { get; set; } //PK
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int UserId { get; set; } //FK
        public User User { get; set; } //NP
    }
}
