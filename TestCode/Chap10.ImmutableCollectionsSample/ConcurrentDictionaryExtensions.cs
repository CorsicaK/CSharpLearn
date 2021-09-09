using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap10.PipelineSample
{
    /// <summary>
    /// 实现字典的扩展方法
    /// </summary>
    public static class ConcurrentDictionaryExtensions
    {
        /// <summary>
        /// 如果拆分得到的某个单词在字典中还不存在，则添加，如果存在则字典递增
        /// 因字典没有阻塞方法，故采用扩展方法
        /// </summary>
        /// <param name="dict"></param>
        /// <param name="key"></param>
        public static void AddOrIncrementValue(
            this ConcurrentDictionary<string, int> dict, string key)
        {
            bool success = false;
            while (!success)
            {
                int value;
                if (dict.TryGetValue(key, out value))//判断值是否存在
                {
                    if (dict.TryUpdate(key, value + 1, value))//存在则尝试递增
                    {
                        success = true;
                    }
                }
                else
                {
                    if (dict.TryAdd(key, 1))//并不存在则尝试添加
                    {
                        success = true;
                    }
                }
            }
        }

    }
}
