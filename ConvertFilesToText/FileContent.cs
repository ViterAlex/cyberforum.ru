using System;
using System.ComponentModel;

namespace ConvertFilesToText
{
internal class FileContent
{
    [DisplayName("Время добавления")]
    public DateTime CreationDate { get; set; }
    [DisplayName("Путь к файлу")]
    public string Path { get; set; }
    [DisplayName("Содержимое")]
    public string Content { get; set; }

    public FileContent(DateTime creationDate, string path, string content)
    {
        CreationDate = creationDate;
        Path = path;
        Content = content;
    }
}
}
