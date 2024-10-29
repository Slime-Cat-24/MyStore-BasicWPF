using Business_Objects;
using MyStore_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Repositories
{
    public class AccountMemberRepo : IAccountMemberRepo
    {
        public bool CreateAccountMember(AccountMember account)
        {
            return AccountMemberDAO.Instance.CreateAccountMember(account);
        }

        public bool DeleteAccountMember(string id)
        {
            return AccountMemberDAO.Instance.DeleteAccountMember(id);
        }

        public AccountMember GetAccountMemberById(string id)
        {
            return AccountMemberDAO.Instance.GetAccountMemberById(id);
        }

        public List<AccountMember> GetAccountMembers()
        {
            return AccountMemberDAO.Instance.GetAccountMembers();
        }

        public bool UpdateAccountMember(AccountMember account)
        {
            return AccountMemberDAO.Instance.UpdateAccountMember(account);
        }
    }
}
