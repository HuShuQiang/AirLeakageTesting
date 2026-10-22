using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLeakageTesting.utils
{
    class PrintUitls
    {
        public static void Write(string msg, int channel = 1)
        {
            string tmpStr = "Channel：" + channel + "，" + msg;
            Trace.WriteLine(tmpStr);
            FormMain.myLog.Info(tmpStr);
        }
    }
}
