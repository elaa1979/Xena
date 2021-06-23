using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Xena.Application.Common.Exceptions;
using Xena.Application.Common.Models;
using Xena.Application.Utils;

namespace Xena.Infrastructure.Persistence.Repositories
{
    public static class DynamicWhereFilter
    {

        public static Expression<Func<T, bool>> Where<T>(List<Where> filter)
        {
            Expression<Func<T, bool>> predicate = PredicateBuilder.True<T>();
            if (filter != null)
                foreach (var where in filter)
                {
                    if (where.Value is null)
                        continue;
                    var prop = getProperty<T>(where.Field);
                    if (prop is null)
                        throw new BadRequestException(ErrorCodes.InvalidFilter);

                    var parameter = Expression.Parameter(typeof(T));
                    var property = Expression.Property(parameter, prop);
                    var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;

                    var converted = type.IsEnum ?
                        Enum.Parse(type, where.Value) :
                        Convert.ChangeType(where.Value, type);
                    var value = Expression.Constant(converted);

                    var expr = getExpression(where.FilterType, property, value);
                    var result = Expression.Lambda<Func<T, bool>>(expr, parameter);

                    predicate = predicate.And(result);
                }
            return predicate;
        }

        private static PropertyInfo getProperty<T>(string name)
        {
            var t = typeof(T);
            return t.GetProperty(name);
        }

        private static BinaryExpression getExpression(FilterType type, MemberExpression property, ConstantExpression constant)
        {
            var value = Expression.Convert(constant, property.Type);
            var res = type switch
            {
                FilterType.Equals => Expression.Equal(property, value),
                FilterType.GreaterThan => Expression.GreaterThan(property, value),
                FilterType.GreaterThanOrEqual => Expression.GreaterThanOrEqual(property, value),
                FilterType.LessThan => Expression.LessThan(property, value),
                FilterType.LessThanOrEqual => Expression.LessThanOrEqual(property, value),
                FilterType.Like => Expression.Equal(Expression.Call(property, typeof(string).GetMethod("Contains", new[] { typeof(string) }), value), Expression.Constant(true)),
                _ => throw new BadRequestException(ErrorCodes.InvalidFilter)
            };
            return res;
        }
    }
}