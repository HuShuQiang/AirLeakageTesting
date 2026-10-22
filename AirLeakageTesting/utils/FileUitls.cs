using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AirLeakageTesting.settings;
using AirLeakageTesting.uitls;

namespace AirLeakageTesting.utils
{
    /// <summary>
    /// 文件操作
    /// </summary>
    class FileUitls
    {
        /// <summary>
        /// 保存更新本地的设置配置
        /// </summary>
        /// <param name="obj"></param>
        public static void SaveConfig(object obj)
        {
            string settingsPath = null;
            if (obj is GlobalSettings)
            {
                settingsPath = FormMain.SaveGlobalSettingsPath;
            }
            else if (obj is SerialPort1Paramas)
            {
                settingsPath = FormMain.SaveSerialPort1SettingsPath;
            }
            else if (obj is SerialPort2Paramas)
            {
                settingsPath = FormMain.SaveSerialPort2SettingsPath;
            }
            else if (obj is SerialPort3Paramas)
            {
                settingsPath = FormMain.SaveSerialPort3SettingsPath;
            }
            else if (obj is SerialPort4Paramas)
            {
                settingsPath = FormMain.SaveSerialPort4SettingsPath;
            }

            if (settingsPath == null)
            {
                return;
            }

            Trace.WriteLine(PropertiesUtils.GetProperties(obj));
            FormMain.myLog.Info(PropertiesUtils.GetProperties(obj));
            try
            {
                using (FileStream fs = new FileStream(settingsPath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, obj);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("SaveConfig Error：" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("SaveConfig Error：" + ex.StackTrace + ",msg=" + ex.Message);
            }
        }
        /// <summary>
        /// 获取本地的配置，如果存在
        /// </summary>
        /// <returns></returns>
        public static object GetConfig(SerializationFileType fileType)
        {
            string settingsPath = null;

            if (fileType == SerializationFileType.Global)
            {
                if (!File.Exists(FormMain.SaveGlobalSettingsPath))
                {
                    return null;
                }
                settingsPath = FormMain.SaveGlobalSettingsPath;
            }
            else if (fileType == SerializationFileType.SerialPort1)
            {
                if (!File.Exists(FormMain.SaveSerialPort1SettingsPath))
                {
                    return new SerialPort1Paramas();
                }
                settingsPath = FormMain.SaveSerialPort1SettingsPath;
            }
            else if (fileType == SerializationFileType.SerialPort2)
            {
                if (!File.Exists(FormMain.SaveSerialPort2SettingsPath))
                {
                    return new SerialPort2Paramas();
                }
                settingsPath = FormMain.SaveSerialPort2SettingsPath;
            }
            else if (fileType == SerializationFileType.SerialPort3)
            {
                if (!File.Exists(FormMain.SaveSerialPort3SettingsPath))
                {
                    return new SerialPort3Paramas();
                }
                settingsPath = FormMain.SaveSerialPort3SettingsPath;
            }
            else if (fileType == SerializationFileType.SerialPort4)
            {
                if (!File.Exists(FormMain.SaveSerialPort4SettingsPath))
                {
                    return new SerialPort4Paramas();
                }
                settingsPath = FormMain.SaveSerialPort4SettingsPath;
            }

            try
            {
                using (FileStream fs = new FileStream(settingsPath, FileMode.Open))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    return bf.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine("GetConfig Error：" + ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info("GetConfig Error：" + ex.StackTrace + ",msg=" + ex.Message);
            }

            return null;
        }
    }
}
