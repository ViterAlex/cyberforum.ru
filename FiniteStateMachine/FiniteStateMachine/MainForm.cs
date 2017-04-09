using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FiniteStateMachine {
	public partial class MainForm : Form {
		public MainForm() {
			InitializeComponent();
			PrintState();
		}
enum StateType { oD, cD, cU, oU }
StateType State = StateType.oD;
/// Нажатие кнопок
private void button_Click(object sender, EventArgs e) {
	Button btn = sender as Button;
	switch (btn.Text) {
		case "o":
			co();
			break;
		case "c":
			co();
			break;
		case "U":
			UD();
			break;
		case "D":
			UD();
			break;
	}
}
/// <summary>Функция перехода по горизонтали</summary>
/// <param name="printstate">Печатать ли состояние?</param>
void co(bool printstate = true) {
	switch (State) {
		case StateType.oD:
			State = StateType.cD;
			break;
		case StateType.cD:
			State = StateType.oD;
			break;
		case StateType.cU:
			State = StateType.oU;
			break;
		case StateType.oU:
			State = StateType.cU;
			break;
	}
	if (printstate) PrintState();
}

private void PrintState() {
	Console.WriteLine("Текущее состояние {0}", Enum.GetName(typeof(StateType), State));
}
/// <summary>Функция перехода по вертикали</summary>
/// <param name="printstate">Печатать ли состояние?</param>
void UD(bool printstate = true) {
	switch (State) {
		case StateType.cD:
			State = StateType.cU;
			break;
		case StateType.cU:
			State = StateType.cD;
			break;
		default:
			co();
			UD(false);
			break;
	}
	if (printstate) PrintState();
}
	}
}
