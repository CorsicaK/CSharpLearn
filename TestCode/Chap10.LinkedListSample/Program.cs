using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap10.LinkedListSample
{
    class Program
    {
        static void Main()
        {
            var pdm = new PriorityDocumentManager();
            pdm.AddDocument(new LinkedListSample.Document("one", "Simple", 8));
            pdm.AddDocument(new LinkedListSample.Document("two", "Sample", 2));
            pdm.AddDocument(new Document("three", "Sample", 4));
            pdm.AddDocument(new Document("four", "Sample", 5));
            pdm.AddDocument(new Document("five", "Sample", 1));
            pdm.AddDocument(new Document("six", "Sample", 5));
            pdm.AddDocument(new Document("seven", "Sample", 6));
            pdm.AddDocument(new Document("four", "Sample", 2));
            pdm.DisplayAllNodes();
            Console.ReadKey();
        }
    }
}
