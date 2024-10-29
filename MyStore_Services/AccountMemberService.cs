using Business_Objects;
using MyStore_DAOs;
using MyStore_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore_Services
{
    public class AccountMemberService : IAccountMemberService
    {
        private readonly IAccountMemberRepo accountMemberRepo;
        public AccountMemberService()
        {
            accountMemberRepo = new AccountMemberRepo();
        }
        public bool CreateAccountMember(AccountMember account)
        {
            return accountMemberRepo.CreateAccountMember(account);
        }

        public bool DeleteAccountMember(string id)
        {
            return accountMemberRepo.DeleteAccountMember(id);
        }

        public AccountMember GetAccountMemberById(string id)
        {
            return accountMemberRepo.GetAccountMemberById(id);
        }

        public List<AccountMember> GetAccountMembers()
        {
            return accountMemberRepo.GetAccountMembers();
        }

        public bool UpdateAccountMember(AccountMember account)
        {
            return accountMemberRepo.UpdateAccountMember(account);
        }
    }
}
