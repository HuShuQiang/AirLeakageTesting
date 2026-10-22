using System;

namespace AirLeakageTesting.settings
{
    /// <summary>
    /// 常用设置 变量保存
    /// </summary>
    [Serializable()]
    public sealed class GlobalSettings
    {
        public GlobalSettings() { }

        #region  工站设置
        /// <summary>
        /// 生产线Id
        /// </summary>
        public string ProductionId { get; set; }
        /// <summary>
        /// 工位ID
        /// </summary>
        public string StationId { get; set; }
        /// <summary>
        /// 工位名
        /// </summary>
        public string StationName { get; set; }
        #endregion

        #region  服务器设置
        /// <summary>
        /// 机型
        /// </summary>
        public string Model { get; set; }
        /// <summary>
        /// IP地址
        /// </summary>
        private string serverIP = "192.168.8.2:8090";
        public string ServerIP
        {
            get
            {
                return serverIP;
            }
            set
            {
                serverIP = value;
            }
        }
        #endregion

        #region  样本指标设置
        /// <summary>
        /// 进气压力（单位为Kpa）
        /// </summary>
        private double pressureValue = 12;
        public double PressureValue
        {
            get
            {
                return pressureValue;
            }
            set
            {
                pressureValue = value;
            }
        }

        /// <summary>
        /// 进气压力上限（单位为Kpa）
        /// </summary>
        private double pressureValueUp = 13;
        public double PressureValueUp
        {
            get
            {
                return pressureValueUp;
            }
            set
            {
                pressureValueUp = value;
            }
        }

        /// <summary>
        /// 进气压力下限（单位为Kpa）
        /// </summary>
        private double pressureValueDown = 11;
        public double PressureValueDown
        {
            get
            {
                return pressureValueDown;
            }
            set
            {
                pressureValueDown = value;
            }
        }

        /// <summary>
        /// 泄漏上限（单位为Kpa）
        /// </summary>
        private double leakAgeValueUP = 0.2;
        public double LeakAgeValueUP
        {
            get
            {
                return leakAgeValueUP;
            }
            set
            {
                leakAgeValueUP = value;
            }
        }

        /// <summary>
        /// 泄漏下限（单位为Kpa）
        /// </summary>
        private double leakAgeValueDown = 0;
        public double LeakAgeValueDown
        {
            get
            {
                return leakAgeValueDown;
            }
            set
            {
                leakAgeValueDown = value;
            }
        }

        /// <summary>
        /// 充气时间
        /// </summary>
        private int chongQiTime = 4;
        public int ChongQiTime
        {
            get
            {
                return chongQiTime;
            }
            set
            {
                chongQiTime = value;
            }
        }

        /// <summary>
        /// 稳压时间
        /// </summary>
        private int wenYaTime = 5;
        public int WenYaTime
        {
            get
            {
                return wenYaTime;
            }
            set
            {
                wenYaTime = value;
            }
        }
        /// <summary>
        /// 测试时间
        /// </summary>
        private int testingTime = 5;
        public int TestingTime
        {
            get
            {
                return testingTime;
            }
            set
            {
                testingTime = value;
            }
        }
        #endregion

        #region  通道设置
        /// <summary>
        /// 通道数量
        /// </summary>
        private int channelNumbers = 1;
        public int ChannnelNumber
        {
            get
            {
                return channelNumbers;
            }
            set
            {
                channelNumbers = value;
            }
        }
        #endregion

        #region  访问服务器离线设置
        /// <summary>
        /// 访问服务器是否离线
        /// </summary>
        private string isOffline = "否";
        public string IsOffline
        {
            get
            {
                return isOffline;
            }
            set
            {
                isOffline = value;
            }
        }
        #endregion

        /// <summary>
        /// 检查前一工位的测试是否通过
        /// </summary>
        private string checkPreStation = "是";
        public string CheckPreStation
        {
            get
            {
                return checkPreStation;
            }
            set
            {
                checkPreStation = value;
            }
        }

        /// <summary>
        /// 扫描的号码sn/cmei
        /// </summary>
        private string inputNumber = "sn";
        public string InputNumber
        {
            get
            {
                return inputNumber;
            }
            set
            {
                inputNumber = value;
            }
        }

        /// <summary>
        /// 统计总共测试的合格数量
        /// </summary>
        private int totalPass = 0;
        public int TotalPassNums
        {
            get
            {
                return totalPass;
            }
            set
            {
                totalPass = value;
            }
        }

        /// <summary>
        /// 统计总共测试的失败数量
        /// </summary>
        private int totalFail = 0;
        public int TotalFailNums
        {
            get
            {
                return totalFail;
            }
            set
            {
                totalFail = value;
            }
        }

        private string workmode = "手动触发";
        public string WorkMode
        {
            get
            {
                return workmode;
            }
            set
            {
                workmode = value;
            }
        }

    }
}
