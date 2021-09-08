using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap10.ImmutableCollectionsSample
{
    public static  class PipelineStages
    {
        public static Task ReadFilenamesAsync(string path,BlockingCollection<string> output)
        {
            return Task.Run(() =>
            {
                foreach (string filename in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories))
                {
                    output.Add(filename);
                    ConsoleHelper.WriteLine(string.Format("stage 1:added {0}", filename));
                }
                output.CompleteAdding();
            });
        }
    }
}
