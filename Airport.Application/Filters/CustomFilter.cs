using Airport.Domain.Enums;
using Airport.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Application.Filters;

public static class CustomFilter
{
    private static Expression<Func<T, bool>> GetFilterExpressions<T>(Filter filter)
    {

        // Here We create X=>
        var paramter = Expression.Parameter(typeof(T));
        // Here We create X.FirstName
        var propName = Expression.PropertyOrField(paramter, filter.PropertyName);
        // Here We create "Jon" Constant
        var targetType = propName.Type;
        if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Nullable<>))
            targetType = Nullable.GetUnderlyingType(targetType);
        var constExpression = Expression.Constant(Convert.ChangeType(filter.Value, targetType), propName.Type);
        Expression filterExpression;

        // Here We Create the Binary Operator Like == or > and etc.
        switch (filter.Operation)
        {
            case Operator.Eq:
                filterExpression = Expression.Equal(propName, constExpression);
                break;
            case Operator.GtOrEq:
                filterExpression = Expression.GreaterThanOrEqual(propName, constExpression);
                break;
            case Operator.LtorEq:
                filterExpression = Expression.LessThanOrEqual(propName, constExpression);
                break;
            case Operator.Gt:
                filterExpression = Expression.GreaterThan(propName, constExpression);
                break;
            case Operator.Lt:
                filterExpression = Expression.LessThan(propName, constExpression);
                break;
            case Operator.NotEq:
                filterExpression = Expression.NotEqual(propName, constExpression);
                break;
            case Operator.Conatains:
                //if (filter.Value.GetType() != typeof(string))
                //    throw new InvalidFilterCriteriaException();
                var containsMethodInfo = typeof(string).GetMethod(nameof(string.Contains), new Type[] { typeof(string) });
                filterExpression = Expression.Call(propName, containsMethodInfo, constExpression);
                break;
            default:
                throw new InvalidOperationException();
        }
        // Here We Put Every thing Together
        // X=> X.FirstName == "Jon"
        return Expression.Lambda<Func<T, bool>>(filterExpression, paramter);
    }

    private static Expression<Func<T, object>> GetSortExpression<T>(Sort sort)
    {
        var prop = Expression.Parameter(typeof(T));
        var property = Expression.PropertyOrField(prop, sort.PropertyName);
        return Expression.Lambda<Func<T, object>>(property, prop);
    }

    public static async Task<IEnumerable<T>> ApplyFilter<T>(this IQueryable<T> query,
        QueryCriteria queryCriteria)
    {
        if (queryCriteria is not null)
        {
            if (queryCriteria.Filters is not null)
            {
                foreach (var filter in queryCriteria.Filters)
                {
                    query = query.Where(GetFilterExpressions<T>(filter));
                }
            }

            if (queryCriteria.Sorts is not null)
            {
                foreach (var sort in queryCriteria.Sorts)
                {
                    query = sort.IsAscending ?
                    query.OrderBy(GetSortExpression<T>(sort)) :
                    query.OrderByDescending(GetSortExpression<T>(sort));
                }
            }

            //return await query.Skip(queryCriteria.Skip)
            //                  .Take(queryCriteria.Take)
            //                  .ToListAsync();
        }
        else
        {
            //return await query.ToListAsync();
        }
        return query;
    }
}
