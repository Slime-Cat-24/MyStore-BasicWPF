using Business_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MyStore_DAOs
{
    public class AccountMemberDAO
    {
        private MyStoreContext _context;
        private static AccountMemberDAO instance;

        public static AccountMemberDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountMemberDAO();
                }
                return instance;
            }
        }
        private AccountMemberDAO()
        {
            _context = new MyStoreContext();
        }
        public List<AccountMember> GetAccountMembers()
        {
            return _context.AccountMembers.ToList();
        }
        public AccountMember GetAccountMemberById(string id)
        {
            return _context.AccountMembers.SingleOrDefault(m => m.MemberId.Equals(id));
        }
        public bool CreateAccountMember(AccountMember account)
        {
            try
            {
                _context.AccountMembers.Add(account);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteAccountMember(string id)
        {
            try
            {
                var member = GetAccountMemberById(id);
                if (member != null)
                {
                    _context.AccountMembers.Remove(member);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateAccountMember(AccountMember account)
        {
            try
            {
                var accountToUpdate = GetAccountMemberById(account.MemberId);
                if (accountToUpdate != null)
                {
                    _context.Entry<AccountMember> (accountToUpdate).State = EntityState.Modified;
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
