using SMART_BIN.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMART_BIN
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Account> WithoutPasswords(this IEnumerable<Account> accounts)
        {
            return accounts.Select(x => x.WithoutPassword());
        }

        public static Account WithoutPassword(this Account account)
        {
            account.Password = null;
            return account;
        }
    }
}