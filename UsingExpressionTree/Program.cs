﻿using System;
using System.Linq.Expressions;

namespace UsingExpressionTree
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1*2+(x-y)
            Expression const1 = Expression.Constant(1);
            Expression const2 = Expression.Constant(2);

            Expression leftExp = Expression.Multiply(const1, const2);

            Expression param1 = Expression.Parameter(typeof(int)); // x를 위한 변수
            Expression param2 = Expression.Parameter(typeof(int)); // y를 위한 변수

            Expression rightExp = Expression.Subtract(param1, param2);

            Expression exp = Expression.Add(leftExp, rightExp);

            Expression<Func<int, int, int>> expression =
                Expression<Func<int, int, int>>.Lambda<Func<int, int, int>>(
                    exp, new ParameterExpression[]
                    {
                        (ParameterExpression)param1,
                        (ParameterExpression)param2
                    });
            Func<int, int, int> func = expression.Compile();

            // x =7, x= 8
            Console.WriteLine($"1*2+({7}-{8}) = {func(7, 8)}");
        }
    }
}
