namespace AirLeakageTesting
{
    /// <summary>
    /// 保存气密性测试的信息
    /// </summary>
    class EntryBean
    {
        /// <summary>
        /// 测试压力
        /// </summary>
        public string testPressure { get; set; }

        /// <summary>
        /// 测试压力偏差
        /// </summary>
        public string testPressureDeviation { get; set; }

        /// <summary>
        /// 漏气值
        /// </summary>
        public string AirLeakageValue { get; set; }

        /// <summary>
        /// 漏气值偏差
        /// </summary>
        public string AirLeakageValueDeviation { get; set; }

        /// <summary>
        /// 泄漏速率
        /// </summary>
        public string LeakageRate { get; set; }

        /// <summary>
        /// 充气时间
        /// </summary>
        public string ChongQiTime { get; set; }

        /// <summary>
        /// 稳压时间
        /// </summary>
        public string WenYaTime { get; set; }

        /// <summary>
        /// 测试时间
        /// </summary>
        public string TestTime { get; set; }

        /// <summary>
        /// 总测试时间
        /// </summary>
        public string TotalTestTime { get; set; }
    }
}
