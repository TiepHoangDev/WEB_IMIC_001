using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Daos;

namespace WCF.BusinessControlLayer.Bcls
{
    public class AccountBcl
    {
        /*
         * Nghiệp vụ về tài khoản
         * NgocNB - 16092016
         */

        public static AccountObject CheckFacebookId(string sFacebookId)
        {
            return AccountDao.CheckFacebookId(sFacebookId);
        }


        public static bool CheckEmail(string sEmail)
        {
            return AccountDao.CheckMail(sEmail);
        }

        public static bool CreateAccount(AccountObject objAccount)
        {
            return AccountDao.CreateAccount(objAccount);
        }

        public static AccountObject CheckGoogleId(string sGoogleId)
        {
            return AccountDao.CheckGoogleId(sGoogleId);
        }

        public AccountObject CheckLogin(AccountObject objAccount)
        {
            return AccountDao.CheckLogin(objAccount);
        }

        public static int Login(LoginObject objLogin, bool isLoginAdmin = false)
        {
            return new AccountDao().Login(objLogin, isLoginAdmin);
        }

        public AccountObject getLoginAccount(string username, string password)
        {
            return new AccountDao().getLoginAccount(username, password);
        }

        public List<AccountObject> getElement()
        {
            return new AccountDao().getElements();
        }

        public AccountObject getElementById(object id)
        {
            return new AccountDao().getAccountByID(id);
        }

        public void deleteElement(Guid id)
        {
            new AccountDao().deleteElement(id);
        }

        public List<AccountObject> getByRoleID(object id)
        {
            return new AccountDao().getByRoleId(id);
        }

        public void addElements(AccountObject objAccount)
        {
            new AccountDao().addElements(objAccount);
        }

        public void updateElements(AccountObject objAccount)
        {
            new AccountDao().updateElements(objAccount);
        }

        //    public static AccountObject CheckFacebookId(string sFacebookId)
        //    {
        //        return AccountDao.CheckFacebookId(sFacebookId);
        //    }


        //    public static bool CheckEmail(string sEmail)
        //    {
        //        return AccountDao.CheckMail(sEmail);
        //    }

        //    public static bool CreateAccount(AccountObject objAccount)
        //    {
        //        return AccountDao.CreateAccount(objAccount);
        //    }

        //    public static AccountObject CheckGoogleId(string sGoogleId)
        //    {
        //        return AccountDao.CheckGoogleId(sGoogleId);
        //    }

        //    public static AccountObject CheckLogin(AccountObject objAccount)
        //    {
        //        return AccountDao.CheckLogin(objAccount);
        //    }

        //    public static int Login(LoginObject objLogin, bool isLoginAdmin = false)
        //    {
        //        return new AccountDao().Login(objLogin, isLoginAdmin);
        //    }
        //    public AccountObject getLoginAccount(string username, string password)
        //    {
        //        return new AccountDao().getLoginAccount(username, password);
        //    }
        public AccountObject getAccountByID(Guid AccountID)
        {
            return new AccountDao().getAccountByID(AccountID);
        }
        public AccountObject getByUsername(string Username)
        {
            return new AccountDao().getByUsername(Username);
        }
        public bool Update_Information(Guid AccountID, string FullName, string Email, string Phone, DateTime Birthday, bool Gender)
        {
            return new AccountDao().Update_Information(AccountID, FullName, Email, Phone, Birthday, Gender);
        }
        public bool Change_Password(Guid AccountID, string Password)
        {
            return new AccountDao().Change_Password(AccountID, Password);
        }
        public bool Change_Avatar(Guid AccountID, string ImageAvatar)
        {
            return new AccountDao().Change_Avatar(AccountID, ImageAvatar);
        }
    }
    //}

}
