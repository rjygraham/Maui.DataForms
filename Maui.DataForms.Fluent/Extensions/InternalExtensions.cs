using System.Linq.Expressions;
using System.Reflection;

namespace Maui.DataForms.Extensions;

public static class InternalExtensions
{
    internal static Func<TModel, TProperty> CreatePropertydGetDelegate<TModel, TProperty>(this PropertyInfo propertyInfo)
    {
        var instExp = Expression.Parameter(typeof(TModel));
        var fieldExp = Expression.Property(instExp, propertyInfo);
        return Expression.Lambda<Func<TModel, TProperty>>(fieldExp, instExp).Compile();
    }

    internal static Action<TModel, TProperty> CreatePropertydSetDelegate<TModel, TProperty>(this PropertyInfo propertyInfo)
    {
        var instanceParameter = Expression.Parameter(typeof(TModel));
        var valueParameter = Expression.Parameter(typeof(TProperty));
        var field = Expression.Property(instanceParameter, propertyInfo);
        var assign = Expression.Assign(field, valueParameter);

        return Expression.Lambda<Action<TModel, TProperty>>(assign, instanceParameter, valueParameter).Compile();
    }

    internal static Func<TModel, TProperty> CreateFieldGetDelegate<TModel, TProperty>(this FieldInfo fieldInfo)
    {
        var instExp = Expression.Parameter(typeof(TModel));
        var fieldExp = Expression.Field(instExp, fieldInfo);
        return Expression.Lambda<Func<TModel, TProperty>>(fieldExp, instExp).Compile();
    }

    internal static Action<TModel, TProperty> CreateFieldSetDelegate<TModel, TProperty>(this FieldInfo fieldInfo)
    {
        var instanceParameter = Expression.Parameter(typeof(TModel));
        var valueParameter = Expression.Parameter(typeof(TProperty));
        var field = Expression.Field(instanceParameter, fieldInfo);
        var assign = Expression.Assign(field, valueParameter);

        return Expression.Lambda<Action<TModel, TProperty>>(assign, instanceParameter, valueParameter).Compile();
    }

    /// <summary>
	/// Gets a MemberInfo from a member expression.
	/// </summary>
	public static MemberInfo GetMember<TModel, TProperty>(this Expression<Func<TModel, TProperty>> expression)
    {
        var memberExp = RemoveUnary(expression.Body) as MemberExpression;

        if (memberExp == null)
        {
            return null;
        }

        Expression currentExpr = memberExp.Expression;

        // Unwind the expression to get the root object that the expression acts upon.
        while (true)
        {
            currentExpr = RemoveUnary(currentExpr);

            if (currentExpr != null && currentExpr.NodeType == ExpressionType.MemberAccess)
            {
                currentExpr = ((MemberExpression)currentExpr).Expression;
            }
            else
            {
                break;
            }
        }

        if (currentExpr == null || currentExpr.NodeType != ExpressionType.Parameter)
        {
            return null; // We don't care if we're not acting upon the model instance.
        }

        return memberExp.Member;
    }

    private static Expression RemoveUnary(Expression toUnwrap)
    {
        if (toUnwrap is UnaryExpression)
        {
            return ((UnaryExpression)toUnwrap).Operand;
        }

        return toUnwrap;
    }
}
