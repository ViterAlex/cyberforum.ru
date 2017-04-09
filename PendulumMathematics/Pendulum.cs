using System;

namespace PendulumMathematics {
	/// <summary>
	/// Модель математического маятника
	/// </summary>
	class Pendulum  {
		/// <summary>
		/// Длина маятника, м
		/// </summary>
		internal float Length { get; private set; }
		/// <summary>
		/// Период колебаний маятника, сек
		/// </summary>
		internal float T { get; private set; }
		/// <summary>
		/// Фаза колебаний маятника (0 — 2П), рад
		/// </summary>
		internal float Phase { get; private set; }

		private float A;//Амплитуда колебаний
		private System.Timers.Timer tmr;//Таймер для просчёта положения маятника в зависимости от времени
		private DateTime startTime;//Время запуска маятника
		/// <summary>
		/// Создание нового экземпляра маятника с заданной длиной
		/// </summary>
		/// <param name="length">Длина маятника в метрах</param>
		public Pendulum(float length) {
			this.Length = length;
			this.T = 2 * (float)(Math.PI * Math.Sqrt(this.Length / 9.80665)); 
			/// Максимальная амплитуда колебаний. Рассчитывается, исходя из
			/// максимального угла отклонения 8°
			A = this.Length * (float)Math.Sin(8 * Math.PI / 180);
			tmr = new System.Timers.Timer();
			tmr.Interval = 100;
			tmr.Elapsed += tmr_Elapsed;
		}
		/// <summary>
		/// Вычисление положения маятника в зависимости от времени
		/// </summary>
		void tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
			//фаза
			double phase = (e.SignalTime - startTime).TotalSeconds / T;
			/// Отклонение от вертикали
			/// Поскольку маятник начинает движение из положения равновесия, то 
			/// он движется по закону синуса
			float X = A * (float)Math.Sin(phase);
			//Генерируем событие
			OnOscillate(new OscillateEventArgs() { Scale = X / A });
			//Пересчёт фазы от 0 до 2П
			double n = phase / (2 * Math.PI);
			Phase = (float)((n - Math.Truncate(n)) * 2 * Math.PI);
		}
		/// <summary>
		/// Запуск колебаний маятника
		/// </summary>
		internal void Start() {
			startTime = DateTime.Now;
			tmr.Start();
		}

		public event EventHandler<OscillateEventArgs> Oscillate;
		protected virtual void OnOscillate(OscillateEventArgs e) {
			EventHandler<OscillateEventArgs> handler = Oscillate;
			if (handler != null) {
				handler(this, e);
			}
		}
		public override string ToString() {
			return string.Format("Длина: {0} м; Период: {1} с; Фаза: {2}", Length, T, Phase);
		}
	}

	class OscillateEventArgs : EventArgs {
		/// <summary>
		/// Отклонение маятника от состояния равновесия в процентах от амплитуды
		/// </summary>
		public float Scale;
	}
}
