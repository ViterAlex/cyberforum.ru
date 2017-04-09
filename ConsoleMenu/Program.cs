using System;
using System.Collections.Generic;

namespace ConsoleMenuApplication {
	class Program {
		static void Main(string[] args) {
			ConsoleMenu cm = new ConsoleMenu(OneDArray, TwoDArray, JaggedArray);
			cm.Show(false);
		}

		static void OneDArray() { Console.WriteLine("Здесь необходимо реализовать ввод и обработку одномерного массива"); }
		static void TwoDArray() { Console.WriteLine("Здесь необходимо реализовать ввод и обработку двумерного массива"); }
		static void JaggedArray() { Console.WriteLine("Здесь необходимо реализовать ввод и обработку \"рваного\" массива"); }
	}

	class ConsoleMenu {
		public delegate void MenuMethod();
		private List<MenuMethod> Methods;
		public ConsoleMenu(params MenuMethod[] methods) {
			Methods = new List<MenuMethod>();
			Methods.AddRange(methods);
			ItemColor = ConsoleColor.Yellow;
			SelectionColor = ConsoleColor.Blue;
		}
		public ConsoleColor ItemColor;
		public ConsoleColor SelectionColor;
		public int SelectedItem { get; private set; }
		private int top;//Положение первой строки меню

		public void Show(bool addEmptyLineBefore = true) {
			top = Console.CursorTop;
			if (addEmptyLineBefore) {
				Console.WriteLine();
				top++;
			}
			Console.ForegroundColor = ItemColor;
			for (int i = 0; i < Methods.Count; i++) {
				if (i == SelectedItem) {
					Console.BackgroundColor = SelectionColor;
				}
				else {
					Console.ResetColor();
					Console.ForegroundColor = ItemColor;
				}
				Console.WriteLine(Methods[i].Method.Name);
			}
			Console.ResetColor();
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine("Нажмите любую клавишу для выхода...");
			Console.ResetColor();
			WaitForInput();
		}

		private void WaitForInput() {
			ConsoleKeyInfo cki = Console.ReadKey();
				switch (cki.Key) {
					case ConsoleKey.DownArrow:
						MoveDown();
						break;
					case ConsoleKey.UpArrow:
						MoveUp();
						break;
					case ConsoleKey.Enter:
						Methods[SelectedItem]();
						Show();
						break;
				}
		}

		private void MoveDown() {
			SelectedItem = SelectedItem == Methods.Count - 1 ? 0 : SelectedItem + 1;
			Console.SetCursorPosition(0, top);
			Show(false);
		}

		private void MoveUp() {
			SelectedItem = SelectedItem == 0 ? Methods.Count - 1 : SelectedItem - 1;
			Console.SetCursorPosition(0, top);
			Show(false);
		}
	}
}
