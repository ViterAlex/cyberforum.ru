using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GmapDgvSample
{
public static class WordExporter
{
    /// <summary>
    /// Завершение экспорта
    /// </summary>
    internal static Action ExportCompleted;
    private static DataGridView _dataGridView;
    private static dynamic _wdApp;//Приложение Word
    private static string _fileName;//путь к файлу
    private static dynamic _wdTable;//Таблица в документе
    private static dynamic _wdDoc;//Документ

    /// <summary>
    /// Экспорт содержимого DataGridView в Word с разделением на документы по содержимому столбца
    /// </summary>
    /// <param name="dgv">Экспортируемый DataGridView</param>
    /// <param name="filename">Имя файла</param>
    public static void Export(DataGridView dgv, string filename)
    {
        //Сохраняем ссылки на объекты
        _dataGridView = dgv;
        _fileName = filename;
        //Создаём новое приложение Word
        _wdApp = Activator.CreateInstance(Type.GetTypeFromProgID("Word.Application"));
        _wdApp.Visible = true;//Показываем
        //Поток, в котором будет проводиться экспорт
        var exportthread = new Thread(ExporterDelegate);
        //Начинаем экспорт
        exportthread.Start();
    }

    /// <summary>
    /// Делегат, выполняющий экспорт.
    /// </summary>
    private static void ExporterDelegate()
    {
        //Пытаемся создать новый документ
        try
        {
            _wdDoc = _wdApp.Documents.Add();
        }
        catch (Exception ex)
        {
            ExportCompleted?.Invoke();
            throw new Exception($"Ошибка при создании документа{_fileName}.", ex);
        }
        //Создаём в документе таблицу и строку заголовка
        CreateWordTable();
        //Перебор строк
        foreach (DataGridViewRow row in _dataGridView.Rows)
        {
            //На случай, если пользователю разрешено добавлять строки
            //Новую строку пропускаем
            if (row.IsNewRow) continue;
            //Добавляем из строки dgv данные в строку таблицы документа
            AddRow(row);
        }
        //Сохранение документа
        SaveDoc();
        //Закрываем документ
        _wdDoc.Close(false);
        //убираем ссылку на объект
        _wdDoc = null;
        //Выходим из приложения
        _wdApp.Quit();
        //убираем ссылку на объект
        _wdApp = null;
        //Если есть — вызываем метод окончания экспорта
        ExportCompleted?.Invoke();
    }

    /// <summary>
    /// Сохранение документа
    /// </summary>
    private static void SaveDoc()
    {
        //Формат сохранения файла в зависимости от расширения
        var fileFormat = _fileName.EndsWith("doc") ? 0 : 16;
        //Версия приложения, чтобы определить какой метод сохранения вызывать.
        var appVersion = float.Parse(_wdApp.Version.ToString(), CultureInfo.InvariantCulture);
        if (appVersion < 14)
        {
            //Если приложение старше Word 2010
            _wdDoc.SaveAs(_fileName, fileFormat, false, string.Empty, false);
        }
        else
        {
            _wdDoc.SaveAs2(_fileName, fileFormat, false, string.Empty, false);
        }
    }

    /// <summary>
    /// Добавление строки в таблицу документа
    /// </summary>
    /// <param name="row">Строка из DataGridView, данные из которой нужно добавить в документ</param>
    private static void AddRow(DataGridViewRow row)
    {
        dynamic wdRow = _wdDoc.Tables[1].Rows.Add();
        foreach (DataGridViewCell cell in row.Cells)
        {
            wdRow.Cells[cell.OwningColumn.DisplayIndex + 1].Range.Text = cell.Value.ToString();
        }
    }

    /// <summary>
    /// Создание таблицы в документе
    /// </summary>
    /// <param name="dgv">DataGridView из которого создаётся таблица</param>
    private static void CreateWordTable()
    {
        _wdTable = _wdDoc.Tables.Add(_wdDoc.Range, 1, _dataGridView.ColumnCount);
        foreach (DataGridViewColumn column in _dataGridView.Columns)
        {
            if (column.Index == -1) continue;
            _wdTable.Cell(1, column.DisplayIndex + 1).Range.Text = column.HeaderText;
        }
    }

}
}
