// ReSharper disable once CheckNamespace
namespace System.Windows.Forms
{
    public static class ControlHelper
    {
        /// <summary>
        /// Вызов делегата из другого потока
        /// </summary>
        /// <param name="control">Контрол</param>
        /// <param name="method">Делегат</param>
        /// <param name="param">Параметры</param>
        public static void InvokeEx(this Control control, Delegate method, params object[] param)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(method, param);
            }
            else
            {
                method.DynamicInvoke(param);
            }
        }
        /// <summary>
        /// Вызов делегата из другого потока
        /// </summary>
        /// <param name="control">Контрол</param>
        /// <param name="method">Делегат</param>
        public static void InvokeEx(this Control control, Delegate method)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(method);
            }
            else
            {
                method.DynamicInvoke();
            }
        }
    }
}