using System;
using System.Collections;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace AirLeakageTesting.uitls
{
    public static class UrlHelper
    {
        /// <summary>
        /// 获取上一个工位的测试结果 URL
        /// </summary>
        private static string GetPreStationURL = "/box_cms_v3/mes_v1/getDutTestFlowResult.php?";
        /// <summary>
        /// 获取上一个工位的测试结果
        /// </summary>
        /// <param name="ParamaterNamesKeys"></param>
        /// <returns></returns>
        public static string GetPreStation(string serverIP, Hashtable ParamaterNamesKeys)
        {
            try
            {
                string url = "http://" + serverIP;
                url += GetPreStationURL;
                url += GetParamaters(ParamaterNamesKeys);
                Trace.WriteLine("GetPreStation：url=" + url);
                FormMain.myLog.Info("GetPreStation：url=" + url);
                string result = (new MyWebClient()).HttpGet(url);
                Trace.WriteLine("GetPreStation：result=" + result);
                FormMain.myLog.Info("GetPreStation：result=" + result);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("GetPreStation：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("GetPreStation：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                return string.Empty;
            }
        }


        private static string GetStationStatuURL = "/box_cms_v3/mes_v1/getDutStationInfo.php?";
        public static string GetStationStatu(string serverIP, Hashtable ParamaterNamesKeys)
        {
            try
            {
                string url = "http://" + serverIP;
                url += GetStationStatuURL;
                url += GetParamaters(ParamaterNamesKeys);
                Trace.WriteLine("GetPreStation：url=" + url);
                FormMain.myLog.Info("GetPreStation：url=" + url);
                string result = (new MyWebClient()).HttpGet(url);
                Trace.WriteLine("GetPreStation：result=" + result);
                FormMain.myLog.Info("GetPreStation：result=" + result);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("GetPreStation：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("GetPreStation：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 获取字段的信息 URL
        /// </summary>
        private static string GetFieldsInfoURL = "/box_cms_v3/mes_v1/getDutFields.php?";
        /// <summary>
        /// 获取字段的信息
        /// </summary>
        /// <param name="ParamaterNamesKeys"></param>
        /// <returns></returns>
        public static string GetFieldsInfo(string serverIP, Hashtable ParamaterNamesKeys)
        {
            try
            {
                string url = "http://" + serverIP;
                url += GetFieldsInfoURL;
                url += GetParamaters(ParamaterNamesKeys);
                Trace.WriteLine("GetFieldsInfo：url=" + url);
                FormMain.myLog.Info("GetFieldsInfo：url=" + url);
                string result = (new MyWebClient()).HttpGet(url);
                Trace.WriteLine("GetFieldsInfo：result=" + result);
                FormMain.myLog.Info("GetFieldsInfo：result=" + result);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("GetFieldsInfo：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("GetFieldsInfo：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 绑定字段信息 URL
        /// </summary>
        private static string BindFieldsURL = "/box_cms_v3/mes_v1/bindDutFields.php?";
        /// <summary>
        /// 绑定字段信息
        /// </summary>
        /// <param name="ParamaterNamesKeys"></param>
        /// <returns></returns>
        public static string BindFields(string serverIP, Hashtable ParamaterNamesKeys)
        {
            try
            {
                string url = "http://" + serverIP;
                url += BindFieldsURL;
                url += GetParamaters(ParamaterNamesKeys);
                Trace.WriteLine("BindFields：url=" + url);
                FormMain.myLog.Info("BindFields：url=" + url);
                string result = (new MyWebClient()).HttpGet(url);
                Trace.WriteLine("BindFields：result=" + result);
                FormMain.myLog.Info("BindFields：result=" + result);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("BindFields：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("BindFields：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 上传工站TAG URL
        /// </summary>
        private static string UploadTagURL = "/box_cms_v3/mes_v1/postTestDataStr.php?";
        /// <summary>
        /// 上传工站TAG
        /// </summary>
        /// <param name="ParamaterNamesKeys"></param>
        /// <returns></returns>
        public static string UploadTag(string serverIP, Hashtable ParamaterNamesKeys)
        {
            try
            {
                string url = "http://" + serverIP;
                url += UploadTagURL;
                url += GetParamaters(ParamaterNamesKeys);
                Trace.WriteLine("UploadTag：url=" + url);
                FormMain.myLog.Info("UploadTag：url=" + url);
                string result = (new MyWebClient()).HttpGet(url);
                Trace.WriteLine("UploadTag：result=" + result);
                FormMain.myLog.Info("UploadTag：result=" + result);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("UploadTag：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("UploadTag：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                return string.Empty;
            }
        }

        /// <summary>
        /// 上传工站TAG&上传测试信息
        /// </summary>
        /// <param name="ParamaterNamesKeys"></param>
        /// <returns></returns>
        public static string UploadTagWithTestInfos(string serverIP, Hashtable ParamaterNamesKeys, string testInfosValue)
        {
            try
            {
                string buf = null;
                foreach (var objItem in JObject.Parse(testInfosValue))
                {
                    buf += "{\"elapsed\":\"\",\"lower\":\"\",\"result\":\"\",\"unit\":\"\",\"upper\":\"\",\"name\":\"" + objItem.Key + "\",\"value\":\"" + objItem.Value + "\"},";
                }

                string caseTemp = "{\"cases\":[" + buf.Substring(0, buf.Length - 1) + "]}";

                Trace.WriteLine("UploadTagWithTestInfos：caseTemp=" + caseTemp);
                FormMain.myLog.Info("UploadTagWithTestInfos：caseTemp=" + caseTemp);

                string url = "http://" + serverIP;
                url += UploadTagURL;
                url += GetParamaters(ParamaterNamesKeys);
                Trace.WriteLine("UploadTagWithTestInfos：url=" + url);
                FormMain.myLog.Info("UploadTagWithTestInfos：url=" + url);
                string result = (new MyWebClient()).HttpPostJson(url, caseTemp);
                Trace.WriteLine("UploadTagWithTestInfos：result=" + result);
                FormMain.myLog.Info("UploadTagWithTestInfos：result=" + result);
                return result;
            }
            catch (Exception ex)
            {
                Trace.WriteLine("UploadTagWithTestInfos：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("UploadTagWithTestInfos：Exception=" + ex.StackTrace + ",msg=" + ex.Message);
                return string.Empty;
            }
        }
        /// <summary>
        /// 拼接URL参数
        /// </summary>
        /// <param name="ParamaterNamesKeys"></param>
        /// <returns></returns>
        private static string GetParamaters(Hashtable ParamaterNamesKeys)
        {
            string paramaters = null;
            foreach (DictionaryEntry entry in ParamaterNamesKeys)
            {
                paramaters += entry.Key + "=" + entry.Value + "&";
            }
            return paramaters.Substring(0, paramaters.Length - 1);
        }
    }
}
