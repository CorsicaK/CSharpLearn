using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chap11.DataLib;

namespace ParallelEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 并行查询AsParallel()
            var data = SampleData();

            var res1 = (from x in data.AsParallel()
                       where Math.Log(x) < 4
                       select x).Average();

            
            var res12 = data.AsParallel().Where(x => Math.Log(x) < 4).Select(x => x).Average();
            #endregion

            #region 分区器
            var res2 = (
                from x in Partitioner.Create(data.ToList(), true).AsParallel()
                where Math.Log(x) < 4
                select x
                ).Average();
            #endregion


            #region 取消

            var cts = new CancellationTokenSource();
            Task.Factory.StartNew(() =>
          {
              try
              {
                  var res = (from x in data.AsParallel().WithCancellation(cts.Token)
                             where Math.Log(x) < 4
                             select x).Average();
                  Console.WriteLine("query finished,sum: {0}", res);
              }
              catch (OperationCanceledException ex)
              {
                  Console.WriteLine(ex.Message);
              }
          });

            string input = Console.ReadLine();
            if(input.ToLower().Equals("y"))
            {
                //在主线程中调用CancellationTokenSource类的Token()方法取消任务
                cts.Cancel();
            }

            #endregion



            #region 表达式树
            Expression<Func<Racer, bool>> expression = r => r.Country == "Italy" && r.Wins > 6;
            DisplayTree(0, "lambda", expression);

            #endregion

            Console.ReadKey();
        }

        static IEnumerable<int> SampleData()
        {
            const int arraySize = 10000000;
            var r = new Random();
            return Enumerable.Range(0, arraySize).Select(x => r.Next(140)).ToList();
        }


        private static void DisplayTree(int indent,string message,Expression expression)
        {
            string output = String.Format("{0} {1} ! NodeType:{2};Expr:{3}", "".PadLeft(indent, '>'), message, expression.NodeType, expression);
            indent++;
            switch (expression.NodeType)
            {
                case ExpressionType.Lambda:
                    Console.WriteLine(output);
                    LambdaExpression lambdaExpr = (LambdaExpression)expression;
                    foreach (var parameter in lambdaExpr.Parameters)
                    {
                        DisplayTree(indent, "Parameter", parameter);
                    }
                    DisplayTree(indent, "Body", lambdaExpr.Body);
                    break;
                case ExpressionType.Constant:
                    ConstantExpression constExpr = (ConstantExpression)expression;
                    Console.WriteLine("{0} Const Value:{1}", output, constExpr.Value);
                    break;
                case ExpressionType.Parameter:
                    ParameterExpression paramExpr = (ParameterExpression)expression;
                    Console.WriteLine("{0} param Type:{1}", output, paramExpr.Type.Name);
                    break;
                case ExpressionType.Equal:
                case ExpressionType.AndAlso:
                case ExpressionType.GreaterThan:
                    BinaryExpression binExpr = (BinaryExpression)expression;
                    if (binExpr .Method != null)
                    {
                        Console.WriteLine("{0} Param Type:{1}", output, binExpr .Method .Name);
                    }
                    else
                    {
                        Console.WriteLine(output);
                    }
                    DisplayTree(indent, "Left", binExpr.Left);
                    DisplayTree(indent, "Right", binExpr.Right);
                    break;
                case ExpressionType.MemberAccess:
                    MemberExpression memberExpr = (MemberExpression)expression;
                    Console.WriteLine("{0} Memeber Name :{1} ,Type:{2}", output, memberExpr.Member.Name, memberExpr.Type.Name);
                    DisplayTree(indent, "Member Expr", memberExpr.Expression);
                    break;
                default:
                    Console.WriteLine();
                    Console.WriteLine("{0} {1}", expression.NodeType, expression.Type.Name);
                    break;

            }

        }
    }
}
