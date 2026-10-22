using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace AirLeakageTesting.utils
{
    /// <summary>
    /// 跨线程调用控件帮助类
    /// </summary>
    public class InvokeHelper
    {
        #region delegates  

        private delegate object MethodInvoker(Control control, string methodName, params object[] args);
        private delegate object PropertyGetInvoker(Control control, object noncontrol, string propertyName);
        private delegate void PropertySetInvoker(Control control, object noncontrol, string propertyName, object value);

        #endregion

        #region static methods  
        // helpers  
        private static PropertyInfo GetPropertyInfo(Control control, object noncontrol, string propertyName)
        {
            PropertyInfo pi = null;
            try
            {
                if (control != null && !string.IsNullOrEmpty(propertyName))
                {
                    Type t = null;

                    if (noncontrol != null)
                        t = noncontrol.GetType();
                    else
                        t = control.GetType();

                    pi = t.GetProperty(propertyName);

                    if (pi == null)
                        throw new InvalidOperationException(
                            string.Format(
                            "Can't find property {0} in {1}.",
                            propertyName,
                            t.ToString()
                            ));

                    return pi;
                }
                else
                {
                    throw new ArgumentNullException("Invalid argument.");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info(ex.StackTrace + ",msg=" + ex.Message);
                return pi;
            }
        }

        /// <summary>
        /// 调用主界面控件的某个方法，并返回方法执行结果
        /// </summary>
        /// <param name="control"> 控件 </param>
        /// <param name="methodName"> 方法名 </param>
        /// <param name="args"> 参数 </param>
        /// <returns></returns>
        public static object Invoke(Control control, string methodName, params object[] args)
        {
            try
            {
                if (control != null && !string.IsNullOrEmpty(methodName))
                {
                    if (control.InvokeRequired)
                    {
                        return control.Invoke(
                            new MethodInvoker(Invoke),
                            control,
                            methodName,
                            args
                            );
                    }
                    else
                    {
                        MethodInfo mi = null;

                        if (args != null && args.Length > 0)
                        {
                            Type[] types = new Type[args.Length];
                            for (int i = 0; i < args.Length; i++)
                            {
                                if (args[i] != null)
                                    types[i] = args[i].GetType();
                            }

                            mi = control.GetType().GetMethod(methodName, types);
                        }
                        else
                            mi = control.GetType().GetMethod(methodName);

                        // check method info you get  
                        if (mi != null)
                            return mi.Invoke(control, args);
                        else
                            throw new InvalidOperationException("Invalid method.");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Invalid argument.");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info(ex.StackTrace + ",msg=" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 获取主界面控件的某个属性
        /// </summary>
        /// <param name="control"> 控件 </param>
        /// <param name="propertyName"> 属性名 </param>
        /// <returns></returns>
        public static object Get(Control control, string propertyName)
        {
            return Get(control, null, propertyName);
        }

        public static object Get(Control control, object noncontrol, string propertyName)
        {
            try
            {
                if (control != null && !string.IsNullOrEmpty(propertyName))
                {
                    if (control.InvokeRequired)
                    {
                        return control.Invoke(new PropertyGetInvoker(Get),
                            control,
                            noncontrol,
                            propertyName
                            );
                    }
                    else
                    {
                        PropertyInfo pi = GetPropertyInfo(control, noncontrol, propertyName);
                        object invokee = (noncontrol == null) ? control : noncontrol;

                        if (pi != null)
                            if (pi.CanRead)
                                return pi.GetValue(invokee, null);
                            else
                                throw new FieldAccessException(
                                    string.Format(
                                    "{0}.{1} is a write-only property.",
                                    invokee.GetType().ToString(),
                                    propertyName
                                    ));

                        return null;
                    }
                }
                else
                {
                    throw new ArgumentNullException("Invalid argument.");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info(ex.StackTrace + ",msg=" + ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 设置主界面控件的某个属性
        /// </summary>
        /// <param name="control"> 控件 </param>
        /// <param name="propertyName"> 属性名 </param>
        /// <param name="value"> 属性值 </param>
        public static void Set(Control control, string propertyName, object value)
        {
            Set(control, null, propertyName, value);
        }

        public static void Set(Control control, object noncontrol, string propertyName, object value)
        {
            try
            {
                if (control != null && !string.IsNullOrEmpty(propertyName))
                {
                    if (control.InvokeRequired)
                    {
                        control.Invoke(new PropertySetInvoker(Set),
                            control,
                            noncontrol,
                            propertyName,
                            value
                            );
                    }
                    else
                    {
                        PropertyInfo pi = GetPropertyInfo(control, noncontrol, propertyName);
                        object invokee = (noncontrol == null) ? control : noncontrol;

                        if (pi != null)
                            if (pi.CanWrite)
                                pi.SetValue(invokee, value, null);
                            else
                                throw new FieldAccessException(
                                    string.Format(
                                    "{0}.{1} is a read-only property.",
                                    invokee.GetType().ToString(),
                                    propertyName
                                    ));
                    }
                }
                else
                {
                    throw new ArgumentNullException("Invalid argument.");
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.StackTrace + ",msg=" + ex.Message);
                FormMain.myLog.Info(ex.StackTrace + ",msg=" + ex.Message);
            }
        }
        #endregion
    }
}
