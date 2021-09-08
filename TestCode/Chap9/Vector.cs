using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap9
{
    struct Vector:IFormattable
    {
        public double x, y, z;


        public Vector(double  v1, double  v2, double  v3) : this()
        {
            this.x = v1;
            this.y = v2;
            this.z = v3;
        }

        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }

        public double Norm()
        {
            return x * x + y * y + z * z;
        }
        public string ToString(string format,IFormatProvider formatProvider)
        {
            if(format == null)
            {
                return ToString();
            }

            string formatUpper = format.ToUpper();
            switch (formatUpper) {
                case "N"://表示模
                    return "||" + Norm().ToString() + "||";
                case "VE"://表示以科学计数法显示每个成员的一个请求
                    return String.Format("{0:E},{1:E},{2:E})", x, y, z);
                case "IJK"://以格式i+j+k显示矢量的请求
                    StringBuilder sb = new StringBuilder(x.ToString(), 30);
                    sb.AppendFormat("i+");
                    sb.AppendFormat(y.ToString());
                    sb.AppendFormat("j+");
                    sb.AppendFormat(z.ToString());
                    sb.AppendFormat("k");
                    return sb.ToString();
                default:
                    return ToString();
            }

        }
    }
}
