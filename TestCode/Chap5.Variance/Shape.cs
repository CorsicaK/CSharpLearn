using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap5.Variance
{
    //定义Shape类，用于说明协变和抗变
    public class Shape
    {
        public double Width
        {
            get;
            set;
        }
        public double Height
        {
            get;
            set;
        }
        public override string ToString()
        {
            return String.Format("Width:{0},Height:{1}", Width, Height);
        }
    }
}
