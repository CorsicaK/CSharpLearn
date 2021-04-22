using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap6
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayClass();

            Person[] persons =
            {
                new Person {FirstName="LLL",LastName="Hill" },
                new Person {FirstName="Nike",LastName="zll" },
                new Person {FirstName="LJS",LastName="xsg" }
            };
            //使用自定义类数组的排序
            Array.Sort(persons);
            foreach(var p in persons)
            {
                Console.WriteLine(p);
            }


            //第三种方法排序实现
            Array.Sort(persons, new PersonComparer(PersonCompareType.LastName));
            foreach(var p in persons)
            {
                Console.WriteLine(p);
            }

            //ArraySegments<T>结构的使用
            int[] ar1 = { 1, 2, 3, 45, 11, 22, 52 };
            int[] ar2 = { 23, 56, 11, 11, 2, 5, 2, 3 };
            var segments = new ArraySegment<int>[2]
            {
                new ArraySegment<int>(ar1,0,3),
                new ArraySegment<int>(ar2,3,3)
            };
            var sum = SumOfSegements(segments);
            Console.WriteLine("sum:"+sum);

            //迭代集合不同方式的使用
            var titles = new MusicTitles();
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
            Console.WriteLine("REVERSE:");
            foreach (var title in titles.Reverse())
            {
                Console.WriteLine(title);
            }
            Console.WriteLine();
            Console.WriteLine("SUBSET:");
            foreach(var title in titles.Subset(2, 2))
            {
                Console.WriteLine(title);
            }

            //用yield return 返回枚举器
            var game = new GameMove();
            IEnumerator enumerator = game.Cross();
            while (enumerator.MoveNext())
            {
                enumerator = enumerator.Current as IEnumerator;
            }

            //元组使用
            var result = Divide(5, 2);
            Console.WriteLine("result of division:{0},reminder:{1}",
                result.Item1, result.Item2);

            //数组对比Person2
            var janet = new Person2 { FirstName = "Janet", LastName = "Jaskon" };
            Person2[] persoanl =
            {
                new Person2
                {
                    FirstName="mmmm",
                    LastName="JJJ"
                },
                janet
            };
            Person2[] personal2 =
            {
                new Person2
                {
                    FirstName="JJJJ",
                    LastName="jjj"
                },
                janet
            };
            if (persoanl != personal2)
            {
                //会输出，因为两个变量personal1和personal2引用的两个不同数组
                Console.WriteLine("NOT THE SAME REFERENCE");
            }
            //调用IEquatable.Equals()方法
            if((persoanl as IStructuralEquatable).Equals(personal2, EqualityComparer<Person2>.Default))
            {
                Console.WriteLine("the same content");
            }

            //元组比较
            //比较运算符对比
            var t1 = Tuple.Create<int, string>(1, "stephanie");
            var t2 = Tuple.Create<int, string>(1, "stephanie");
            if (t1 != t2)
            {
                Console.WriteLine("not the same reference to the tuple");
            }
            //Tuple<>类提供的两个Equals（）方法
            //方法1：重写了Object基类中的Equals()方法，并把object作为参数
            if (t1.Equals(t2))
                Console.WriteLine("rhe same content");

            Console.ReadKey();
          

        }

        static void ArrayClass()
        {
            //CreateInstance创建数组
            Array intArray1 = Array.CreateInstance(typeof(int), 5);
            for (int i = 0; i < 5; i++)
            {
                intArray1.SetValue(33, i);
            }

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(intArray1.GetValue(i));
            }

            //CreateInstance重载版本创建数组
            //表示创建一个2*3个元素的数组
            int[] lengths = { 2, 3 };
            //表示第一维基于1，第二维基于10
            int[] lowerBounds = { 1, 10 };
            Array racers = Array.CreateInstance(typeof(Person), lengths, lowerBounds);

            racers.SetValue(new Person { FirstName = "Alain", LastName = "Prost" }, index1: 1, index2: 10);
            racers.SetValue(new Person
            {
                FirstName = "Emerson",
                LastName = "Fittipaldi"
            }, 1, 11);
            racers.SetValue(new Person { FirstName = "Ayrton", LastName = "Senna" }, 1, 12);
            racers.SetValue(new Person { FirstName = "Michael", LastName = "Schumacher" }, 2, 10);
            racers.SetValue(new Person { FirstName = "Fernando", LastName = "Alonso" }, 2, 11);
            racers.SetValue(new Person { FirstName = "Jenson", LastName = "Button" }, 2, 12);

            Person[,] racers2 = (Person[,])racers;
            Person first = racers2[1, 10];
            Person last = racers2[2, 12];

        }

        //ArraySegement<T>结构的使用
        static int SumOfSegements(ArraySegment<int>[] segments)
        {
            int sum = 0;
            foreach(var segment in segments)
            {
                for(int i = segment.Offset; i < segment.Offset + segment.Count; i++)
                {
                    sum += segment.Array[i];
                }
            }
            return sum;
        }

        //元组
        public static Tuple<int ,int> Divide(int dividend,int divisor)
        {
            int result = dividend / divisor;
            int reminder = dividend % divisor;
            return Tuple.Create<int, int>(result, reminder);  
        }
    }
}
