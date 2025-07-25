using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms_singleselection
{
    public static class ControlExtensions
    {
        /// <summary>
        /// 线程安全的UI操作
        /// </summary>
        public static void SafeInvoke(this Control control, Action action)
        {
            try
            {
                if (control == null || control.IsDisposed) return;

                if (control.InvokeRequired)
                {
                    control.Invoke(action);
                }
                else
                {
                    action();
                }
            }
            catch (ObjectDisposedException)
            {
                // 忽略已释放控件的异常
            }
        }

        /// <summary>
        /// 带返回值的线程安全调用
        /// </summary>
        public static T SafeInvoke<T>(this Control control, Func<T> func)
        {
            if (control == null || control.IsDisposed) return default;

            return control.InvokeRequired
                ? (T)control.Invoke(func)
                : func();
        }
    }
}
