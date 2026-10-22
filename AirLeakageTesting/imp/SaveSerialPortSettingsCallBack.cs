using AirLeakageTesting.settings;

namespace AirLeakageTesting.imp
{
    /// <summary>
    /// 串口设置保存之后的更新回调
    /// </summary>
    public interface SaveSerialPortSettingsCallBack
    {
        void updateSerialPortConfig(SerializationFileType type, PostSettings postSettings);
    }
}
