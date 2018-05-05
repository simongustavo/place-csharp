using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;

namespace Place
{
	public static class ObjectHelper
	{
	  public static IDictionary<string, object> ToDictionary(this object source)
	  {
	    return source.ToDictionary<object>();
	  }

	  public static IDictionary<string, T> ToDictionary<T>(this object source)
	  {
	    if (source == null) ThrowExceptionWhenSourceArgumentIsNull();

	    var dictionary = new Dictionary<string, T>();
	    foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(source))
	    {
	      object value = property.GetValue(source);
	      if (IsOfType<T>(value))
	      {
	        dictionary.Add(property.Name, (T)value);
	      }
	    }
	    return dictionary;
	  }

	  private static bool IsOfType<T>(object value)
	  {
	    return value is T;
	  }

	  private static void ThrowExceptionWhenSourceArgumentIsNull()
	  {
	    throw new NullReferenceException("Unable to convert anonymous object to a dictionary. The source anonymous object is null.");
	  }

	  public static string GetQueryString(object obj) {
		  var properties = from p in obj.GetType().GetProperties()
						   where p.GetValue(obj, null) != null
						   select p.Name + "=" + WebUtility.UrlEncode(p.GetValue(obj, null).ToString());

		  return String.Join("&", properties.ToArray());
		}
	}
}
