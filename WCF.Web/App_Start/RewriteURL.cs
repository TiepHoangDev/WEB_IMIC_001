using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WCF.Web.App_Start
{
    public static class StringHelpers
    {
        public static Random MYRANDOM = new Random();
        public static string SubString(string inputString, int length)
        {
            try
            {
                //Nếu chuỗi nhỏ hơn chiều dài cần cắt thì return về chính chuỗi truyền vào
                if (inputString.Length <= length)
                    return inputString;


                string strResult = string.Empty;
                int iEmptyIndex = 0;


                //Nếu chỉ có 1 từ --> ko cho cắt (vô nghĩa)
                iEmptyIndex = inputString.IndexOf(" ");
                if (iEmptyIndex != -1)
                {
                    //Cắt chuỗi yêu cầu
                    strResult = inputString.Substring(0, length);


                    //Tìm index của khoảng trắng kế bên chuổi cắt. Nếu là khoảng trắng --> return kết quả là strSplited.
                    //Ngược lại: cắt chuổi ký tự thừa của strSplited
                    iEmptyIndex = inputString.IndexOf(" ", length);
                    if (iEmptyIndex == length)
                        return strResult;
                    else
                    {
                        //strResult: Cộng hò --> Cộng
                        iEmptyIndex = strResult.LastIndexOf(" ");
                        if (iEmptyIndex != -1)
                        {
                            strResult = strResult.Substring(0, iEmptyIndex);
                        }
                    }
                }
                return strResult;
            }
            catch
            {
                return null;
            }
        }

        public static string ToRewireUrl(this string url)
        {
            // make the url lowercase
            string encodedUrl = (url ?? "").ToLower();

            // replace & with and
            encodedUrl = Regex.Replace(encodedUrl, @"\&+", "and");

            // remove characters
            encodedUrl = encodedUrl.Replace("'", "");

            // remove invalid characters
            encodedUrl = Regex.Replace(encodedUrl, @"[^a-z0-9]", "-");

            // remove duplicates
            encodedUrl = Regex.Replace(encodedUrl, @"-+", "-");

            // trim leading & trailing characters
            encodedUrl = encodedUrl.Trim('-');

            return encodedUrl;
        }

        public static String ToAscii(this String unicode)
        {
            unicode = unicode.ToLower();
            unicode = Regex.Replace(unicode, "[áàảãạăắằẳẵặâấầẩẫậ]", "a");
            unicode = Regex.Replace(unicode, "[óòỏõọôồốổỗộơớờởỡợ]", "o");
            unicode = Regex.Replace(unicode, "[éèẻẽẹêếềểễệ]", "e");
            unicode = Regex.Replace(unicode, "[íìỉĩịIÍĨÌỈĨ]", "i");
            unicode = Regex.Replace(unicode, "[úùủũụưứừửữự]", "u");
            unicode = Regex.Replace(unicode, "[ýỳỷỹỵ]", "y");
            unicode = Regex.Replace(unicode, "[đ]", "d");
            //unicode = Regex.Replace(unicode, "[-\\s+/]+", "-");
            unicode = Regex.Replace(unicode, "\\W+", "-");
            //Nếu bạn muốn thay dấu khoảng trắng thành dấu "_" hoặc dấu cách " " thì thay kí tự bạn muốn vào đấu "-"
            return unicode;
        }

        public static string GenerateURL(this string Title)
        {
            if (string.IsNullOrEmpty(Title))
                return "";
            Title = ToAscii(Title);
            string strTitle = Title.ToString();

            //#region Generate SEO Friendly URL based on Title

            strTitle = strTitle.Trim();
            strTitle = strTitle.Trim('-');

            strTitle = strTitle.ToLower();
            char[] chars = @"$%#@!*?;:~`+=()[]{}|\'<>,/^&"".".ToCharArray();
            strTitle = strTitle.Replace("c#", "C-Sharp");
            strTitle = strTitle.Replace("vb.net", "VB-Net");
            strTitle = strTitle.Replace("asp.net", "Asp-Net");
            strTitle = strTitle.Replace(".", "-");
            for (int i = 0; i < chars.Length; i++)
            {
                string strChar = chars.GetValue(i).ToString();
                if (strTitle.Contains(strChar))
                {
                    strTitle = strTitle.Replace(strChar, string.Empty);
                }
            }
            strTitle = strTitle.Replace(" ", "-");

            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("-----", "-");
            strTitle = strTitle.Replace("----", "-");
            strTitle = strTitle.Replace("---", "-");
            strTitle = strTitle.Replace("--", "-");
            strTitle = strTitle.Trim();

            return strTitle;
        }
        public static String FormatJSString(String input)
        {
            return input.Replace(',', ' ').Replace(' ', ' ');
        }
        public static String FormatDatetime(DateTime date)
        {
            String rs = "";
            DateTime today = DateTime.Now;
            if (date.Date == today.Date && today.Hour == date.Hour && today.Minute == date.Minute)
                rs = "Vừa xong";
            else if (date.Date == today.Date && today.Hour == date.Hour)
                rs = (today.Minute - date.Minute) + " phút trước";
            else if (date.Date == today.Date)
                rs = (today.Hour - date.Hour) + " giờ trước";
            else if ((today.Date - date.Date).Days < 7)
            {
                var culture = new System.Globalization.CultureInfo("vi-VN");
                var day = culture.DateTimeFormat.GetDayName(date.DayOfWeek);
                rs = day + " " + date.ToString("hh:mm");
            }
               
            else rs = date.ToString("dd/MM/yyyy hh:mm");
            return rs;
        }
    }
}