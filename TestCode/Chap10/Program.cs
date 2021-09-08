using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Chap10
{
    class Program
    {
        static void Main(string[] args)
        {


            string s = "aaa";
            Regex r = new Regex("a");
            s = r.Replace(s, "b", 1);
            Console.WriteLine(s);//输出baa

            #region 可观察的集合
            var data = new ObservableCollection<string>();
            data.CollectionChanged += Data_CollectionChanged;

            data.Add("One");
            data.Add("Two");
            data.Insert(1, "Three");
            data.Remove("One");
            #endregion


            #region 队列
            var dm = new DocumentManager();
            ProcessDocuments.Start(dm);
            for (int i = 0; i < 1000; i++)
            {
                var doc = new Document("Doc " + i.ToString(), " content");
                dm.AddDocument(doc);
                Console.WriteLine("Added document {0}", doc.Title);
                Thread.Sleep(new Random().Next(20));
            }

            #endregion

            #region 列表
            var racers = new List<Racer>(new Racer[]
            {
                new Racer (12,"Jochen","Rindt","Austra",6),
                new Racer (13,"Jochenj","Rindtr","USA",12),
                new Racer (18,"kshsaj","Gindtr","CN",88)
            });

            //以下两种完全相同
            int index2 = racers.FindIndex(new FindCountry("Finland").FindCountryPredicate);
            int index3 = racers.FindIndex(t => t.Country == "Findland");

            racers.Sort(new RacerComparer(RacerComparer.CompareType.Country));
            racers.ForEach(Console.WriteLine);

            List<Person> persons = racers.ConvertAll<Person>(t => new Person(t.FirstName + " " + t.LastName));

            #endregion


            #region 栈
            var alphabet = new Stack<char>();
            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');
            //输出CBA
            foreach (char item in alphabet)
            {
                Console.Write(item);
            }
            //输出ABC
            while (alphabet.Count > 0)
            {
                Console.Write(alphabet.Pop());
            }
            Console.WriteLine();

            #endregion

            #region Lookup类
            racers.Add(new Racer(18, "JTest", "Rindt", "Austra", 15));
              
            var lookupsRacers = racers.ToLookup(t => t.Country);
            foreach (Racer racer in lookupsRacers["Austra"])
            {
                Console.WriteLine(racer);
            }
            #endregion

            Console.ReadKey();


        }

        private static void Data_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("ACTION :{0}", e.Action.ToString());
            if (e.OldItems != null)
            {
                Console.WriteLine("starting index for old item(s):{0}", e.OldStartingIndex);
                Console.WriteLine("old item(S):");
                foreach (var item in e.OldItems)
                {
                    Console.WriteLine(item);
                }
            }
            if (e.NewItems != null)
            {
                Console.WriteLine("starting index for new item(s):{0}", e.NewStartingIndex);
                Console.WriteLine("new item(S):");
                foreach (var item in e.NewItems)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
