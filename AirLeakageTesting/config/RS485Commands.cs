namespace AirLeakageTesting.config
{
    /// <summary>
    /// 基于RS485的通讯指令，发送接收的指令均为 16进制数据（目前仪器都是 “直压仪器”）
    /// </summary>
    class RS485Commands
    {
        private static RS485Commands _instace = new RS485Commands();
        private RS485Commands() { }
        public static RS485Commands GetInstance()
        {
            return _instace;
        }

        /// <summary>
        /// 查询设备状态
        /// </summary>
        public string GetDeviceStatus = "01 03 00 28 00 01 04 02";

        /// <summary>
        /// 若仪器空闲，就可以发送指令让仪器工作了
        /// </summary>
        public string Start = "01 05 00 00 FF 00 8c 3A";

        /// <summary>
        /// 测试气压读取
        /// </summary>
        public string GetPressureValue = "01 03 16 dc 00 02 01 b9";

        /// <summary>
        /// 直压型测试泄漏值读取
        /// </summary>
        public string DirectPressureTestLeakageValue = "01 03 16 90 00 02 C0 6E";

        /// <summary>
        /// 差压型测试泄漏值读取
        /// </summary>
        public string DifferentialPressureTestLeakageValue = "01 03 16 92 00 02 61 AE";

        /// <summary>
        /// 直压型测试流量值读取
        /// </summary>
        public string DirectVoltageTestFlowValue = "01 03 16 CC 00 02 00 7C";

        /// <summary>
        /// 差压型测试流量值读取
        /// </summary>
        public string DifferentialVoltageTestFlowValue = "01 03 16 CE 00 02 A1 BC";

        /// <summary>
        /// 差压型大漏值读取
        /// </summary>
        public string DifferentialPressureTypeLargeLeakageValue = "01 03 15 D6 00 02 21 F";

        /// <summary>
        /// 测试判定结果读取
        /// </summary>
        public string GetTestResult = "01 03 00 0C 00 01 44 09";

        /// <summary>
        /// 泄漏速率SCCM值读取
        /// </summary>
        //public string LeakageRateSCCMValue = "01 03 16 D4 00 02 80 7B";
        public string LeakageRateSCCMValue = "01 03 02 F1 00 02 94 40";


        /// <summary>
        /// 测试过程中终止测试
        /// </summary>
        public string Stop = "01 05 00 01 FF 00 DD FA";

        /// <summary>
        /// 测试程序号D128的读取
        /// 仪器回复：01 03 02 00 01 79 84 ，红色部分是得到的2字节的测试仪执行程序的起始程序号。
        /// 00 01
        /// 0x0001 = 1 代表1号程序。
        /// </summary>
        public string GetTestProgramNumber = "01 03 00 80 00 01 85 e2";

        /// <summary>
        /// 上位机发送代码：01 06 00 80 00 03 c8 23 ，代表将起始程序号 D128 写入 3
        /// 例如仪器回复：01 06 00 80 00 03 C8 23 ，表示写入3 成功
        /// </summary>
        public string SetTestProgramNumber = "01 06 00 80 00 03 c8 23";

        /// <summary>
        /// 测试的产量值读取
        /// </summary>
        public string GetTotalTestNumber = "01 03 00 8a 00 01 a5 e0";

        /// <summary>
        /// 产量值的清零
        /// </summary>
        public string ClearTotalTestNumber = "01 06 00 8a 00 00 a8 20";

        /// <summary>
        /// 当前气压值得读取
        /// </summary>
        public string GetCurrentPressureValue = "01 03 16 88 00 02 40 69";

        /// <summary>
        /// 进气、泄漏 上下限读取
        /// </summary>
        public string UpperAndLowerLimitsOfAirIntakeAndLeakage = "01 03 00 5A 00 08 64 1F";

        /// <summary>
        /// 读取测试过程中时间参数
        /// </summary>
        public string GetTestTimes = "01 03 00 49 00 08 95 DA";

        /// <summary>
        /// 读取单位指令
        /// </summary>
        public string GetUnit = "01 03 00 96 00 02 24 27";

        /// <summary>
        /// 远程清零 M8
        /// </summary>
        public string RemoteZeroing = "01 05 00 08 FF 00 0D F8";

        /// <summary>
        /// 进度条
        /// </summary>
        public string GetTestProgress = "01 03 00 b0 00 02 C5 EC";
    }
}
