using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chap7
{
    struct Vector
    {
        public double x, y, z;
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        //复制构造函数
        public Vector(Vector rhs)
        {
            x = rhs.x;
            y = rhs.y;
            z = rhs.z;
        }
        public override string ToString()
        {
            return "(" + x + "," + y + "," + z + ")";
        }

        //运算符重载，用于Vector相加
        public static Vector operator +(Vector lhs, Vector rhs)
        {
            Vector result = new Vector(lhs);
            result.x += lhs.x;
            result.y += lhs.y;
            result.z += lhs.z;
            return result;
        }

        //数与适量相乘方法1
        public static Vector operator *(double lhs, Vector rhs)
        {
            return new Vector(rhs.x * lhs, rhs.y * lhs, rhs.z * lhs);
        }
        //数与矢量相乘方法2
        public static Vector operator *(Vector rhs, double lhs)
        {
            //重用上一个矢量相乘的方法
            return lhs * rhs;
        }
        //矢量内积
        public static double operator *(Vector rhs, Vector lhs)
        {
            return lhs.x * rhs.x + lhs.y * rhs.y + lhs.z * rhs.z;
        }
        //==比较运算符重载
        public static bool operator ==(Vector rhs, Vector lhs)
        {
            if (rhs.x == lhs.y && rhs.x == lhs.y && rhs.z == lhs.z)
                return true;
            else
                return false;
        }
        //比较运算符必须成对重载
        public static bool operator !=(Vector rhs, Vector lhs)
        {
            //引用重载的==运算符
            return !(lhs == rhs);
        }
    }
}
