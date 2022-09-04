using MauiForms.Forms.Extensions;
using System.Collections.Concurrent;
using System.Reflection;

namespace MauiForms.Forms;

internal static class FormFieldAccessorCache
{
    private static readonly ConcurrentDictionary<Key, Delegate> cache = new ConcurrentDictionary<Key, Delegate>();

    public static Func<TModel, TProperty> GetCachedGetter<TModel, TProperty>(MemberInfo memberInfo)
    {
        var key = new Key(memberInfo, true, false);
        return (Func<TModel, TProperty>)cache.GetOrAdd(key, CreateGetDelegate<TModel, TProperty>(memberInfo));
    }

    public static Action<TModel, TProperty> GetCachedSetter<TModel, TProperty>(MemberInfo memberInfo)
    {
        var key = new Key(memberInfo, true, false);
        return (Action<TModel, TProperty>)cache.GetOrAdd(key, CreateSetDelegate<TModel, TProperty>(memberInfo));
    }

    private static Func<TModel, TProperty> CreateGetDelegate<TModel, TProperty>(MemberInfo memberInfo)
    {
        if (memberInfo is PropertyInfo propertyInfo)
        {
            return propertyInfo.CreatePropertydGetDelegate<TModel, TProperty>();
        }
        else if (memberInfo is FieldInfo fieldInfo)
        {
            return fieldInfo.CreateFieldGetDelegate<TModel, TProperty>();
        }

        throw new ArgumentException($"Value must be of type {nameof(PropertyInfo)} or {nameof(FieldInfo)}", nameof(memberInfo));
    }
    private static Action<TModel, TProperty> CreateSetDelegate<TModel, TProperty>(MemberInfo memberInfo)
    {
        if (memberInfo is PropertyInfo propertyInfo)
        {
            return propertyInfo.CreatePropertydSetDelegate<TModel, TProperty>();
        }
        else if (memberInfo is FieldInfo fieldInfo)
        {
            return fieldInfo.CreateFieldSetDelegate<TModel, TProperty>();
        }

        throw new ArgumentException($"Value must be of type {nameof(PropertyInfo)} or {nameof(FieldInfo)}", nameof(memberInfo));
    }

    private class Key
    {
        private readonly MemberInfo memberInfo;
        private readonly bool isGet;
        private readonly bool isSet;

        public Key(MemberInfo memberInfo, bool isGet, bool isSet)
        {
            this.memberInfo = memberInfo;
            this.isGet = isGet;
            this.isSet = isSet;
        }
    }
}
