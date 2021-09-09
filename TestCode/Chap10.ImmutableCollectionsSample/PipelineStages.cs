using Chap10.PipelineSample;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap10.PipelineSample
{
    public static  class PipelineStages
    {
        /*管道第一阶段：读取文件名*/
        public static Task ReadFilenamesAsync(string path,BlockingCollection<string> output)
        {
            return Task.Run(() =>
            {
                //使用枚举器迭代指定目录及其子目录中的C#文件
                foreach (string filename in Directory.EnumerateFiles(path, "*.cs", SearchOption.AllDirectories))
                {
                    output.Add(filename);
                    ConsoleHelper.WriteLine(string.Format("stage 1:added {0}", filename));
                }
                //通知所欲读取器不再等待集合中任何的额外项，结束添加
                output.CompleteAdding();
            });
        }

        /*管道第二阶段：读取文件并将文件添加到另一个集合中*/
        public static  async Task LoadContentAsync(BlockingCollection <string > input, BlockingCollection <string > output)
        {
            //如果在填充集合的同时使用读取器读取集合，则需要使用GetConsumingEnumerable方法获取阻塞集合的枚举器，而非直接迭代
            //如果直接迭代会只迭代当前状态迭代集合而不会迭代以后添加的项
            foreach (var filename in input.GetConsumingEnumerable())
            {
                using (FileStream stream = File.OpenRead(filename))
                {
                    var reader = new StreamReader(stream);
                    string line = null;
                    while((line =await reader.ReadLineAsync()) != null)
                    {
                        output.Add(line);
                        ConsoleHelper.WriteLine(string.Format("stage 2:added {0}", line));
                    }
                }
            }
            output.CompleteAdding();
        }

        /*管道第三阶段：处理内容*/
        public static Task ProcessContentAsync(BlockingCollection <string > input,ConcurrentDictionary<string ,int> ouput)
        {
            return Task.Run(() =>
            {
                foreach (var line in input.GetConsumingEnumerable())
                {
                    string[] words = line.Split(' ', ';', '\t', '{', '}', '(', ')', ':', ':');
                    foreach (var word in words.Where(w => !string.IsNullOrEmpty(w)))
                    {
                        ouput.AddOrIncrementValue(word);
                        ConsoleHelper.WriteLine(string.Format("stage 3:added {0}", word));
                    }
                }
            });
        }


        /*管道第四阶段：从字典中获取数据，将其转换为Info类型*/
        public static Task TransferContentAsync(
            ConcurrentDictionary<string ,int> input,BlockingCollection<Info> output)
        {
            return Task.Run(() =>
          {
              foreach (var word in input.Keys)
              {
                  int value;
                  if (input.TryGetValue(word, out value))
                  {
                      var info = new Info { Word = word, Count = value };
                      output.Add(info);
                      ConsoleHelper.WriteLine(string.Format("stage4: added {0}", info));
                  }
              }
              output.CompleteAdding();
          });
        }


        /*管道第五阶段：根据Count属性设置Info类型的Color属性*/
        public static Task AddColorAsync(BlockingCollection<Info> input, BlockingCollection <Info> output)
        {
            return Task.Run(() =>
            {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    if (item.Count > 40)
                    {
                        item.Color = "Red";
                    }
                    else if (item.Count > 20)
                    {
                        item.Color = "Yellow";
                    }
                    else
                    {
                        item.Color = "Green";
                    }
                    output.Add(item);
                    ConsoleHelper.WriteLine(string.Format("stage 5: added color {1} to {0}", item, item.Color));
                }
                output.CompleteAdding();
            });
        }


        /*管道最后一个阶段：用指定颜色在控制台中输出结果*/
        public static Task ShowContentAsync(BlockingCollection <Info > input)
        {
            return Task.Run(() =>
            {
                foreach (var item in input.GetConsumingEnumerable())
                {
                    ConsoleHelper.WriteLine(string.Format("stage 6: {0}", item), item.Color);
                }
            });
        }
    }
}
