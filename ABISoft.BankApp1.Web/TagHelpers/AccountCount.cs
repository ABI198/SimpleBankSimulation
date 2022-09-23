using ABISoft.BankApp1.Web.Data.Context;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABISoft.BankApp1.Web.TagHelpers
{
    [HtmlTargetElement("accountCount")]
    public class AccountCount : TagHelper
    {
        public int UserId { get; set; }

        private readonly BankContext _bankContext;
        public AccountCount(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountNumber = _bankContext.Accounts.Count(x => x.UserId == UserId);
            var html = $"<span class='badge bg-warning pt-2 pb-2 pr-4 pl-4'>{accountNumber}</span>";
            output.Content.SetHtmlContent(html);
        }
    }
}
