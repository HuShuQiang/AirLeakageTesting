using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;

namespace AirLeakageTesting.uitls
{
    public class MyWebClient : WebClient
    {
        private int _timeout;
        /// <summary>
        /// 超时时间(毫秒)
        /// </summary>
        public int Timeout
        {
            get
            {
                return _timeout;
            }
            set
            {
                _timeout = value;
            }
        }

        public MyWebClient()
        {
            this._timeout = 2000;
        }

        public MyWebClient(int timeout)
        {
            this._timeout = timeout;
        }

        private IPAddress ipAddress;

        public MyWebClient(IPAddress ipAddress)
        {
            this.ipAddress = ipAddress;
        }

        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url">地址</param>
        /// <returns></returns>
        public RequestRes HttpGetRequest(string url, IPAddress localip)
        {
            RequestRes resTmp = new RequestRes();
            HttpWebRequest request = null;
            try
            {
                //创建请求
                request =
                   WebRequest.Create(url) as
                       HttpWebRequest;
                string json = "";

                request.KeepAlive = false;
                request.Timeout = this._timeout;
                request.Proxy = null;//去掉这条代码,可能导致第一次访问很慢

                request.ServicePoint.BindIPEndPointDelegate = delegate (
                    ServicePoint servicePoint,
                    IPEndPoint remoteEndPoint,
                    int retryCount)
                {
                    if (remoteEndPoint.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    {
                        return new IPEndPoint(IPAddress.IPv6Any, 0);
                    }
                    else
                    {
                        return new IPEndPoint(localip, 0);
                    }

                };

                //得到请求的返回数据
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK) //表示返回的状态吗是200，请求成功
                    {
                        //得到返回的数据流,进行读取
                        using (Stream streamResonse = response.GetResponseStream())
                        using (StreamReader reader = new StreamReader(streamResonse))
                        {

                            json = reader.ReadToEnd();
                        }
                    }
                }
                resTmp.IsRequestSucceed = true;
                resTmp.Result = json;
                return resTmp;
            }
            catch (Exception ex)
            {
                request.Abort();
                resTmp.IsRequestSucceed = false;
                Trace.WriteLine("HttpGetRequest异常：" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("HttpGetRequest异常：" + ex.StackTrace + ",msg=" + ex.Message);
                return resTmp;
            }

        }

        public string HttpGet(string url, int tryCnt = 3)
        {
            string resTotal = "";
            RequestRes resTmp = new RequestRes();
            for (int i = 0; i < tryCnt; i++)//如果出现异常，尝试再次请求，最多尝试三次
            {
                IPAddress localip = IPAddress.Any;
                //IPAddress.TryParse(SettingsHelper.GeneralSettingsHelper.settings.OtherGeneralSettings.LocalIp, out localip);
                if (localip == null)
                {
                    localip = IPAddress.Any;
                }
                //Trace.WriteLine("HttpGet localip:" + localip);

                resTmp = HttpGetRequest(url, localip);
                if (resTmp.IsRequestSucceed)
                {
                    resTotal = resTmp.Result;
                    break;
                }
                else
                {
                    resTotal = resTmp.Result;
                    Trace.WriteLine("网络请求异常，再次尝试...错误信息：" + resTmp.Result);
                    Thread.Sleep(200);
                }
            }
            return resTotal;
        }

        public string HttpPostJson(string url, string rawData)
        {
            int tryCnt = 3;
            for (int i = 0; i < tryCnt; i++)//如果出现异常，尝试再次请求，最多尝试三次
            {
                try
                {
                    HttpWebRequest httpWebRequest = WebRequest.Create(url) as HttpWebRequest;

                    httpWebRequest.KeepAlive = false;
                    httpWebRequest.Timeout = this._timeout;
                    httpWebRequest.Proxy = null;//去掉这条代码,可能导致第一次访问很慢

                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";

                    IPAddress localip = IPAddress.Any;
                    //IPAddress.TryParse(SettingsHelper.GeneralSettingsHelper.settings.OtherGeneralSettings.LocalIp, out localip);
                    if (localip == null)
                    {
                        localip = IPAddress.Any;
                    }
                    //Trace.WriteLine("HttpPostJson localip:" + localip);

                    httpWebRequest.ServicePoint.BindIPEndPointDelegate = delegate (
                        ServicePoint servicePoint,
                        IPEndPoint remoteEndPoint,
                        int retryCount)
                    {
                        if (remoteEndPoint.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                        {
                            return new IPEndPoint(IPAddress.IPv6Any, 0);
                        }
                        else
                        {
                            return new IPEndPoint(localip, 0);
                        }

                    };

                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(rawData);
                        streamWriter.Flush();
                        streamWriter.Close();
                    }

                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("HttpPostJson异常：" + i + " " + ex.StackTrace + ",msg=" + ex.Message);
                    continue;
                }
            }
            return "";//未成功
        }

        public string HttpPostFormData(string url, IEnumerable<FormDataFile> files, NameValueCollection values)
        {
            int tryCnt = 3;
            for (int i = 0; i < tryCnt; i++)//如果出现异常，尝试再次请求，最多尝试三次
            {
                try
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpWebRequest.Method = "POST";
                    httpWebRequest.Timeout = this._timeout;

                    httpWebRequest.KeepAlive = false;
                    httpWebRequest.Proxy = null;//去掉这条代码,可能导致第一次访问很慢

                    IPAddress localip = IPAddress.Any;
                    //IPAddress.TryParse(SettingsHelper.GeneralSettingsHelper.settings.OtherGeneralSettings.LocalIp, out localip);
                    if (localip == null)
                    {
                        localip = IPAddress.Any;
                    }
                    //Trace.WriteLine("HttpPostFormData localip:" + localip);
                    //FormMain.myLog.Info("HttpPostFormData localip:" + localip);

                    httpWebRequest.ServicePoint.BindIPEndPointDelegate = delegate (
                        ServicePoint servicePoint,
                        IPEndPoint remoteEndPoint,
                        int retryCount)
                    {
                        if (remoteEndPoint.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                        {
                            return new IPEndPoint(IPAddress.IPv6Any, 0);
                        }
                        else
                        {
                            return new IPEndPoint(localip, 0);
                        }

                    };


                    var boundary = "---------------------------" + DateTime.Now.Ticks.ToString("x", NumberFormatInfo.InvariantInfo);
                    httpWebRequest.ContentType = "multipart/form-data; boundary=" + boundary;
                    boundary = "--" + boundary;

                    using (var requestStream = httpWebRequest.GetRequestStream())
                    {
                        // Write the values
                        if (values != null && values.Count > 0)
                        {
                            foreach (string name in values.Keys)
                            {
                                var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                                requestStream.Write(buffer, 0, buffer.Length);
                                buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"{1}{1}", name, Environment.NewLine));
                                requestStream.Write(buffer, 0, buffer.Length);
                                buffer = Encoding.UTF8.GetBytes(values[name] + Environment.NewLine);
                                requestStream.Write(buffer, 0, buffer.Length);
                            }
                        }

                        // Write the files
                        if (files != null && files.Count() > 0)
                        {
                            foreach (var file in files)
                            {
                                var buffer = Encoding.ASCII.GetBytes(boundary + Environment.NewLine);
                                requestStream.Write(buffer, 0, buffer.Length);

                                buffer = Encoding.ASCII.GetBytes(string.Format("Content-Disposition: form-data; name=\"{0}\"; filename=\"{1}\"{2}", file.Name, file.Filename, Environment.NewLine));
                                requestStream.Write(buffer, 0, buffer.Length);

                                buffer = Encoding.ASCII.GetBytes(string.Format("Content-Type: {0}{1}{1}", file.ContentType, Environment.NewLine));
                                requestStream.Write(buffer, 0, buffer.Length);

                                file.Stream.CopyTo(requestStream);
                                file.Stream.Close();
                                buffer = Encoding.UTF8.GetBytes(Environment.NewLine);
                                requestStream.Write(buffer, 0, buffer.Length);

                                Trace.WriteLine(file.Filename);
                                FormMain.myLog.Info(file.Filename);
                            }
                        }

                        var boundaryBuffer = Encoding.ASCII.GetBytes(boundary + "--");
                        requestStream.Write(boundaryBuffer, 0, boundaryBuffer.Length);
                        requestStream.Close();
                    }

                    using (var response = httpWebRequest.GetResponse())
                    using (var responseStream = response.GetResponseStream())
                    using (var stream = new MemoryStream())
                    {
                        responseStream.CopyTo(stream);
                        byte[] bytes = stream.ToArray();
                        return System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("HttpPostFormData 异常：" + i + " " + ex.StackTrace + ",msg=" + ex.Message);
                    FormMain.myLog.Info("HttpPostFormData 异常：" + i + " " + ex.StackTrace + ",msg=" + ex.Message);
                    continue;
                }
            }
            return "";//未成功
        }
    }

    public class FormDataFile
    {
        public FormDataFile()
        {
            ContentType = "multipart/form-data";
        }

        public string Name { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public Stream Stream { get; set; }
    }

    public class RequestRes
    {
        public string Result { get; set; }
        public bool IsRequestSucceed { get; set; }
    }
}
