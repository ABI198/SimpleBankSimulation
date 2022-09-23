using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.Data.Entities
{
    public class User
    {
        public int Id { get; set; } //PK
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Account> Accounts { get; set; } //NP
    }
}
