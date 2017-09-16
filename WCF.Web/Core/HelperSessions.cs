using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCF.BusinessObjectsLayer.EntityObjects;

namespace WCF.Web.Core
{
    public class HelperSessions
    {
        /*
         * Các xử lý session
         * NgocNB - 18092016
         */

        public static void SetSession(AccountObject objAccount)
        {
            HttpContext.Current.Session["S_AccountInfo"] = objAccount;
        }

        public static AccountObject GetSession()
        {
            var session = HttpContext.Current.Session["S_AccountInfo"];
            if (session == null) return null;
            return (AccountObject)session;
        }
    }
}