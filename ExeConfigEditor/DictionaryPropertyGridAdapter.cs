using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;


namespace ExeConfigEditor
{
    class DictionaryPropertyGridAdapter : ICustomTypeDescriptor
    {
        IDictionary _dictionary;

        public DictionaryPropertyGridAdapter(IDictionary d)
        {
            _dictionary = d;
        }

        public AttributeCollection GetAttributes()
        {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public EventDescriptorCollection GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            ArrayList properties = new ArrayList();
            foreach (DictionaryEntry ent in _dictionary)
            {
                properties.Add(new DictionaryPropertyDescriptor(_dictionary, ent.Key));
            }

            PropertyDescriptor[] props = (PropertyDescriptor[])properties.ToArray(typeof(PropertyDescriptor));
            return new PropertyDescriptorCollection(props);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return _dictionary;
        }
    }

    internal class DictionaryPropertyDescriptor : PropertyDescriptor
    {
        IDictionary _dictionary;
        object _key;

        internal DictionaryPropertyDescriptor(IDictionary d, object key) : base(key.ToString(), null)
        {
            _dictionary = d;
            _key = key;
        }

        public override Type ComponentType => null;

        public override bool IsReadOnly => false;

        public override Type PropertyType
        {
            get
            {
                string ValueString = _dictionary[_key].ToString();
                if (bool.TryParse(ValueString.ToLower(), out _))
                {
                    return typeof(bool);
                }
                else if (int.TryParse(ValueString, out _))
                {
                    return typeof(int);
                }
                else if (float.TryParse(ValueString, out _))
                {
                    return typeof(float);
                }
                else if (TimeSpan.TryParse(ValueString, out _))
                {
                    return typeof(TimeSpan);
                }
                else if(DateTime.TryParse(ValueString, out _))
                {
                    return typeof(DateTime);
                }
                else if (Color.FromName(ValueString).IsKnownColor)
                {
                    _dictionary[_key] = Color.FromName(ValueString);
                    return typeof(Color);
                }
                else
                {
                    return _dictionary[_key].GetType();
                }
            }
        }

        public override bool CanResetValue(object component) => false;

        public override object GetValue(object component)
        {
            return _dictionary[_key];
        }

        public override void ResetValue(object component) { }

        public override void SetValue(object component, object value) => _dictionary[_key] = value;

        public override bool ShouldSerializeValue(object component) => false;
    }
}
