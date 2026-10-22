using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AirLeakageTesting.uitls
{
    public static class ConvertUtils
    {
        /// <summary>
        /// 16进制string转为byte[]
        /// </summary>
        /// <param name="hexStr"></param>
        /// <returns></returns>
        public static byte[] HexStringToBytes(string hexStr)
        {
            hexStr = hexStr.Replace(" ", "");
            if (Regex.IsMatch(hexStr, "[^0-9a-fA-F].*"))
            {
                Trace.WriteLine("不符合十六进制格式要求[0-9a-fA-F]!");
                return null;
            }

            int byteCnt = (int)Math.Ceiling((double)hexStr.Length / 2);
            Byte[] cmdByte = new Byte[byteCnt];

            for (int i = 0; i < hexStr.Length / 2; i++)
            {
                cmdByte[i] = Convert.ToByte(hexStr.Substring(i * 2, 2), 16);
                //Trace.WriteLine(">>" + cmdByte[i]);
            }
            return cmdByte;
        }

        /// <summary>
        /// 字符串转ASSIC字符串
        /// </summary>
        /// <param name="strTmp"></param>
        /// <returns></returns>
        public static string StringToHexstring(string strTmp)
        {
            string outRes = "";
            char[] values = strTmp.ToCharArray();
            foreach (char letter in values)
            {
                int value = Convert.ToInt32(letter);
                string hexOutput = String.Format("{0:X}", value);
                outRes += hexOutput;
            }
            return outRes;
        }

        /// <summary>
        /// ASCII转字符
        /// </summary>
        /// <param name="asciiCode"></param>
        /// <returns></returns>
        public static string Ascii2Str(int asciiCode)
        {
            //不处理等于0的，否则会卡主不返回
            if (asciiCode > 0 && asciiCode <= 255)
            {
                System.Text.ASCIIEncoding asciiEncoding = new System.Text.ASCIIEncoding();
                byte[] byteArray = new byte[] { (byte)asciiCode };
                string strCharacter = asciiEncoding.GetString(byteArray);
                return (strCharacter);
            }
            else
            {
                //Console.WriteLine("不能处理的Ascii值："+ asciiCode,false);
                return "";
            }
        }

        /// <summary>
        /// 从string中提取json格式的string内容
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetJsonString(string str)
        {
            string patern = "({[^{}]*(?:(?:(?'Open'{)[^{}]*)+(?:(?'-Open'})[^{}]*)+)*(?(Open)(?!))})";
            Regex regRes = new Regex(patern, RegexOptions.Multiline);//
            MatchCollection regMatch = regRes.Matches(str);
            string resReturn = "";
            foreach (Match m in regMatch)
            {
                resReturn = m.Groups[0].Value;
            }
            return resReturn;
        }

        /// <summary>
        /// 比较两个byte数组是否完全相等
        /// </summary>
        /// <param name="b1"></param>
        /// <param name="b2"></param>
        /// <returns></returns>
        public static bool BytesContains(byte[] b1, byte[] b2)
        {
            if (b1 == null || b2 == null) return false;
            string b1Str = BitConverter.ToString(b1).Replace("-", "");
            string b2Str = BitConverter.ToString(b2).Replace("-", "");

            if (b1Str.Contains(b2Str))
            {
                return true;
            }
            else
            {
                Trace.WriteLine("b1St>>>" + b1Str + "<<<");
                Trace.WriteLine("b2Str>>>" + b2Str + "<<<");
                return false;
            }
        }

        ///<summary>
        /// 移除前缀字符串
        ///</summary>
        ///<param name="val">原字符串</param>
        ///<param name="str">前缀字符串</param>
        ///<returns></returns>
        public static string GetRemovePrefixString(string val, string str)
        {
            string strRegex = @"^(" + str + ")";
            return Regex.Replace(val, strRegex, "");
        }
    }
}
