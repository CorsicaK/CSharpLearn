using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap11.DataLib
{
    class Program
    {
        static void Main(string[] args)
        {
            var query = from r in Formulal.GetChampions()
                        where r.Country == "Italy"
                        orderby r.Wins descending
                        select r;
            foreach (Racer  r in query )
            {
                Console.WriteLine("{0:A}", r);
            }


            #region 标准查询操作符示例

            //筛选
            var racers1 = from r in Formulal.GetChampions()
                          where r.Wins > 15 &&
                            (r.Country == "Italy" || r.Country == "USA")
                          select r;

            //筛选使用扩展方法
            var racers11 = Formulal.GetChampions()
                .Where(r => r.Wins > 15 && (r.Country == "Italy" || r.Country == "USA"))
                .Select(r => r);

            //使用索引筛选
            var racers12 = Formulal.GetChampions()
                .Where((r, index) => r.LastName.StartsWith("A") && index % 2 != 0);

            //类型筛选,使用OfType()扩展方法，筛选出string类型的
            object[] data = { "one", 2, 3, "four", "five", 6 };
            var query1 = data.OfType<string>();

            //复合的from子句
            var ferrariDrivers = from r in Formulal.GetChampions()
                                 from c in r.Cars
                                 where c == "Ferrari"
                                 orderby r.LastName
                                 select r.FirstName + " " + r.LastName;
           

            //扩展方法SelectMany()重写上面的复合子句
            var ferrariDrivers1 = Formulal.GetChampions()
                .SelectMany(r => r.Cars, (r, c) => new { Racer = r, Car = c })
                .Where(r => r.Car == "Ferrari")
                .OrderBy(r => r.Racer.LastName)
                .Select(r => r.Racer.FirstName + " " + r.Racer.LastName);

            //排序
            var racers5 = from r in Formulal.GetChampions()
                          where r.Country == "Barr"
                          orderby r.Wins descending
                          select r;

            //扩展方法OrderByDescending()重写上面的排序
            var racers51 = Formulal.GetChampions()
                .Where(r => r.Country == "Barr")
                .OrderByDescending(r => r.Wins)
                .Select(r => r);

            //根据多个条件排序并提取前10个
            var racers6 = (from r in Formulal.GetChampions()
                           orderby r.Country, r.LastName, r.FirstName
                           select r).Take(10);

            //扩展方法OrderBy()和ThenBy()重写上面
            var racers61 = Formulal.GetChampions()
                .OrderBy(r => r.Country)
                .ThenBy(r => r.LastName)
                .ThenBy(r => r.FirstName)
                .Take(10);

            //分组
            var countries = from r in Formulal.GetChampions()
                            group r by r.Country into g    //根据Country属性组合并定义为新的标识符g
                            orderby g.Count() descending, g.Key
                            where g.Count() >= 2
                            select new { Country = g.Key, Count = g.Count() };

            //扩展方法重写分组
            var countries1 = Formulal.GetChampions()
                .GroupBy(r => r.Country)
                .OrderByDescending(g => g.Count())
                .ThenBy(g => g.Key)
                .Where(g => g.Count() >= 2)
                .Select(g => new { Country = g.Key, Count = g.Count() });

            //对嵌套的对象分组
            var countries2 = from r in Formulal.GetChampions()
                             group r by r.Country into g
                             orderby g.Count() descending, g.Key
                             where g.Count() >= 2
                             select new
                             {
                                 Country = g.Key,
                                 Count = g.Count(),
                                 Racers = from r1 in g
                                          orderby r1.LastName
                                          select r1.FirstName + " " + r1.LastName
                             };

            //内连接
            var racers7 = from r in Formulal.GetChampions()
                          from y in r.Years
                          select new
                          {
                              Year=y,
                              Name=r.FirstName+" "+r.LastName
                          };

            var teams = from t in Formulal.GetContructorChampions()
                        from y in t.Years
                        select new
                        {
                            Year=y,
                            Name=t.Name
                        };
            var racersAndTeams = (from r in racers7
                                  join t in teams on r.Year equals t.Year
                                  select new
                                  {
                                      r.Year,
                                      Champion = r.Name,
                                      Constructor = t.Name
                                  }).Take(10);

            //将上面的连接合并为一个LINQ
            var racersAndTeams1 =
                (from r in
                     from r1 in Formulal.GetChampions()
                     from yr in r1.Years
                     select new
                     {
                         Year = yr,
                         Name = r1.FirstName + " " + r1.LastName
                     }
                 join t in
                 from t1 in Formulal.GetContructorChampions()
                 from yt in t1.Years
                 select new
                 {
                     Year = yt,
                     Name = t1.Name
                 }
                 on r.Year equals t.Year
                 orderby t.Year
                 select new
                 {
                     Year = r.Year,
                     Racer = r.Name,
                     Team = t.Name
                 }).Take(10);


            //左外连接
            var racersAndTeams3 = (
                from r in racers7
                join t in teams on r.Year equals t.Year into rt
                from t in rt.DefaultIfEmpty()//该方法定义右侧的默认值
                orderby r.Year
                select new
                {
                    Year = r.Year,
                    Champion = r.Name,
                    Constructor = t == null ? "no constructor championship" : t.Name
                }).Take(10);

            //组连接

            var q = (from r in Formulal.GetChampions()
                     join r2 in racers7 on
                     new
                     {
                         FirstName = r.FirstName,
                         LastName = r.LastName
                     }
                     equals
                     new
                     {
                         FirstName = r2.Name.FirstName(),
                         LastName = r2.Name.LastName()
                     }

                     into yearResults
                     select new
                     {
                         FirstName = r.FirstName,
                         LastName = r.LastName,
                         Wins = r.Wins,
                         Starts = r.Starts,
                         Results = yearResults
                     });

            
            //与GetRacersByCar()方法相同
            //因为在别的地方不需要使用，所以定义一个委托类型的变量来保存LINQ查询
            Func<string, IEnumerable<Racer>> racersByCar =
                car => from r in Formulal.GetChampions()
                       from c in r.Cars
                       where c == car
                       orderby r.LastName
                       select r;

            //集合操作:扩展方法Distinct()、Union()、Intersect()、Except()都是集合操作
            foreach (var racer in racersByCar("Ferrari").Intersect(racersByCar ("Mclaren")))
            {
                Console.WriteLine(racer);
            }

            //合并:Zip()方法,如果两个序列的项数不同，Zip()方法会在到达较小集合的末尾时停止
            var racerNames = from r in Formulal.GetChampions()
                             where r.Country == "Italy"
                             orderby r.Wins descending
                             select new
                             {
                                 Name = r.FirstName + " " + r.LastName
                             };

            var racerNamesAndStarts = from r in Formulal.GetChampions()
                                      where r.Country == "Italy"
                                      orderby r.Wins descending
                                      select new
                                      {
                                          LastName = r.LastName,
                                          Starts = r.Starts
                                      };
            var racers = racerNames.Zip(racerNamesAndStarts, (first, second) => first.Name + ",starts:" + second.Starts);


            //分区:常应用于分页
            int pageSize = 5;
            int numberPages = (int)Math.Ceiling(Formulal.GetChampions().Count() / (double)pageSize);
            for(int page = 0; page < numberPages; page++)
            {
                Console.WriteLine("Page {0}", page);
                var racers8 =
                    (from r in Formulal.GetChampions()
                     orderby r.LastName, r.FirstName
                     select r.FirstName + " " + r.LastName)
                     .Skip(page * pageSize)
                     .Take(pageSize);
            }


            //聚合操作符
            var query2 = from r in Formulal.GetChampions()
                         let numberYears = r.Years.Count() //let子句定义变量
                         where numberYears >= 3
                         orderby numberYears descending, r.LastName
                         select new
                         {
                             Name = r.FirstName + " " + r.LastName,
                             TimesChampion = numberYears
                         };

            var countries3 =
                (from c in
                     from r in Formulal.GetChampions()
                     group r by r.Country into c
                     select new
                     {
                         Country = c.Key,
                         Wins = (from r1 in c
                                 select r1.Wins).Sum()
                     }
                 orderby c.Wins descending, c.Country
                 select c).Take(5);


            //转换操作符
            var racers9 = (from r in Formulal.GetChampions()
                           from c in r.Cars
                           select new
                           {
                               Car = c,
                               Racer = r
                           }).ToLookup(cr => cr.Car, cr => cr.Racer);

            //在非类型化的集合(如Arraylist)上使用LINQ查询，可以使用Cast()方法
            var list = new System.Collections.ArrayList(Formulal.GetChampions() as System.Collections.ICollection);
            var query3 = from r in list.Cast<Racer>()//Cast定义强类型化的查询
                         where r.Country == "USA"
                         orderby r.Wins descending
                         select r;

            //生成操作符:Range() Empty() Repear()
            var values = Enumerable.Range(1, 20);//第一个参数作为起始值，第二个参数作为填充值
            foreach(var item in values)
            {
                Console.WriteLine("{0} ", item);//1 2 3 4 ... 19 20
            }

            var values2 = Enumerable.Range(1, 20).Select(n => n * 3);

            #endregion
            Console.ReadKey();
        }




        /// <summary>
        /// LINQ扩展方法
        /// </summary>
        static void ExtensionMethods()
        {
            var champions = new List<Racer>(Formulal.GetChampions());
            IEnumerable<Racer> italyChampion = champions.Where(r => r.Country == "Italy").OrderByDescending(r => r.Wins).Select(r => r);
            foreach (Racer  r in italyChampion)
            {
                Console.WriteLine("{0:A}", r);
            }
        }


        private static IEnumerable<Racer> GetRacersByCar(string car)
        {
            return from r in Formulal.GetChampions()
                   from c in r.Cars
                   where c == car
                   orderby r.LastName
                   select r;
        }
    }
}
