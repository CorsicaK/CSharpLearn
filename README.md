# CSharpLearn
C#入门学习，指导书：C#高级编程第9版

## .NET体系结构

语言互操作性：用一种语言编写的类应能直接与用另一怨言编写的类通信

垃圾回收机制

对于共享程序集的异步编程，C#5.0新增的异步方法：async和await（应该与JS相同，后续验证）

![image-20210315145057508](C:\Users\李晨曦\AppData\Roaming\Typora\typora-user-images\image-20210315145057508.png)



## 核心C#

#### 基础介绍

​    using类似Java的import

​    每个C#可执行文件都必须有一个入口点——Main()方法（M大写） 

​    在系统启动调用该方法时，要么没有返回值（void），要么返回整数（int）

```c#
	[modifiers]  return_type MethodName([parameters])
	{
	// Method body.
	}
```

#### 变量

##### 声明和初始化

```c#
//声明
datatype identifier;
//声明并初始化
int i = 10;
//声明相同类型的多个变量并初始化
int i = 0 , y = 10;
//声明不同类型的多个变量并初始化
int i = 0;
bool y = true;
```

确保使用前初始化的方法

- 变量是类和结构中的字段，默认值为0

- 方法是局部变量必须在代码中显示初始化之后才能使用值

##### 类型推断

var关键字

##### 作用域

- 只要类在某个作用域内，其字段(也称为成员变量)也在该作用域内。
- 局部变量存在于表示声明该变量的块语句或方法结束的右花括号之前的作用域内。
- 在for、while 或类似语句中声明的局部变量存在于该循环体内。

##### 常量

const关键字

- 必须在声明时初始化
- 总是静态的但是不用加static
- 常量的值必须能在编译时用于计算。因此，不能用从一个变量中提取的值来初始化常量。
- 名称值易于理解

#### 预定义数据类型

##### 值类型和引用类型

值类型存储在*堆栈*中，应用类型存储在*托管堆*上

```c#
//如下，x和y是引用类型的变量，声明这两个变量只保留了一个引用
//因为x和y引用同一个对象，所以不管改变哪个都会影响另一个
Vector x,y;
x= new Vector();
x.Value=30;
y = x ;
Console.WriteLine(y.Value); //30
y.Value = 50;
Console.WriteLine(x.Value); //50
```
如果变量是一个引用，可以把值设置成null，表示不引用任何对象

```c#
y = null;
```

自己定义的类都是引用类型

##### 预定义的值类型

内置的CTS值类型表示基本类型，如*整型和浮点型、字符型和布尔型*

- 整型：8种，int总是32位带符号的整数

- 浮点型：float和double

  ```c#
  //一般认为非整数值为double，指定为float的方法
  float f = 12.3F
  ```

- decimal类型：精度更高的浮点数
- bool类型： true和false，**不能和整数值0或1显示转换**
- 字符类型：char，字面量用**’‘**括起来，用“”会出现错误

##### 预定义的引用类型

- object：最终的父类型

- string：string关键字，+连接字符串

  - 字符串是不可改变的，修改其中一个字符串，就会创建一个全新的string对象，而另一个字符串不会发生任何变化（此特点不同于引用类型）

    ```c#
    using System;
    class StringExarple
    {
    	public static int Main()
    	{
    	string s1 = "a string";
    	string s2=s1;
    	Console.writeLine("sl is"+ s1);//s1 is a string
    	Console.writeLine("s2 is"+ s2);//s2 is a string
    	sl = "another string" ;
    	Console.writeLine("sl is now" + s1);//s1 is now another string
    	Console.writeLine("s2 is now"+ s2)://s2 is now a string
    	return 0;
    	}
    }
    ```

  - **@**防止解释为转义字符

    ```c#
    //转义字符写法
    string filepath = "C: \\ProCSharp\\First .cs";
    //@形式替代
    string filepath = @"C: \ProCSharp\First .cs";
    ```

##### 流控制

- 条件语句（各种编程语言都相似，不记录）

  - if语句 
  - switch语句：case的值必须是**常量表达式**，不建议使用goto语句，会使代码看着很混乱

- 循环（各种编程语言都相似，不记录）

  - for循环

  - while循环

  - do...while循环

  - foreach循环：可以迭代集合中的每一项，**改循环不能改变集合中的各项**，如有此需求改用for循环

    ```c#
    foreach (int temp in arrayOfInts)
    {
    	temp++;
    	Console.WriteLine(temp);
    }
    ```

- 跳转语句

  - goto语句：不建议使用
    - 不能跳转到像for循环这样的代码块，也不能跳出类的范围，不能退出try...catch块后面的finally块
  - break语句
  - continue语句：退出循环的当前迭代，开始下一次迭代
  - return语句：如果方法返回void，应使用没有表达式的return语句

##### **枚举**

```c#
public enum TimeofDay
{
    Morning = 0,
    Afternoon = 1,
    Evening = 2
}
...
//使用
class EnumExample
{
	public static int Main()
	{
		WriteGreeting (TimeOfDay.Morning) ;
		return 0;
	}
	static void WriteGreeting (TimeOfDay timeOfDay)
	{
		switch (timeOfDay) 
		{
			case TimeOfDay.Morning:
				Console.WriteLine ("Good morning!");
				break;
			...
		}
	}
}
```

枚举在后台会实例化为派生于基类System.Enum的结构，这表示可以对它们调用方法，执行有用的任务。一旦代码编译好，枚举就成为基本类型

```c#
TimeOfDay time = TimeOfDay.Afternoon;
Console.WriteLine (time.ToString());
//还可以从字符串中获取枚举值
TimeOfDay time2 = (TimeOfDay) Enum.Parse(typeof(TimeOfDay),
	"afternoon",true);
Console.WriteLine((int)time2) ;
```

##### 命名空间

