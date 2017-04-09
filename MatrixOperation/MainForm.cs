using System;
using System.Drawing;
using System.Windows.Forms;

namespace MatrixOperation
{
    public partial class MainForm : Form
    {
        //Массивы, представляющие матрицы
        private int[,] _first;
        private int[,] _second;
        private int[,] _result;
        private Point _minIndex;//Индексы минимального значения
        private Point _maxIndex;//Индексы максимального значения

        public MainForm()
        {
            InitializeComponent();
            firstColumnsCountNud_ValueChanged(firstRowsCountNud, new EventArgs());
            secondColumnsCountNud_ValueChanged(secondColumnsCountNud, new EventArgs());
        }

        #region Методы-обработчики событий контролов формы

        private void firstRowsCountNud_ValueChanged(object sender, EventArgs e)
        {
            _first = new int[(int)firstRowsCountNud.Value, (int)firstColumnsCountNud.Value];
            FillWithRandoms(_first);
            FillDgvs(firstMatrixDgv, _first);
            UpdateMenu();
        }

        private void firstColumnsCountNud_ValueChanged(object sender, EventArgs e)
        {
            _first = new int[(int)firstRowsCountNud.Value, (int)firstColumnsCountNud.Value];
            FillWithRandoms(_first);
            FillDgvs(firstMatrixDgv, _first);
            UpdateMenu();
        }

        private void secondRowsCountNud_ValueChanged(object sender, EventArgs e)
        {
            _second = new int[(int)secondRowsCountNud.Value, (int)secondColumnsCountNud.Value];
            FillWithRandoms(_second);
            FillDgvs(secondMatrixDgv, _second);
            UpdateMenu();
        }

        private void secondColumnsCountNud_ValueChanged(object sender, EventArgs e)
        {
            _second = new int[(int)secondRowsCountNud.Value, (int)secondColumnsCountNud.Value];
            FillWithRandoms(_second);
            FillDgvs(secondMatrixDgv, _second);
            UpdateMenu();
        }

        private void sumMatriciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SumMatricies(_first, _second);
            FillDgvs(resultMatrixDgv, _result);
            UpdateMenu();
        }

        private void subtractMatriciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubtractMatricies(_first, _second);
            FillDgvs(resultMatrixDgv, _result);
            UpdateMenu();
        }

        private void multiplyMatriciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MultiplyMatricies(_first, _second);
            FillDgvs(resultMatrixDgv, _result);
            UpdateMenu();
        }

        private void minToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindMin(_result);
            resultMatrixDgv[_minIndex.Y, _minIndex.X].Style.BackColor = Color.PaleVioletRed;
        }

        private void maxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindMax(_result);
            resultMatrixDgv[_maxIndex.Y, _maxIndex.X].Style.BackColor = Color.DodgerBlue;
        }

        #endregion

        /// <summary>Обновление состояний пунктов меню.</summary>
        /// <remarks>Например, пункты «Умножить» и «Сложить» будут неактивны, если матрицы не одного размера.</remarks>
        private void UpdateMenu()
        {
            if (_first == null || _second == null)
            {
                sumMatriciesToolStripMenuItem.Enabled = false;
                subtractMatriciesToolStripMenuItem.Enabled = false;
                multiplyMatriciesToolStripMenuItem.Enabled = false;
                minToolStripMenuItem.Enabled = false;
                maxToolStripMenuItem.Enabled = false;
                return;
            }
            //Для сложения и вычитания матрицы должны быть одного размера
            sumMatriciesToolStripMenuItem.Enabled = _first.GetLength(0) == _second.GetLength(0) && _first.GetLength(1) == _second.GetLength(1);
            subtractMatriciesToolStripMenuItem.Enabled = _first.GetLength(0) == _second.GetLength(0) && _first.GetLength(1) == _second.GetLength(1);
            //Для умножения количество столбцов первой матрицы должно быть равно количеству строк второй.
            multiplyMatriciesToolStripMenuItem.Enabled = _first.GetLength(1) == _second.GetLength(0);
            minToolStripMenuItem.Enabled = resultMatrixDgv.RowCount != 0 && resultMatrixDgv.ColumnCount != 0;
            maxToolStripMenuItem.Enabled = resultMatrixDgv.RowCount != 0 && resultMatrixDgv.ColumnCount != 0;
        }

        #region Методы действий над матрицами
        
        /// <summary>Заполнение DataGridView из двумерного массива.</summary>
        /// <param name="dgv">DataGridView, который нужно заполнить.</param>
        /// <param name="matrix">Двумерный массив, которым нужно заполнить.</param>
        private void FillDgvs(DataGridView dgv, int[,] matrix)
        {
            if (matrix == null) return;
            //Очистка
            dgv.Columns.Clear();
            //Очистка таблицы результатов
            resultMatrixDgv.Columns.Clear();
            //Создание новой таблицы
            dgv.ColumnCount = matrix.GetLength(1);
            dgv.RowCount = matrix.GetLength(0);
            //Заполнение таблицы
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    dgv[j, i].Value = matrix[i, j];
        }

        /// <summary>Заполнение массива случайными целыми числами.</summary>
        /// <param name="matrix">Массив для заполнения.</param>
        private static void FillWithRandoms(int[,] matrix)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
                    matrix[i, j] = rnd.Next(1, 1000);
        }

        /// <summary>Сложение матриц.</summary>
        /// <param name="m1">Первая матрица.</param>
        /// <param name="m2">Вторая матрица.</param>
        private void SumMatricies(int[,] m1, int[,] m2)
        {
            _result = new int[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < _result.GetLength(0); i++)
                for (int j = 0; j < _result.GetLength(1); j++)
                    _result[i, j] = m1[i, j] + m2[i, j];
        }

        /// <summary>Вычитание матриц.</summary>
        /// <param name="m1">Первая матрица.</param>
        /// <param name="m2">Вторая матрица.</param>
        private void SubtractMatricies(int[,] m1, int[,] m2)
        {
            _result = new int[m2.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < _result.GetLength(0); i++)
                for (int j = 0; j < _result.GetLength(1); j++)
                    _result[i, j] = m1[i, j] - m2[i, j];
        }

        /// <summary>Перемножение матриц.</summary>
        /// <param name="m1">Первая матрица.</param>
        /// <param name="m2">Вторая матрица.</param>
        private void MultiplyMatricies(int[,] m1, int[,] m2)
        {
            //Результирующая матрица. Количество строк как в первой, а столбцов как во второй
            _result = new int[m1.GetLength(0), m2.GetLength(1)];
            for (int i = 0; i < _result.GetLength(0); i++)
                for (int j = 0; j < _result.GetLength(1); j++)
                    _result[i, j] = MultiplyRowAndCol(m1, i, m2, j);
        }

        /// <summary>Умножение строки одной матрицы на столбец второй.</summary>
        /// <param name="rows">Матрица, из которой брать строку.</param>
        /// <param name="row">Индекс строки.</param>
        /// <param name="cols">Матрица, из которой брать столбец.</param>
        /// <param name="col">Индекс столбца.</param>
        /// <returns>Возвращает скалярное произведение вектора строки на вектор столбца.</returns>
        private static int MultiplyRowAndCol(int[,] rows, int row, int[,] cols, int col)
        {
            int result = 0;
            for (int i = 0; i < cols.GetLength(0); i++)
                result += rows[row, i] * cols[i, col];
            return result;
        }

        /// <summary>Нахождение минимального числа в матрице.</summary>
        /// <param name="m">Матрица.</param>
        private void FindMin(int[,] m)
        {
            var min = int.MaxValue;
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    if (m[i, j] < min)
                    {
                        min = m[i, j];
                        _minIndex = new Point(i, j);
                    }
        }

        /// <summary>Нахождение максимального числа в матрице.</summary>
        /// <param name="m">Матрица.</param>
        private void FindMax(int[,] m)
        {
            var max = int.MinValue;
            for (int i = 0; i < m.GetLength(0); i++)
                for (int j = 0; j < m.GetLength(1); j++)
                    if (m[i, j] > max)
                    {
                        max = m[i, j];
                        _maxIndex = new Point(i, j);
                    }
        } 
        #endregion
    }
}
