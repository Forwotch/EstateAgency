using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace EstateAgency.BLL.RentAnnouncements.Services
{
    public class RentAnnouncementExpressionComposer : IRentAnnouncementExpressionComposer
    {
        private readonly IMapper _mapper;

        public RentAnnouncementExpressionComposer(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Expression<Func<RentAnnouncementDto, bool>> Compose(int? maxPrice, int? numberOfRooms, string adress)
        {
            var expressions = new List<Expression<Func<RentAnnouncementDto, bool>>>();
            expressions.Add(rad => true);
            
            if (maxPrice.HasValue)
              expressions.Add(rad => rad.Rent < maxPrice.Value);

            if (numberOfRooms.HasValue)
                expressions.Add(rad => numberOfRooms.Value == rad.ApartmentNumberOfRooms);

            if (!string.IsNullOrEmpty(adress))
                expressions.Add(rad => rad.ApartmentAddress.Contains(adress));

            var lambda = GetExpression(expressions.ToArray());
            return lambda;
        }

        private Expression<Func<RentAnnouncementDto, bool>> GetExpression(params Expression<Func<RentAnnouncementDto, bool>>[] expressions)
        {
            Expression<Func<RentAnnouncementDto, bool>> lambda = expressions[0];
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