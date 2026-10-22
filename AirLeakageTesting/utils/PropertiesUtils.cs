namespace AirLeakageTesting.uitls
{
    class PropertiesUtils
    {
        /// <summary>
        /// 输出结果为: name1:value1,name2:value2 遍历获取类的属性及属性的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetProperties<T>(T t)
        {
            string tStr = string.Empty;

            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);

            if (properties.Length <= 0)
            {
                return tStr;
            }

            int length = properties.Length;
            if (length <= 0)
            {
                return tStr;
            }
            for (int i = 0; i < length; i++)
            {
                System.Reflection.PropertyInfo item = properties[i];
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    if (i == length - 1)
                    {
                        tStr += string.Format("{0}={1}", name, value);
                    }
                    else
                    {
                        if (i == 0)
                        {
                            tStr += string.Format("{0}：{1}={2},", t.GetType().Name, name, value);
                        }
                        else
                        {
                            tStr += string.Format("{0}={1},", name, value);
                        }
                    }
                }
                else
                {
                    GetProperties(value);
                }
            }
            return tStr;
        }
    }
}
