using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace CSVtoPARNamespace {
	public class CSVProcess : IDisposable {
		private DataTable csvData;//ТАблица с данными из csv-файла
		private const char SEPARATOR = ';';
		//Имена столбцов
		public string[] ColumnsNames {
			get {
				return csvData.Columns.Cast<DataColumn>().Select(c => c.ColumnName).ToArray<string>();
			}
		}

		//Максимальный номер строки
		public int RowsCount {
			get {
				return csvData.Rows.Count;
			}
		}

		//Конструктор, принимающий имя csv-файла для обработки
		public CSVProcess(string filename) {
			csvData = new DataTable();
			string[] lines = System.IO.File.ReadAllLines(filename, Encoding.Default);
			string[] names = lines[7].Split(SEPARATOR);


			for (int i = 1; i < names.Length && i <= 3; i++) {
				csvData.Columns.Add(names[i], typeof(Int32));
			}

			for (int i = 9; i < lines.Length; i++) {
				string[] source = lines[i].Split(SEPARATOR);// разбивка строки из файла в массив
				string[] dest = new string[csvData.Columns.Count];//массив для выбора значений
				Array.Copy(source, 1, dest, 0, dest.Length);//копирование данных из 
				csvData.Rows.Add(dest);

			}
		}

		//Метод возвращает новую таблицу данных, состоящую из выбранных строк и столбцов
		public DataTable GetDataTablePart(int startRowIndex, int endRowIndex, int[] columnsIndices) {
			//Если нужно вернуть всю таблицу
			if (endRowIndex - startRowIndex + 1 == csvData.Rows.Count && columnsIndices.Length == csvData.Columns.Count)
				return csvData.Copy();

			DataTable dt = new DataTable();

			foreach (int item in columnsIndices) {
				DataColumn dc = (csvData.Columns[item]);
				dt.Columns.Add(dc.ColumnName, dc.DataType);
			}

			for (int i = startRowIndex - 1; i < endRowIndex; i++)
				dt.ImportRow(csvData.Rows[i]);

			return dt;
		}


		public void Dispose() {
			csvData.Dispose();
			csvData = null;
		}
	}
}
