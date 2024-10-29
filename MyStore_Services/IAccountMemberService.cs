using Business_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Services
{
    public interface IAccountMemberService
    {
        public List<AccountMember> GetAccountMembers();
        public AccountMember GetAccountMemberById(string id);
        public bool CreateAccountMember(AccountMember account);
        public bool UpdateAccountMember(AccountMember account);
        public bool DeleteAccountMember(string id);
    }
}
