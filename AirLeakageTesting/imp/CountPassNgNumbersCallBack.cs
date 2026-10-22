namespace AirLeakageTesting.imp
{
    /// <summary>
    /// 测试通过和失败的数量统计的回调
    /// </summary>
    public interface CountPassNgNumbersCallBack
    {
        void updatePassNumbers(int passNum);
        void updateFailNumbers(int failNum);
    }
}
