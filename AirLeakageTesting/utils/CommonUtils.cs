using System;

namespace AirLeakageTesting.utils
{
    class CommonUtils
    {
        #region 内存回收
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);

        private static CommonUtils mCommonUtils = new CommonUtils();

        public static CommonUtils GetInstance()
        {
            return mCommonUtils;
        }
        ///
        /// 释放内存
        ///
        public void ClearMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
    }
}
