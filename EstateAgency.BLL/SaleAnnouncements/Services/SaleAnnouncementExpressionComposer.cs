using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EstateAgency.BLL.SaleAnnouncements.Services
{
    public class SaleAnnouncementExpressionComposer : ISaleAnnouncementExpressionComposer
    {
        public Expression<Func<SaleAnnouncementDto, bool>> Compose(int? maxPrice, int? numberOfRooms, string adress)
        {
            var expressions = new List<Expression<Func<SaleAnnouncementDto, bool>>>();
            expressions.Add(sad => true);

            if (maxPrice.HasValue)
                expressions.Add(sad => sad.Price < maxPrice.Value);

            if (numberOfRooms.HasValue)
                expressions.Add(sad => numberOfRooms.Value == sad.ApartmentNumberOfRooms);

            if (!string.IsNullOrEmpty(adress))
                expressions.Add(sad => sad.ApartmentAddress.Contains(adress));

            var lambda = GetExpression(expressions.ToArray());
            return lambda;
        }

        private Expression<Func<SaleAnnouncementDto, bool>> GetExpression(params Expression<Func<SaleAnnouncementDto, bool>>[] expressions)
        {
            Expression<Func<SaleAnnouncementDto, bool>> lambda = expressions[0];
            foreach (var expression in expressions.Skip(1))
            {
                lambda = AndAlso(lambda, expression);
            }
            return lambda;
        }

        private Expression<Func<T, bool>> AndAlso<T>(Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            var parameter = Expression.Parameter(typeof(T));

            var leftVisitor = new ReplaceExpressionVisitor(expr1.Parameters[0], parameter);
            var left = leftVisitor.Visit(expr1.Body);

            var rightVisitor = new ReplaceExpressionVisitor(expr2.Parameters[0], parameter);
            var right = rightVisitor.Visit(expr2.Body);

            return Expression.Lambda<Func<T, bool>>(Expression.AndAlso(left, right), parameter);
        }

        private class ReplaceExpressionVisitor
            : ExpressionVisitor
        {
            private readonly Expression _oldValue;
            private readonly Expression _newValue;

            public ReplaceExpressionVisitor(Expression oldValue, Expression newValue)
            {
                _oldValue = oldValue;
                _newValue = newValue;
            }

            public override Expression Visit(Expression node)
            {
                if (node == _oldValue)
                    return _newValue;
                return base.Visit(node);
            }
        }
    }
}