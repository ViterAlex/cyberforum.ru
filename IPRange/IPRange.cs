using System;
using System.Net;

namespace ConsoleApplication1 {
	internal class IPRange {
		internal readonly IPAddress LowerBound;
		internal readonly IPAddress UpperBound;

		internal IPRange(IPAddress lowerBound, IPAddress upperBound) {
			if (lowerBound.ToInteger() > upperBound.ToInteger())
				throw new ArgumentException("Нижний адрес должен быть меньше верхнего.");
			this.LowerBound = lowerBound;
			this.UpperBound = upperBound;
		}

		internal bool Contains(IPAddress address) {
			return (address.ToInteger() < UpperBound.ToInteger()) && (address.ToInteger() > LowerBound.ToInteger());
		}

		/// <summary>
		/// Определение адресов, принадлежащих сразу двум диапазонам
		/// </summary>
		/// <param name="range">Заданный диапазон адресов</param>
		/// <returns>Массив диапазонов, включающих адреса, принадлежащие только одному из диапазонов</returns>
		internal IPRange[] Exclude(IPRange range) {
			IPRange[] result = new IPRange[0];
			//Верхняя граница заданного диапазона попадает в данный диапазон
			if (this.Contains(range.UpperBound) && range.Contains(this.LowerBound)) {
				Array.Resize<IPRange>(ref result, 2);
				result[0] = new IPRange(range.LowerBound, this.LowerBound);
				result[1] = new IPRange(range.UpperBound, this.UpperBound);
				return result;
			}
			//Нижняя граница заданного диапазона попадает в данный диапазон
			if (this.Contains(range.LowerBound) && range.Contains(this.UpperBound)) {
				Array.Resize<IPRange>(ref result, 2);
				result[0] = new IPRange(this.LowerBound, range.LowerBound);
				result[1] = new IPRange(this.UpperBound, range.UpperBound);
				return result;
			}
			//Весь заданный диапазон попадает внутрь данного диапазона
			if (this.Contains(range.UpperBound) && this.Contains(range.LowerBound)) {
				Array.Resize<IPRange>(ref result, 2);
				result[0] = new IPRange(this.LowerBound, range.LowerBound);
				result[1] = new IPRange(range.UpperBound, this.UpperBound);
				return result;
			}
			//Весь данный диапазон попадает внутрь заданного диапазона
			if (range.Contains(this.UpperBound) && range.Contains(this.LowerBound)) {
				Array.Resize<IPRange>(ref result, 2);
				result[0] = new IPRange(range.LowerBound, this.LowerBound);
				result[1] = new IPRange(this.UpperBound, range.UpperBound);
				return result;
			}
			return result;
		}

		public override string ToString() {
			return string.Format("{0} - {1}", LowerBound.ToString(), UpperBound.ToString());
		}

		/// <summary>
		/// Получение диапазона адресов из строковой записи
		/// </summary>
		/// <param name="stringRange">Строковое представление диапазона адресов вида xxx.xxx.xxx.xxx-xxx.xxx.xxx.xxx</param>
		/// <returns>Экземпляр класса IPRange</returns>
		internal static IPRange Parse(string stringRange) {
			IPAddress ipL, ipU;
			string[] addresses = stringRange.Split('-');
			ipL = IPAddress.Parse(addresses[0]);
			ipU = IPAddress.Parse(addresses[1]);
			return new IPRange(ipL, ipU);
		}
	}

	public static class IPAddressExtension {
		public static int ToInteger(this IPAddress address) {
			byte[] bytes = address.GetAddressBytes();
			return (int)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
		}
	}
}
