using System;

namespace AlarmClockNamespace {
	class AlarmClock {
		private int minute;

		public int Minute {
			get { return minute; }
		}
		private int hour;

		public int Hour {
			get { return hour; }
		}
		private int alarmMinute;

		public int AlarmMinute {
			get { return alarmMinute; }
		}
		private int alarmHour;

		public int AlarmHour {
			get { return alarmHour; }
		}
		private bool alarmMode;

		public bool AlarmMode {
			get { return alarmMode; }
			set { alarmMode = value; }
		}
		public AlarmClock() {
			hour = DateTime.Now.Hour;
			minute = DateTime.Now.Minute;
		}

		public override string ToString() {
			return string.Format("{0:00}:{1:00}", alarmMode ? alarmHour : hour, alarmMode ? alarmMinute : minute);
		}

		public void SetHours() {
			if (alarmMode)
				alarmHour = (alarmHour + 1) % 24;
			else hour = (hour + 1) % 24;
		}

		public void SetMinutes() {
			if (alarmMode)
				alarmMinute = (alarmMinute + 1) % 60;
			else minute = (minute + 1) % 60;
		}
	}
}
