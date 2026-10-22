using AirLeakageTesting.settings;

namespace AirLeakageTesting.imp
{
    /// <summary>
    /// 设置项保存之后的更新回调
    /// </summary>
    public interface SettingsCallBack
    {
        void updateConfig(GlobalSettings globalSettings);
    }
}
