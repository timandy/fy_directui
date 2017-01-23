using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace Microsoft.Drawing
{
    /// <summary>
    /// 颜色向量转换类
    /// Copyright (c) JajaSoft
    /// </summary>
    public class ColorVectorConverter : TypeConverter
    {
        /// <summary>
        /// 返回该转换器是否可以使用指定的上下文将给定类型的对象转换为此转换器的类型。
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext，提供格式上下文。</param>
        /// <param name="sourceType">一个 System.Type，表示要转换的类型。</param>
        /// <returns>如果该转换器能够执行转换，则为 true；否则为 false。</returns>
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return ((sourceType == typeof(string)) || base.CanConvertFrom(context, sourceType));
        }

        /// <summary>
        /// 返回此转换器是否可以使用指定的上下文将该对象转换为指定的类型。
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext，提供格式上下文。</param>
        /// <param name="destinationType">一个 System.Type，表示要转换到的类型。</param>
        /// <returns>如果该转换器能够执行转换，则为 true；否则为 false。</returns>
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return ((destinationType == typeof(InstanceDescriptor)) || base.CanConvertTo(context, destinationType));
        }

        /// <summary>
        /// 使用指定的上下文和区域性信息将给定的对象转换为此转换器的类型。
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext，提供格式上下文。</param>
        /// <param name="culture">用作当前区域性的 System.Globalization.CultureInfo。</param>
        /// <param name="value">要转换的 System.Object。</param>
        /// <returns>表示转换的 value 的 System.Object。</returns>
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            //NULL
            string str = value as string;
            if (str == null)
                return base.ConvertFrom(context, culture, value);

            //空字符串
            string trimStr = str.Trim();
            if (trimStr.Length <= 0)
                return ColorVector.Empty;

            //区域分隔符
            if (culture == null)
                culture = CultureInfo.CurrentCulture;
            char ch = culture.TextInfo.ListSeparator[0];

            //类型转换器
            TypeConverter longConverter = TypeDescriptor.GetConverter(typeof(long));
            TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));

            //不含分隔符
            if (trimStr.IndexOf(ch) == -1)
            {
                if (((trimStr[0] == '#') &&
                    (trimStr.Length == 13 || trimStr.Length == 17)) ||
                    ((trimStr.StartsWith("0x") || trimStr.StartsWith("0X") || trimStr.StartsWith("&h") || trimStr.StartsWith("&H")) &&
                    (trimStr.Length == 14 || trimStr.Length == 18)))
                    return ColorVector.FromArgb((long)longConverter.ConvertFromString(trimStr));
            }
            else//包含分隔符
            {
                string[] strArray = trimStr.Split(new char[] { ch });
                int[] numArray = new int[strArray.Length];
                for (int i = 0; i < numArray.Length; i++)
                    numArray[i] = (int)intConverter.ConvertFromString(context, culture, strArray[i]);

                switch (numArray.Length)
                {
                    case 3:
                        return ColorVector.FromArgb(numArray[0], numArray[1], numArray[2]);

                    case 4:
                        return ColorVector.FromArgb(numArray[0], numArray[1], numArray[2], numArray[3]);
                }
            }

            throw new ArgumentException("无效的颜色向量");
        }

        /// <summary>
        /// 使用指定的上下文和区域性信息将给定的值对象转换为指定的类型。
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext，提供格式上下文。</param>
        /// <param name="culture">System.Globalization.CultureInfo。如果传递 null，则采用当前区域性。</param>
        /// <param name="value">要转换的 System.Object。</param>
        /// <param name="destinationType">value 参数要转换成的 System.Type。</param>
        /// <returns>表示转换的 value 的 System.Object。</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == null)
            {
                throw new ArgumentNullException("destinationType");
            }
            if (value is ColorVector)
            {
                if (destinationType == typeof(string))//转换为string
                {
                    ColorVector colorVector = (ColorVector)value;

                    if (culture == null)
                        culture = CultureInfo.CurrentCulture;

                    string separator = culture.TextInfo.ListSeparator + " ";
                    TypeConverter intConverter = TypeDescriptor.GetConverter(typeof(int));

                    string[] strArray = new string[4];
                    strArray[0] = intConverter.ConvertToString(context, culture, colorVector.A);
                    strArray[1] = intConverter.ConvertToString(context, culture, colorVector.R);
                    strArray[2] = intConverter.ConvertToString(context, culture, colorVector.G);
                    strArray[3] = intConverter.ConvertToString(context, culture, colorVector.B);
                    return string.Join(separator, strArray);
                }
                if (destinationType == typeof(InstanceDescriptor))
                {
                    MemberInfo member = null;
                    object[] arguments = null;
                    ColorVector colorVector2 = (ColorVector)value;
                    if (colorVector2 == ColorVector.Empty)
                    {
                        member = typeof(ColorVector).GetField("Empty");
                    }
                    else
                    {
                        member = typeof(ColorVector).GetMethod("FromArgb", new Type[] { typeof(int), typeof(int), typeof(int), typeof(int) });
                        arguments = new object[] { colorVector2.A, colorVector2.R, colorVector2.G, colorVector2.B };
                    }

                    if (member != null)
                        return new InstanceDescriptor(member, arguments);
                }
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }


        /// <summary>
        /// 在已知对象的属性 (Property) 值集的情况下，使用指定的上下文创建与此 System.ComponentModel.TypeConverter 关联的类型的实例。
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext，提供格式上下文。</param>
        /// <param name="propertyValues">新属性 (Property) 值的 System.Collections.IDictionary。</param>
        /// <returns>一个 System.Object，表示给定的 System.Collections.IDictionary，或者如果无法创建该对象，则为 null。此方法始终返回 null。</returns>
        public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
        {
            if (propertyValues == null)
            {
                throw new ArgumentNullException("propertyValues");
            }
            object alpha = propertyValues["A"];
            object red = propertyValues["R"];
            object green = propertyValues["G"];
            object blue = propertyValues["B"];
            if (((alpha == null) || (red == null) || (green == null) || (blue == null))
                || (!(alpha is short) || !(red is short) || !(green is short) || !(blue is short)))
            {
                throw new ArgumentException("属性值为无效输入");
            }
            return ColorVector.FromArgb((int)(short)alpha, (int)(short)red, (int)(short)green, (int)(short)blue);
        }

        /// <summary>
        /// 返回有关更改该对象上的某个值是否需要使用指定的上下文调用 System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary) 以创建新值的情况。
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext，提供格式上下文。</param>
        /// <returns>如果更改此对象的属性需要调用 System.ComponentModel.TypeConverter.CreateInstance(System.Collections.IDictionary) 来创建新值，则为 true；否则为 false。</returns>
        public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// 使用指定的上下文返回值参数指定的数组类型的属性 (Property) 的集合。
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext，提供格式上下文。</param>
        /// <param name="value">一个 System.Object，指定要为其获取属性的数组类型。</param>
        /// <param name="attributes">用作筛选器的 System.Attribute 类型数组。</param>
        /// <returns>具有为此数据类型公开的属性的 System.ComponentModel.PropertyDescriptorCollection；或者如果没有属性，则为 null。</returns>
        public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
        {
            return TypeDescriptor.GetProperties(typeof(ColorVector), attributes).Sort(new string[] { "A", "R", "G", "B" });
        }

        /// <summary>
        /// 返回此对象是否支持属性。
        /// </summary>
        /// <param name="context">System.ComponentModel.ITypeDescriptorContext，提供格式上下文。</param>
        /// <returns>如果应调用 System.ComponentModel.TypeConverter.GetProperties(System.Object) 来查找此对象的属性，则为 true；否则为 false。</returns>
        public override bool GetPropertiesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
    }
}
