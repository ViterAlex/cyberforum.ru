using System;
using System.Text;

namespace DiagonalSnakeArray {
	class Program {
		static void Main(string[] args) {
			double[,] ar = new double[4,4];
			FillArray(ar, 1);
			Console.WriteLine(ArrToString<double>(ar));
			Console.Read();
		}

		/// <summary>
		/// Метод для заполнения указанного массива змейкой по диагонали снизу вверх, справа налево.
		/// </summary>
		/// <param name="ar">Массив для заполнения</param>
		/// <param name="value">Стартовое значение</param>
		static void FillArray(double[,] ar, double value) {
			int iMax = ar.GetLength(0) - 1, jMax = ar.GetLength(1) - 1;//Максимальные значения индексов
			int count = 0;//Количество шагов по диагонали
			int dir = 1;//Направление обхода
			int i = ar.GetLength(0) - 1, j = ar.GetLength(1) - 1;//Начальные значения индексов
			ar[i, j] = value++;//Первое значение
			System.Diagnostics.Debug.WriteLine(ArrToString<double>(ar));
			do {
if ((i == iMax || i == 0) && j!=0) {//Граничные условия. Первый и последний столбец
	j--;
}
else if ((j == jMax || j == 0) && i!=0) {//Граничные условия. Первая и последняя строка
	i--;
}
				ar[i, j] = value++;
				System.Diagnostics.Debug.WriteLine(ArrToString<double>(ar));

				if (i == 0 && j == 0) break;
				count = Math.Abs(i - j);
				while (count-- != 0) {
					i -= dir; j += dir;
					ar[i, j] = value++;
					System.Diagnostics.Debug.WriteLine(ArrToString<double>(ar));

				}
				dir *= -1;
			} while (true);
		}

		private static string ArrToString<T>(T[,] ar) {
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < ar.GetLength(0); i++) {
				for (int j = 0; j < ar.GetLength(1); j++) {
					sb.AppendFormat("{0,-4}", ar[j, i].ToString());
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}
	}
}
