// ReSharper disable once CheckNamespace
namespace System.Windows.Forms
{
    public static class ControlHelper
    {
        /// <summary>
        /// ����� �������� �� ������� ������
        /// </summary>
        /// <param name="control">�������</param>
        /// <param name="method">�������</param>
        /// <param name="param">���������</param>
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
        /// ����� �������� �� ������� ������
        /// </summary>
        /// <param name="control">�������</param>
        /// <param name="method">�������</param>
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