

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

#### 流控制

- 条件语句（各种编程语言都相似，不记录）

  - if语句 
  - switch语句：case的值必须是**常量表达式**，不建议使用goto语句，会使代码看着很混乱

- 循环（各种编程语言都相似，不记录）

  - for循环

  - while循环

  - do...while循环

  - foreach循环：可以迭代集合中的每一项，该能改变集合中的各项**，如有此需求改用for循环

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

#### **枚举**

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

#### 名称空间

名称空间的别名：

```c#
using alias = NamespaceName;
```

名称空间别名的修饰符<font color=red size=4>**::**</font> 

```c#
using Introduction = Wrox.ProCSharp.Basics;
...
Introduction::NamespaceExample NSEx = new Introduction::NamespaceExample();
...
```

#### Main()方法

- 这个方法必须是类或结构的静态方法
- 返回类型必须是int 或void

多个main（）方法，可以使用/main选项告诉编译器哪个方法作为程序入口点

```c#
csc DoubleMain.cs /main:Wrox.MathExample
```

#### 有关编译

如何编译应用程序：  /target选项(/t)指定要创建的文件类型

| 选项       | 输出                              |
| ---------- | --------------------------------- |
| /t:exe     | 控制台应用程序（默认）            |
| /t:library | 带有清单的类库                    |
| /t:module  | 没有清单的组件                    |
| /t:winexe  | Windows应用程序（没有控制台窗口） |

- 如果想得到非可执行文件（dll），则必须编译为一个库

- 如果把C#编译成一个模块，就不会创建程序集，模块可以使用/addmodule选项编译到另一个清单中

- /out用于指定由编译器生成的输出文件名

如何编译类库及在另一个程序集中引用库:需要类库和控制台应用程序

> Chap2中MathLib.cs和MyFirstTest.cs

#### 控制台I/O

控制台窗口读取一行文本 Console.ReadLine()

将指定的值写入控制台窗口 Console.Write()，Console.WriteLine()(最后添加换行符)

```c#
 //格式化输出
 int i = 10;
 int j = 20;
 Console.WriteLine("{0} plus {1} equals {2}",i,j,i+j);
 //输出 10 plus 20 equals 30
```

调整文本在该宽度中的位置，正值表示右对齐，负值表示左对齐：<font color = red size = 3>{n,w} n为参数索引，w为宽度值</font>

预定义主要格式字符串表

![image-20210316101302850](C:\Users\李晨曦\AppData\Roaming\Typora\typora-user-images\image-20210316101302850.png)

可以使用占位符代替格式字符串

```c#
double d = 0.234;
Console.WriteLine("{0:#.00}",d);
//输出.23
```

#### 使用注释

- 源文件的内部注释

```c#
//单行注释
/*...
....多行注释*/
```

- XML文档

```c#
  /// <summary>
  /// 两数求和
  /// </summary>
  /// <param name="x">参数1</param>
  /// <param name="y">参数2</param>
  /// <returns>返回两个数的和</returns>
  public int Add(int x, int y)
  {
  	return x + y;
  }
```

#### C#预处理器指令

- #define和#undef：前者告诉编译器存在给定的符号，后者删除符号的定义

- #if、#elif、#else和#endif：告诉编译器是否要编译某个代码块

  ```c#
  int DoSomeWork(double x)
  {
  	//如果DEBUG被#define，则编译
  	#if DEBUG
  		Console.WriteLine("x is " + x);
  	#endif
  }
  ...
  //还支持逻辑运算符
     #if W2K && (ENTERPRISE == false) //如果W2K被定义但是ENTERPRISE没有被定义
  ```

- #warning和#error：编译器遇到时会产生警告或错误

- #region和#endregion:把一段代码标记为有给定名称的一个块，便于布局

- #line：用于改变编译器在警告和错误信息中显示的文本名和行号信息

  #line default：把行号还原为默认的行号

- #pragma：可以抑制或还原指定的编译警告

#### C#编程规则

- 关于标识符的规则（同其他编程语言，不记录）

  如果需要将某一保留字用作标识符，可以在标识符前面加上<font color=red size=3>@</font>

  标识符可以包含Unicode字符（不建议），用语法\uXXXX指定，如_Identifier 与 \u005fIdentifier完全相同

- 用法约定

  - 命名约定

    - Pascal形式，区别于js，常量名称最好不要全部大写

      ```
      const int MaxmumLength;
      ```

    - camel形式（同js）

      ```c#
      //类型中所有是有成员字段的名称,成员字段前缀名常加下划线
      private int _subscriberId;
      //传递给方法的所有参数的名称
      public void RecordScale(string salesmanName,int quantity);
      //也可用于区分同名的两个对象——比较常见的是属性封装一个字段
      private string employeeName;
      public string EmployeeName
      {
          get
          {
              return employeeName;
          }
      }
      ```

    - 名称的风格应保持一致，如ShowConfirmationDialog()和ShowWarningDialog()

    - 名称空间的名称要慎重

      建议：用自己的公司名创建顶级的名称空间，再嵌套技术范围较窄、用户所在小组或部门或者类所在软件包的名称空间

    - 名称和关键字：名称不与关键字冲突

    > C#关键字列表见《C#高级编程》P63 表2-12

  - 属性和方法的使用<font color = red size=3> （如果要编码的项满足以下所有条件，则将它设置为属性，否则应使用方法)</font>

    - 客户端代码应能读取它的值，最好不要使用只写属性。
    - 读取该值不应花太长的时间。
    - 读取该值不应有任何明显的和不希望的负面效应。设置属性的值，不应有与该属性不直接相关的负面效应。
    - 可以按照任何顺序设置属性。尤其在设置属性时，最好不要因为还没有设置另一个相关的属性而抛出一个异常。
    - 顺序读取属性也应有相同的效果。如果属性的值可能会出现预料不到的改变，就应把它编写为一个方法。

  - 字段的用法

    <font color=red size=3>字段应总是私有的</font>

    在某些情况下可把**常量或只读字段**设置为共有

## 对象和类型

#### 创建和使用类