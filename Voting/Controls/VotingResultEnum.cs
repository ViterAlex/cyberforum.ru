using System.ComponentModel;

namespace System.Windows.Forms
{
    /// <summary>
    /// Результат голосования
    /// </summary>
    [TypeConverter(typeof(VotingResultEnumConverter))]
    public enum VotingResultEnum
    {
        [Description("Да")]
        Yes,
        [Description("Нет")]
        No,
        [Description("Воздержался")]
        Abstain
    }
}
