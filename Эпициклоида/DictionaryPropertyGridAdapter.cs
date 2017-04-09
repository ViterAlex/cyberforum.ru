using System;
using System.Collections;
using System.ComponentModel;

namespace Epicycloid {
	/// <summary>
	/// Класс для описания пользовательского типа данных. Чтобы PropertyGrid понимал как работать с нашими данными
	/// </summary>
	class DictionaryPropertyGridAdapter : ICustomTypeDescriptor {
		IDictionary idic;
		public DictionaryPropertyGridAdapter(System.Collections.IDictionary d) {
			idic = d;
		}
		public AttributeCollection GetAttributes() {
			return TypeDescriptor.GetAttributes(this, true);
		}

		public string GetClassName() {
			return TypeDescriptor.GetClassName(this, true);
		}

		public string GetComponentName() {
			return TypeDescriptor.GetComponentName(this, true);
		}

		public TypeConverter GetConverter() {
			return TypeDescriptor.GetConverter(this, true);
		}

		public EventDescriptor GetDefaultEvent() {
			return null;
		}

		public PropertyDescriptor GetDefaultProperty() {
			return null;
		}

		public object GetEditor(Type editorBaseType) {
			return TypeDescriptor.GetEditor(this, editorBaseType, true);
		}

		public EventDescriptorCollection GetEvents(Attribute[] attributes) {
			return TypeDescriptor.GetEvents(this, attributes, true);
		}

		public EventDescriptorCollection GetEvents() {
			return TypeDescriptor.GetEvents(this, true);
		}

		public PropertyDescriptorCollection GetProperties(Attribute[] attributes) {
			ArrayList properties = new ArrayList();
			foreach (DictionaryEntry e in idic) {
				properties.Add(new DictionaryPropertyDescriptor(idic, e.Key));
			}

			PropertyDescriptor[] props =
				(PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));

			return new PropertyDescriptorCollection(props);
		}

		public PropertyDescriptorCollection GetProperties() {
			return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
		}

		public object GetPropertyOwner(System.ComponentModel.PropertyDescriptor pd) {
			return idic;
		}
	}
}
