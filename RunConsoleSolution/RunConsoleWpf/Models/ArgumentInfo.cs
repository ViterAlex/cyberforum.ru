namespace RunConsole.Models
{
    /// <summary>
    ///     Класс для представления данных об аргументах в списке
    /// </summary>
    public class ArgumentInfo
    {
        #region Свойства

        public string Value { get; set; }

        #endregion

        public ArgumentInfo(string value)
        {
            Value = value;
        }
    }
}