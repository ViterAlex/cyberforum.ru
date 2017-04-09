using System;
using System.Collections;
using System.ComponentModel;

namespace Epicycloid {
	/// <summary>
	/// Класс для вывода соответствующих свойств нашего типа.
	/// </summary>
	class DictionaryPropertyDescriptor : PropertyDescriptor {
		IDictionary idic;
		object key;
		public DictionaryPropertyDescriptor(IDictionary d, object key)
			: base(key.ToString(), null) {
			idic = d;
			this.key = key;
		}
		public override bool CanResetValue(object component) {
			return false;
		}

		public override Type ComponentType {
			get { return null; }
		}

		public override object GetValue(object component) {
			return idic[key];
		}

		public override bool IsReadOnly {
			get { return false; }
		}

		public override Type PropertyType {
			get { return idic[key].GetType(); }
		}

		public override void ResetValue(object component) {

		}

		public override void SetValue(object component, object value) {
			idic[key] = value;
		}

		public override bool ShouldSerializeValue(object component) {
			return false;
		}
	}
}
