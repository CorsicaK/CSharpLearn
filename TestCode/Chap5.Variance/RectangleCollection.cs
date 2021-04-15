using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5.Variance
{
    //IIndex<T>接口用RectangleCollection类来实现
    class RectangleCollection:IIndex<Rectangle>
    {
        private Rectangle[] data = new Rectangle[3]
        {
            new Rectangle{Height=2,Width=5},
            new Rectangle{Height=3,Width=7},
            new Rectangle{Height=4.5,Width=2.9}
        };

        private static RectangleCollection coll;
        public static RectangleCollection GetRectangles()
        {
            //合并运算符，如果coll为null将会调用运算符的右侧
            return coll ?? (coll = new RectangleCollection());
        }
        public Rectangle this[int index]
        {
            get
            {
                if (index < 0 || index > data.Length)
                    throw new ArgumentOutOfRangeException("index");
                return data[index];
            }
        }
        public int Count
        {
            get
            {
                return data.Length;
            }
        }
    }
}
