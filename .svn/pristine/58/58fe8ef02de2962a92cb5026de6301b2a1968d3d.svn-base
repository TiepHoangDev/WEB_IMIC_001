using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCF.BusinessObjectsLayer;
using WCF.BusinessObjectsLayer.EntityObjects;
using WCF.DataAccessLayer.Models;

namespace WCF.DataAccessLayer.Daos
{
    public class AccountDao
    {

        /*
         * Nghiệp vụ về tài khoản: Login, Register
         * NgocNB - 16082016
         */

        private static WebIMicEntities m_objDb = new WebIMicEntities();

        /*
         * Kiểm tra mail
         * NgocNB - 16082016
        */
        public static bool CheckMail(string sEmail)
        {
            var rs = m_objDb.WEB_IMIC_SP_Account_GetByEmail(sEmail).SingleOrDefault();
            if (rs != null) return true;
            return false;
        }

        /*
         * Kiểm tra facebookid
         * NgocNB - 16082016
        */
        public static AccountObject CheckFacebookId(string sFacebookId)
        {
            var rs = m_objDb.WEB_IMIC_SP_Account_GetByFacebookId(sFacebookId).SingleOrDefault();

            if (rs != null) return new AccountObject
            {
                AccountId = rs.AccountId,
                Birthday = rs.Birthday + "",
                Email = rs.Email,
                FacebookId = rs.FacebookId,
                FullName = rs.FullName,
                Gender = rs.Gender,
                GoogleId = rs.GoogleId,
                ImageAvatar = rs.ImageAvatar,
                IsActived = rs.IsActived,
                LastLoginTime = rs.LastLoginTime + "",
                ModifiedBy = rs.ModifiedBy,
                ModifiedTime = rs.ModifiedTime + "",
                Password = rs.Password,
                Phone = rs.Phone,
                RoleId = rs.RoleId,
                TotalOfArtice = rs.TotalOfArtice,
                TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
                Username = rs.Username
            };

            return null;
        }

        /*
         * Kiểm tra googleid
         * NgocNB 18092016
         */
        public static AccountObject CheckGoogleId(string sGoogleId)
        {
            var rs = m_objDb.WEB_IMIC_SP_Account_GetByGoogleId(sGoogleId).SingleOrDefault();

            if (rs != null) return new AccountObject
            {
                AccountId = rs.AccountId,
                Birthday = rs.Birthday + "",
                Email = rs.Email,
                FacebookId = rs.FacebookId,
                FullName = rs.FullName,
                Gender = rs.Gender,
                GoogleId = rs.GoogleId,
                ImageAvatar = rs.ImageAvatar,
                IsActived = rs.IsActived,
                LastLoginTime = rs.LastLoginTime + "",
                ModifiedBy = rs.ModifiedBy,
                ModifiedTime = rs.ModifiedTime + "",
                Password = rs.Password,
                Phone = rs.Phone,
                RoleId = rs.RoleId,
                TotalOfArtice = rs.TotalOfArtice,
                TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
                Username = rs.Username
            };

            return null;
        }

        /*
         * Check login tk thường
         * NgocNB - 18092016
         */
        public static AccountObject CheckLogin(AccountObject objAccount)
        {
            objAccount.Password = new EncodeMD5().EncodingMD5(objAccount.Password);
            var rs = m_objDb.WEB_IMIC_SP_Account_CheckLogin(objAccount.Username, objAccount.Password).SingleOrDefault();

            if (rs != null) return new AccountObject
            {
                AccountId = rs.AccountId,
                Birthday = rs.Birthday + "",
                Email = rs.Email,
                FacebookId = rs.FacebookId,
                FullName = rs.FullName,
                Gender = rs.Gender,
                GoogleId = rs.GoogleId,
                ImageAvatar = rs.ImageAvatar,
                IsActived = rs.IsActived,
                LastLoginTime = rs.LastLoginTime + "",
                ModifiedBy = rs.ModifiedBy,
                ModifiedTime = rs.ModifiedTime + "",
                Password = rs.Password,
                Phone = rs.Phone,
                RoleId = rs.RoleId,
                TotalOfArtice = rs.TotalOfArtice,
                TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
                Username = rs.Username
            };

            return null;
        }

        /*
         * Tạo mới tài khoản
         * NgocNB - 18102016
         */
        public static bool CreateAccount(AccountObject objAccount)
        {
            if (!string.IsNullOrEmpty(objAccount.Birthday))
            {
                // nếu string birthday not null
                DateTime birthday = DateTime.ParseExact(objAccount.Birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                m_objDb.WEB_IMIC_SP_Account_Create(objAccount.AccountId, objAccount.RoleId, objAccount.Username, objAccount.Password, objAccount.ImageAvatar, objAccount.FullName, objAccount.Gender, objAccount.Email, objAccount.Phone,
                birthday, objAccount.FacebookId, objAccount.GoogleId, DateTime.Now);
            }
            else
            {
                // nếu không có birthday
                m_objDb.WEB_IMIC_SP_Account_Create(objAccount.AccountId, objAccount.RoleId, objAccount.Username, objAccount.Password, objAccount.ImageAvatar, objAccount.FullName, objAccount.Gender, objAccount.Email, objAccount.Phone,
                null, objAccount.FacebookId, objAccount.GoogleId, DateTime.Now);
            }

            return true;
        }

        /*
         * Login
         * NgocNB - 15102016
         */
        public int Login(LoginObject objLogin, bool isLoginAdmin = false)
        {
            using (var dbContext = new WebIMicEntities())
            {

                var rs = dbContext.WEB_IMIC_SP_Account_GetByUsername(objLogin.Username).SingleOrDefault();
                if (rs == null)
                {
                    return 0; // Tk ko ton tai
                }
                else
                {
                    if (isLoginAdmin)
                    {
                        // Kiem tra xem co phai tk admin ko
                        // coding more
                        //rs.Password = new EncodeMD5().EncodingMD5(rs.Password);
                        if (new EncodeMD5().EncodingMD5(objLogin.Password).Equals(rs.Password))
                            return 1; // Dang nhap thanh cong
                        else
                            return -2; // Mat khau khong dung

                    }
                    else
                    {
                        // Dang nhap phia client
                        return -1;
                    }
                }
            }
        }
        public AccountObject getAccountByID(object id)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var rs in db.WEB_IMIC_SP_tbl_Account_getByID(Guid.Parse(id + "")))
            {
                return new AccountObject
                {
                    AccountId = rs.AccountId,
                    Birthday = rs.Birthday + "",
                    Email = rs.Email,
                    FacebookId = rs.FacebookId,
                    FullName = rs.FullName,
                    Gender = rs.Gender,
                    GoogleId = rs.GoogleId,
                    ImageAvatar = rs.ImageAvatar,
                    IsActived = rs.IsActived,
                    LastLoginTime = rs.LastLoginTime + "",
                    ModifiedBy = rs.ModifiedBy,
                    ModifiedTime = rs.ModifiedTime + "",
                    Password = rs.Password,
                    Phone = rs.Phone,
                    RoleId = rs.RoleId,
                    TotalOfArtice = rs.TotalOfArtice,
                    TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
                    Username = rs.Username,
                    IsDeleted = rs.IsDeleted
                };
            }
            return null;
        }
        public AccountObject getLoginAccount(string username, string password)
        {
            WebIMicEntities db = new WebIMicEntities();
            password = new EncodeMD5().EncodingMD5(password);
            foreach (var rs in db.WEB_IMIC_SP_getUserWhenLogin(username, password))
            {
                return new AccountObject
                {
                    AccountId = rs.AccountId,
                    Birthday = rs.Birthday + "",
                    Email = rs.Email,
                    FacebookId = rs.FacebookId,
                    FullName = rs.FullName,
                    Gender = rs.Gender,
                    GoogleId = rs.GoogleId,
                    ImageAvatar = rs.ImageAvatar,
                    IsActived = rs.IsActived,
                    LastLoginTime = rs.LastLoginTime + "",
                    ModifiedBy = rs.ModifiedBy,
                    ModifiedTime = rs.ModifiedTime + "",
                    Password = rs.Password,
                    Phone = rs.Phone,
                    RoleId = rs.RoleId,
                    TotalOfArtice = rs.TotalOfArtice,
                    TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
                    Username = rs.Username
                };
            }
            return null;
        }
        public List<AccountObject> getElements()
        {
            WebIMicEntities db = new WebIMicEntities();
            List<AccountObject> lstAccount = new List<AccountObject>();
            foreach (var i in db.WEB_IMIC_SP_Account_GetAll())
            {
                AccountObject objAccount = new AccountObject();
                objAccount.AccountId = i.AccountId;
                objAccount.RoleId = i.RoleId;
                objAccount.Username = i.Username;
                objAccount.Password = i.Password;
                objAccount.ImageAvatar = i.ImageAvatar;
                objAccount.FullName = i.FullName;
                objAccount.Gender = i.Gender;
                objAccount.Email = i.Email;
                objAccount.Phone = i.Phone;
                objAccount.Birthday = i.Birthday.ToString();
                objAccount.FacebookId = i.FacebookId;
                objAccount.GoogleId = i.GoogleId;
                objAccount.IsActived = i.IsActived;
                objAccount.TotalOfArtice = i.TotalOfArtice;
                objAccount.TotalOfBeLikedArtice = i.TotalOfBeLikedArtice;
                objAccount.LastLoginTime = i.LastLoginTime.ToString();
                objAccount.ModifiedBy = i.ModifiedBy.GetValueOrDefault();
                objAccount.ModifiedTime = i.ModifiedTime.ToString();
                objAccount.objRole = new RoleDao().GetByID(objAccount.RoleId);
                lstAccount.Add(objAccount);
            }
            return lstAccount;
        }
        public List<AccountObject> getByRoleId(object id)
        {
            WebIMicEntities db = new WebIMicEntities();
            List<AccountObject> lstAccount = new List<AccountObject>();
            foreach (var i in db.WEB_IMIC_SP_Account_GetByRoleID(byte.Parse(id + "")))
            {
                AccountObject objAccount = new AccountObject();
                objAccount.AccountId = i.AccountId;
                objAccount.RoleId = i.RoleId;
                objAccount.Username = i.Username;
                objAccount.Password = i.Password;
                objAccount.ImageAvatar = i.ImageAvatar;
                objAccount.FullName = i.FullName;
                objAccount.Gender = i.Gender;
                objAccount.Email = i.Email;
                objAccount.Phone = i.Phone;
                objAccount.Birthday = i.Birthday.ToString();
                objAccount.FacebookId = i.FacebookId;
                objAccount.GoogleId = i.GoogleId;
                objAccount.IsActived = i.IsActived;
                objAccount.TotalOfArtice = i.TotalOfArtice;
                objAccount.TotalOfBeLikedArtice = i.TotalOfBeLikedArtice;
                objAccount.LastLoginTime = i.LastLoginTime.ToString();
                objAccount.ModifiedBy = i.ModifiedBy.GetValueOrDefault();
                objAccount.ModifiedTime = i.ModifiedTime.ToString();
                lstAccount.Add(objAccount);
            }
            return lstAccount;
        }
        public void addElements(AccountObject objAccount)
        {
            WebIMicEntities db = new WebIMicEntities();
            if (!string.IsNullOrEmpty(objAccount.Birthday))
            {
                // nếu string birthday not null
                DateTime birthday = DateTime.ParseExact(objAccount.Birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                db.WEB_IMIC_SP_Account_Update1(objAccount.AccountId, objAccount.RoleId, objAccount.Username, objAccount.Password, objAccount.ImageAvatar,
                    objAccount.FullName, objAccount.Gender, objAccount.Email, objAccount.Phone, birthday, objAccount.FacebookId,
                    objAccount.GoogleId, objAccount.IsActived, objAccount.TotalOfArtice, objAccount.TotalOfBeLikedArtice, DateTime.Parse(objAccount.LastLoginTime),
                    objAccount.ModifiedBy, DateTime.Parse(objAccount.ModifiedTime), objAccount.IsDeleted, false);
            }
            else
            {
                // nếu không có birthday
                db.WEB_IMIC_SP_Account_Update1(objAccount.AccountId, objAccount.RoleId, objAccount.Username, objAccount.Password, objAccount.ImageAvatar,
                    objAccount.FullName, objAccount.Gender, objAccount.Email, objAccount.Phone, null, objAccount.FacebookId,
                    objAccount.GoogleId, objAccount.IsActived, objAccount.TotalOfArtice, objAccount.TotalOfBeLikedArtice, Convert.ToDateTime(objAccount.LastLoginTime),
                    objAccount.ModifiedBy, Convert.ToDateTime(objAccount.ModifiedTime), objAccount.IsDeleted, false);
            }
            //db.WEB_IMIC_SP_Account_Update1(objAccount.AccountId,objAccount.RoleId,objAccount.Username,objAccount.Password,objAccount.ImageAvatar,
            //        objAccount.FullName,objAccount.Gender,objAccount.Email,objAccount.Phone, DateTime.Parse(objAccount.Birthday),objAccount.FacebookId,
            //        objAccount.GoogleId, objAccount.IsActived, objAccount.TotalOfArtice, objAccount.TotalOfBeLikedArtice, DateTime.Parse(objAccount.LastLoginTime),
            //        objAccount.ModifiedBy, DateTime.Parse(objAccount.ModifiedTime), objAccount.IsDeleted, false);
            db.SaveChanges();
        }
        public void updateElements(AccountObject objAccount)
        {
            WebIMicEntities db = new WebIMicEntities();
            if (!string.IsNullOrEmpty(objAccount.Birthday))
            {
                // nếu string birthday not null
                DateTime birthday = DateTime.ParseExact(objAccount.Birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                db.WEB_IMIC_SP_Account_Update1(objAccount.AccountId, objAccount.RoleId, objAccount.Username, objAccount.Password, objAccount.ImageAvatar,
                    objAccount.FullName, objAccount.Gender, objAccount.Email, objAccount.Phone, birthday, objAccount.FacebookId,
                    objAccount.GoogleId, objAccount.IsActived, objAccount.TotalOfArtice, objAccount.TotalOfBeLikedArtice, DateTime.Parse(objAccount.LastLoginTime),
                    objAccount.ModifiedBy, DateTime.Parse(objAccount.ModifiedTime), objAccount.IsDeleted, true);
            }
            else
            {
                // nếu không có birthday
                db.WEB_IMIC_SP_Account_Update1(objAccount.AccountId, objAccount.RoleId, objAccount.Username, objAccount.Password, objAccount.ImageAvatar,
                    objAccount.FullName, objAccount.Gender, objAccount.Email, objAccount.Phone, null, objAccount.FacebookId,
                    objAccount.GoogleId, objAccount.IsActived, objAccount.TotalOfArtice, objAccount.TotalOfBeLikedArtice, Convert.ToDateTime(objAccount.LastLoginTime),
                    objAccount.ModifiedBy, Convert.ToDateTime(objAccount.ModifiedTime), objAccount.IsDeleted, true);
            }
            db.SaveChanges();
        }
        public void deleteElement(Guid id)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_Account_Delete(id);
        }

        public bool Change_Password(Guid AccountID, string Password)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_Account_ChangePassword(AccountID, Password);
            return true;
        }
        public bool Change_Avatar(Guid AccountID, string ImageAvatar)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_Account_ChangeAvatar(AccountID, ImageAvatar);
            return true;
        }

        //    /*
        //     * Nghiệp vụ về tài khoản: Login, Register
        //     * NgocNB - 16082016
        //     */

        //    private static WebIMicEntities m_objDb = new WebIMicEntities();

        //    /*
        //     * Kiểm tra mail
        //     * NgocNB - 16082016
        //    */
        //    public static bool CheckMail(string sEmail)
        //    {
        //        var rs = m_objDb.WEB_IMIC_SP_Account_GetByEmail(sEmail).SingleOrDefault();
        //        if (rs != null) return true;
        //        return false;
        //    }

        //    /*
        //     * Kiểm tra facebookid
        //     * NgocNB - 16082016
        //    */
        //    public static AccountObject CheckFacebookId(string sFacebookId)
        //    {
        //        var rs = m_objDb.WEB_IMIC_SP_Account_GetByFacebookId(sFacebookId).SingleOrDefault();

        //        if (rs != null) return new AccountObject
        //        {
        //            AccountId = rs.AccountId,
        //            Birthday = rs.Birthday + "",
        //            Email = rs.Email,
        //            FacebookId = rs.FacebookId,
        //            FullName = rs.FullName,
        //            Gender = rs.Gender,
        //            GoogleId = rs.GoogleId,
        //            ImageAvatar = rs.ImageAvatar,
        //            IsActived = rs.IsActived,
        //            LastLoginTime = rs.LastLoginTime + "",
        //            ModifiedBy = rs.ModifiedBy,
        //            ModifiedTime = rs.ModifiedTime + "",
        //            Password = rs.Password,
        //            Phone = rs.Phone,
        //            RoleId = rs.RoleId,
        //            TotalOfVideo = rs.TotalOfVideo,
        //            TotalOfArtice = rs.TotalOfArtice,
        //            TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
        //            Username = rs.Username
        //        };

        //        return null;
        //    }

        //    /*
        //     * Kiểm tra googleid
        //     * NgocNB 18092016
        //     */
        //    public static AccountObject CheckGoogleId(string sGoogleId)
        //    {
        //        var rs = m_objDb.WEB_IMIC_SP_Account_GetByGoogleId(sGoogleId).SingleOrDefault();

        //        if (rs != null) return new AccountObject
        //        {
        //            AccountId = rs.AccountId,
        //            Birthday = rs.Birthday + "",
        //            Email = rs.Email,
        //            FacebookId = rs.FacebookId,
        //            FullName = rs.FullName,
        //            Gender = rs.Gender,
        //            GoogleId = rs.GoogleId,
        //            ImageAvatar = rs.ImageAvatar,
        //            IsActived = rs.IsActived,
        //            LastLoginTime = rs.LastLoginTime + "",
        //            ModifiedBy = rs.ModifiedBy,
        //            ModifiedTime = rs.ModifiedTime + "",
        //            Password = rs.Password,
        //            Phone = rs.Phone,
        //            RoleId = rs.RoleId,
        //            TotalOfVideo = rs.TotalOfVideo,
        //            TotalOfArtice = rs.TotalOfArtice,
        //            TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
        //            Username = rs.Username
        //        };

        //        return null;
        //    }

        //    /*
        //     * Check login tk thường
        //     * NgocNB - 18092016
        //     */
        //    public static AccountObject CheckLogin(AccountObject objAccount)
        //    {
        //        var rs = m_objDb.WEB_IMIC_SP_Account_CheckLogin(objAccount.Username, objAccount.Password).SingleOrDefault();

        //        if (rs != null) return new AccountObject
        //        {
        //            AccountId = rs.AccountId,
        //            Birthday = rs.Birthday + "",
        //            Email = rs.Email,
        //            FacebookId = rs.FacebookId,
        //            FullName = rs.FullName,
        //            Gender = rs.Gender,
        //            GoogleId = rs.GoogleId,
        //            ImageAvatar = rs.ImageAvatar,
        //            IsActived = rs.IsActived,
        //            LastLoginTime = rs.LastLoginTime + "",
        //            ModifiedBy = rs.ModifiedBy,
        //            ModifiedTime = rs.ModifiedTime + "",
        //            Password = rs.Password,
        //            Phone = rs.Phone,
        //            RoleId = rs.RoleId,
        //            TotalOfVideo = rs.TotalOfVideo,
        //            TotalOfArtice = rs.TotalOfArtice,
        //            TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
        //            Username = rs.Username
        //        };

        //        return null;
        //    }

        //    /*
        //     * Tạo mới tài khoản
        //     * NgocNB - 18102016
        //     */
        //    public static bool CreateAccount(AccountObject objAccount)
        //    {
        //        if (!string.IsNullOrEmpty(objAccount.Birthday))
        //        {
        //            // nếu string birthday not null
        //            DateTime birthday = DateTime.ParseExact(objAccount.Birthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);

        //            m_objDb.WEB_IMIC_SP_Account_Create(objAccount.AccountId, objAccount.RoleId, objAccount.Username, objAccount.Password, objAccount.ImageAvatar, objAccount.FullName, objAccount.Gender, objAccount.Email, objAccount.Phone,
        //            birthday, objAccount.FacebookId, objAccount.GoogleId, DateTime.Now);
        //        }
        //        else
        //        {
        //            // nếu không có birthday
        //            m_objDb.WEB_IMIC_SP_Account_Create(objAccount.AccountId, objAccount.RoleId, objAccount.Username, objAccount.Password, objAccount.ImageAvatar, objAccount.FullName, objAccount.Gender, objAccount.Email, objAccount.Phone,
        //            null, objAccount.FacebookId, objAccount.GoogleId, DateTime.Now);
        //        }

        //        return true;
        //    }

        //    /*
        //     * Login
        //     * NgocNB - 15102016
        //     */
        //    public int Login(LoginObject objLogin, bool isLoginAdmin = false)
        //    {
        //        using (var dbContext = new WebIMicEntities())
        //        {
        //            var rs = dbContext.WEB_IMIC_SP_Account_GetByUsername(objLogin.Username).SingleOrDefault();
        //            if (rs == null)
        //            {
        //                return 0; // Tk ko ton tai
        //            }
        //            else
        //            {
        //                if (isLoginAdmin)
        //                {
        //                    // Kiem tra xem co phai tk admin ko
        //                    // coding more

        //                    if (objLogin.Password.Equals(rs.Password))
        //                        return 1; // Dang nhap thanh cong
        //                    else
        //                        return -2; // Mat khau khong dung

        //                }
        //                else
        //                {
        //                    // Dang nhap phia client
        //                    return -1; 
        //                }
        //            }
        //        }
        //    }
        //    public AccountObject getAccountByID(object id)
        //    {
        //        WebIMicEntities db = new WebIMicEntities();
        //        foreach (var rs in db.WEB_IMIC_SP_tbl_Account_getByID(Guid.Parse(id + "")))
        //        {
        //            return new AccountObject
        //            {
        //                AccountId = rs.AccountId,
        //                Birthday = rs.Birthday + "",
        //                Email = rs.Email,
        //                FacebookId = rs.FacebookId,
        //                FullName = rs.FullName,
        //                Gender = rs.Gender,
        //                GoogleId = rs.GoogleId,
        //                ImageAvatar = rs.ImageAvatar,
        //                IsActived = rs.IsActived,
        //                LastLoginTime = rs.LastLoginTime + "",
        //                ModifiedBy = rs.ModifiedBy,
        //                ModifiedTime = rs.ModifiedTime + "",
        //                Password = rs.Password,
        //                Phone = rs.Phone,
        //                RoleId = rs.RoleId,
        //                TotalOfArtice = rs.TotalOfArtice,
        //                TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
        //                Username = rs.Username
        //            };
        //        }
        //        return null;
        //    }
        //public AccountObject getLoginAccount(string username, string password)
        //{
        //    WebIMicEntities db = new WebIMicEntities();
        //    foreach (var rs in db.WEB_IMIC_SP_getUserWhenLogin(username, password))
        //    {
        //        return new AccountObject
        //        {
        //            AccountId = rs.AccountId,
        //            Birthday = rs.Birthday + "",
        //            Email = rs.Email,
        //            FacebookId = rs.FacebookId,
        //            FullName = rs.FullName,
        //            Gender = rs.Gender,
        //            GoogleId = rs.GoogleId,
        //            ImageAvatar = rs.ImageAvatar,
        //            IsActived = rs.IsActived,
        //            LastLoginTime = rs.LastLoginTime + "",
        //            ModifiedBy = rs.ModifiedBy,
        //            ModifiedTime = rs.ModifiedTime + "",
        //            Password = rs.Password,
        //            Phone = rs.Phone,
        //            RoleId = rs.RoleId,
        //            TotalOfArtice = rs.TotalOfArtice,
        //            TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
        //            Username = rs.Username
        //        };
        //    }
        //    return null;
        //}
        public AccountObject getByUsername(string Username)
        {
            WebIMicEntities db = new WebIMicEntities();
            foreach (var rs in db.WEB_IMIC_SP_Account_GetByUsername(Username))
            {
                return new AccountObject
                {
                    AccountId = rs.AccountId,
                    Birthday = rs.Birthday + "",
                    Email = rs.Email,
                    FacebookId = rs.FacebookId,
                    FullName = rs.FullName,
                    Gender = rs.Gender,
                    GoogleId = rs.GoogleId,
                    ImageAvatar = rs.ImageAvatar,
                    IsActived = rs.IsActived,
                    LastLoginTime = rs.LastLoginTime + "",
                    ModifiedBy = rs.ModifiedBy,
                    ModifiedTime = rs.ModifiedTime + "",
                    Password = rs.Password,
                    Phone = rs.Phone,
                    RoleId = rs.RoleId,
                    TotalOfVideo = rs.TotalOfVideo,
                    TotalOfArtice = rs.TotalOfArtice,
                    TotalOfBeLikedArtice = rs.TotalOfBeLikedArtice,
                    Username = rs.Username
                };
            }
            return null;
        }

        public bool Update_Information(Guid AccountID, string FullName, string Email, string Phone, DateTime Birthday, bool Gender)
        {
            WebIMicEntities db = new WebIMicEntities();
            db.WEB_IMIC_SP_Account_UpdateInformation(AccountID, FullName, Email, Phone, Birthday, Gender);
            return true;
        }


    }
}

