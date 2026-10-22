using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AirLeakageTesting.utils
{
    class RS485DealWithResult
    {
        /// <summary>
        /// 删除串口接收的数据的空格
        /// </summary>
        /// <param name="hexData"></param>
        /// <returns></returns>
        public static string DeleteSpace(string hexData)
        {
            return (hexData.Contains(" ")) ? hexData.Replace(" ", "") : hexData;
        }
        /// <summary>
        /// 获取仪器的测试状态
        /// </summary>
        /// <param name="hexData"></param>
        /// <returns></returns>
        public static string GetTestStatus(string hexData)
        {
            string tempRes = "unknow";

            if (string.IsNullOrEmpty(hexData))
            {
                return tempRes;
            }
            //处理数据
            hexData = DeleteSpace(hexData);
            //取数据位
            hexData = hexData.Substring(8, 2);
            string finalResult = tempRes;

            switch (hexData)
            {
                case "00":
                    finalResult = "设备空闲";
                    break;
                case "01":
                    finalResult = "夹具安装";
                    break;
                case "02":
                    finalResult = "进气";
                    break;
                case "03":
                    finalResult = "稳压";
                    break;
                case "04":
                    finalResult = "测试";
                    break;
                case "05":
                    finalResult = "测试结果OK";
                    break;
                case "06":
                    finalResult = "测试结果NG";
                    break;
            }

            return finalResult;
        }
        /// <summary>
        /// 测试结果的读取
        /// </summary>
        /// <param name="hexData">16进制字符串（不带前缀0X）</param>
        /// <returns></returns>
        public static int GetTestResult(string hexData)
        {
            try
            {
                //处理数据
                hexData = DeleteSpace(hexData);
                //取数据位
                hexData = hexData.Substring(6, 8);
                //高低位组对调（4位一组）
                string hexResult = hexData.Substring(4, 4) + hexData.Substring(0, 4);
                //Trace.WriteLine("hexResult=" + hexResult);

                //判断是否是负数。result转二进制的第一位为1则，表示为负数，为0表示为正数
                //若是负数需要减 0XFFFF FFFF 减 1
                string bin = HexStr2BinStr(hexResult);
                //Trace.WriteLine("HexString2BinString=" + bin);
                if (bin.Substring(0, 1).Equals("1"))
                {
                    hexResult = (Convert.ToInt32(hexResult, 16) - Convert.ToInt32("FFFFFFFF", 16) - 1).ToString("x");
                    //Trace.WriteLine("hexResult 为负数，转换之后=" + hexResult);
                    FormMain.myLog.Info("hexResult 为负数，转换之后=" + hexResult);
                    return Int32.Parse(hexResult, System.Globalization.NumberStyles.HexNumber);
                }
                else
                {
                    return Int32.Parse(hexResult, System.Globalization.NumberStyles.HexNumber);
                }
            }
            catch (Exception ex)
            {

                Trace.WriteLine("异常：" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("异常：" + ex.StackTrace + ",msg=" + ex.Message);
                return 0x1212;
            }
        }

        /// <summary>
        /// 16进制的字符串转2进制的字符串
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        private static string HexStr2BinStr(string hexString)
        {
            string result = string.Empty;
            foreach (char c in hexString)
            {
                int v = Convert.ToInt32(c.ToString(), 16);
                int v2 = int.Parse(Convert.ToString(v, 2));
                // 去掉格式串中的空格，即可去掉每个4位二进制数之间的空格，
                result += string.Format("{0:d4} ", v2);
            }
            return result;
        }

        /// <summary>
        /// 16进制的字符串转10进制的int
        /// </summary>
        /// <param name="hexString"></param>
        /// <returns></returns>
        public static int HexStr2DecimalInt(string hexString)
        {
            hexString = DeleteSpace(hexString);
            return int.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);
        }
        /// <summary>
        /// 单位换算率，默认1 表示"KPA"
        /// </summary>
        public static double unitChangeRate = 1.0;
        /// <summary>
        /// 获取单位和精度
        /// </summary>
        /// <param name="hexData"></param>
        public static Dictionary<string, string> GetUnitAndPrecision(string hexData)
        {
            if (string.IsNullOrEmpty(hexData))
            {
                return null;
            }
            try
            {
                //处理数据
                hexData = DeleteSpace(hexData);
                //取数据位
                hexData = hexData.Substring(6, 8);
                string hexUnit = hexData.Substring(0, 4);
                string hexPrecision = hexData.Substring(4, 4);
                //Trace.WriteLine("单位：" + hexUnit + " 精度：" + hexPrecision);

                string unit = string.Empty;
                switch (hexUnit)
                {
                    case "0007":
                        unit = "KPA";
                        unitChangeRate = 1;
                        break;
                    case "0006":
                        unit = "PA";
                        unitChangeRate = 1000;
                        break;
                    case "0005":
                        unit = "kgf/cm2";
                        unitChangeRate = 0.0101972;
                        break;
                    case "0004":
                        unit = "psi";
                        unitChangeRate = 0.1450377;
                        break;
                    case "0003":
                        unit = "Mpa";
                        unitChangeRate = 0.001;
                        break;
                    case "0002":
                        unit = "Bar";
                        unitChangeRate = 0.01;
                        break;
                    case "0001":
                        unit = "Mbar";
                        unitChangeRate = 10;
                        break;
                    case "0000":
                        unit = "mmhg";
                        unitChangeRate = 7.5006168;
                        break;
                }

                string precision = string.Empty;
                switch (hexPrecision)
                {
                    case "0004":
                        precision = "4";
                        break;
                    case "0003":
                        precision = "3";
                        break;
                    case "0002":
                        precision = "2";
                        break;
                    case "0001":
                        precision = "1";
                        break;
                    case "0000":
                        precision = "0";
                        break;
                }

                Dictionary<string, string> result = new Dictionary<string, string>();
                result.Add(unit, precision);
                return result;
            }
            catch (Exception ex)
            {

                Trace.WriteLine("异常：" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("异常：" + ex.StackTrace + ",msg=" + ex.Message);
                return null;
            }
        }
    }
}
