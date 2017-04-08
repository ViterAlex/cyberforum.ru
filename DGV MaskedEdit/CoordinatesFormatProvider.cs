using System;

namespace DGVMaskedEdit {
	class CoordinatesFormatProvider : IFormatProvider, ICustomFormatter {
		//Метод интерфейса IFormatProvider, определяющий тип форматируемых данных.
		//В данном случае, если тип данных будет ICustomFormatter, то их будем форматировать.
		//Иначе — оставляем всё как есть
		public object GetFormat(Type formatType) {
			if (formatType == typeof(ICustomFormatter))
				return this;
			else
				return null;
		}

		//Метод интерфейса ICustomFormatter
		//Именно здесь и будем работать с данными.
		//Для долготы будем использовать lat (от latitude)
		//Для широты — lon (от longitude)
		public string Format(string format, object arg, IFormatProvider formatProvider) {
			if (arg == null || arg.ToString().Equals(string.Empty)) return string.Empty;
			string fmt = format.ToLower();
			int n;//Количество цифр в первом разряде (для долготы это 3 цифры, для широты — 2)
			if (fmt == "lon")
				n = 2;
			else if (fmt == "lat")
				n = 3;
			else
				throw new FormatException(string.Format("Формат {0} неверный", fmt));
			string val = arg.ToString();
			return string.Format("{0}'{1}'{2},{3}", val.Substring(0, n), val.Substring(n, 2), val.Substring(n + 2, 2), val.Substring(n + 2 + 2));
		}
	}
}
