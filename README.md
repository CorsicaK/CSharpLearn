

# CSharpLearn

C#入门学习，指导书：C#高级编程第9版

## 1  .NET体系结构

语言互操作性：用一种语言编写的类应能直接与用另一语言编写的类通信

垃圾回收机制

对于共享程序集的异步编程，C#5.0新增的异步方法：async和await（应该与JS相同，后续验证）

![](G:\zhl\GIS开发资料\CSharpLearn\CSharpLearn\image\1-1.png)



## 2  核心C#

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

![](G:\zhl\GIS开发资料\CSharpLearn\CSharpLearn\image\2-1.png)

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

## 3  对象和类型

#### 类和结构

类和结构都是创建对象的模板，区别在于它们在内存中的存储方式、访问方式（类是存储在堆（heap）上的<font color=blue>引用类型</font>，而结构是存储在栈上的<font color = blue>值类型</font>）和它们的一些特征（如结构不支持继承）

较小的数据类型使用结构可以提高性能，在语法上：类使用关键字class，结构使用关键字struct。都是用关键字new来声明示例

```c#
//定义类
class ClassName
{
	...
}
//定义结构
struct StructName
{
	...
}
//声明实例
ClassName myClass = new ClassName();
StructName myStruct = new StructName();
```

#### 类

成员的可访问性：public 、protected 、internal 、private

##### 数据成员

- 数据成员是包含类的数据——字段、常量和事件的成员。数据成员可以是静态数据。*类成员总是实例成员，除非用static进行显式的声明*

- 实例化对象后，使用Object.FieldName来访问字段

- 常量与类的关联方式和变量与类的关联方式相同。关键字const，声明为public即可在类的外部访问它

- 事件是类的成员，在发生某些行为时，它可以让对象通知调用方

##### 函数成员

提供了操作类中数据的某些方法，包括方法、属性、构造函数和终结器（finalizer）、运算符以及索引器

​	属性：访问方式与访问类的公共字段相似

​	构造函数：与所属类同名，且不能有返回类型，用于初始化字段的值

​	终结器：类似于构造函数，在CLR检测到不在需要某个对象时调用它，名称与类相同，前面有个“~”号

​	运算符：

​	索引器：允许对象以数组或集合的方式进行索引

- 方法：默认为实例成员，使用static可以定义为静态方法

  - 声明

    ```c#
    //如果没有返回值则返回类型指定为void
    [modifiers] return_type MethodName([parameters])
    {
    	//methods body
    }
    //方法可以包含任意多条return
    public bool IsPositive(int value)
    {
        if(value < 0)
            return false;
        return true;
    }
    ```

  - 调用

    > TestCode\Chap3\MainEntryPoint.cs

  - 给方法传递参数：通过引用或者值传递

    - 引用传递：被调用的方法得到的是这个变量，即指向内存中变量的指针。在方法内部对变量进行的任何改变在方法退出后仍旧有效
    - 值传递：被调用的方法得到的是变量的一个相同副本，方法退出后，对变量的修改会消失
    - 若无特别指定，所有的引用类型都通过引用传递，所有的值类型都通过值传递

    > TestCode\Chap3\MainEntryPoint.cs

    - 字符串虽为引用类型，但是因为字符串是不可改变的，如果改变字符串的值就会创建一个全新的字符串，所以字符串无法采用一般的引用类型的行为方式

  - ref参数：迫使值参数通过引用传递给方法，带有ref关键字则该方法对变量所做的任何改变都会影响原始对象的值

    <font color = red size=4>无论是值传递还是引用传递，在传递给方法之前，任何变量都必须初始化</font>

    ```C#
    static void SomeFunction(int[] ints,ref int i)
    {
    	ints[0] = 100;
    	i = 100;
    }
    //调用时也需要添加ref
    SomeFunction(ints,ref i);
    ```

  - out参数：在方法的输入参数前加out，传递给该方法的变量可以不初始化

    ```c#
    static void SomeFunction(out inti)
    {
    	i = 100;
    }
    public static int Main()
    {
    	int i;//不初始化
    	//调用时也要加out
    	SomeFunction(out i);
    	...
    }
    ```

  - 命名参数

    参数一般按定义的顺序传递给方法，命名参数允许按任意顺序传递

    ```C#
    string FullName(string firstName,string lastName)
    {
    	return firstName+""+lastName;
    }
    //调用
    FullName("John"."Doe");
    FullName(lastName:"Doe",firstName:"John");
    ```

  - 可选参数

    可选参数必须提供默认值，且必须是方法定义的最后参数

  - 方法的重载：同名但不同参数或者类型

    ```C#
    class ResultDisplayer
    {
     void DisplayResult(string result)
     {
     	//方法体
     }
     void DisplayResult(int result)
     {
     	//方法体
     }
     void DisplayResult(int result1,int result2)
     {
     	//方法体
     }
    }
    ```

    - 注意两个方法不能仅在返回类型上有区别
    - 注意两个方法不能仅根据参数是声明为ref还是out来区分

- 属性property：一个方法或一对方法

  ```c#
  public string SomeProperty
  {
  	get
  	{
  		return ...;
  	}
      //省略set即创建只读属性
  	set
  	{
  		...
  	}
  }
  ```

  - 属性的访问修饰符

  ```c#
  private string _name;
  //允许给属性的get和set访问器设置不同的访问修饰符
  //get和set必须有一个具备属性的访问级别
  public string Name
  {
  	//get访问器不能设置为protected
  	get
  	{
  		return _name;
  	}
  	private set
  	{
  		_name = value;
  	}
  }
  ```

  - 自动实现的属性

  ```C#
  //不需要private int age;编译器会自动创建
  //必须有两个访问器
  public int Age{get; set;}
  public int Age{get; private set;}
  ```

  - 构造函数：与类同名但没有返回类型

  ```c#
  public class MyClass
  {
      //若不提供构造函数，系统会在后台默认创建
      public MyClass()
      {
      }
      //构造函数重载，与其他方法规则相同
      //若定义了有参数的构造函数，系统就不会创建默认的构造函数
      public MyClass(int x,int y)
      {
      }
      //一般使用this关键字区分成员字段和同名的参数
      //构造函数可以定义为private或protected，这样不相关的类就不能访问它们
      private int number;
      private MyClass(int number)
      {
          this.number=number;
      }
  }
  ```

  （1）静态构造函数：无参数，只执行一次，只能有一个

  ```
  calss MyClass
  {
  	//静态构造函数只能访问类的静态成员，不能访问类的实例成员
  	//无参数的实例构造函数与静态构造函数可以在同一个类中同时定义
  	static MyClass()
  	{
  		...
  	}
  	...
  }
  ```

  （2）从构造函数中调用其他构造函数

  构造函数初始化器可以包含对同一个类的另一个构造函数的调用，也可以包含<font face="宋体" color=red> 直接基类</font>的构造函数的调用（此时用<font color=red>base</font>替代this），初始化构造器不能有多个调用

  ```C#
  class Car
  {
  	private string description;
  	private uint nWheels;
  	public Car(string description, uint nWhee1s)
  	{
  		this.description = description;
  		this.nWheels = nwheels;
  	}
  	public Car(string description): this (description, 4)
  	{
  	}
  	...
  }
  ...
  Car myCar = newCar("Proton Persona");
  ```

##### 只读字段

readonly关键字，允许把一个字段设置成常量，但是需要执行一些计算以确定它的初始值

```c#
public class DocumentEditor
{
	//如果要把只读字段设置成静态，就必须显式的声明它
	public static readonly unit MaxDocuments;
	static DocumentEditor()
	{
		//可以在构造函数中给只读字段赋值，但是不能在别的地方赋值
		MaxDocuments = DoSomthingOutMaxNumber();
	}
}
```

#### 匿名类型

var关键字，用于表示隐式类型化的变量

var和new关键字一起使用时可以创建匿名类型，它是一个继承自Object且没有与名称的类

`var captain = new {FirstName="James",MiddleName="T",lastName="Krik"};`

如果设置的值来自另一个类，且该类有一个实例（如person）则可以简化初始化器

`var doctor =new {person.FirstName,person.MiddleName,person.lastName};`

#### 结构（主要用于小的数据结构）

为结构定义函数与为类定义函数完全相同

```c#
struct Dimensions
{
	public double Length;
	public double Width;
	public Dimensions(double length,double width)
	{
		Length = length;
		Width = width;
	}
	public double Digonal
	{
		get
		{
			return Math.Sqrt(Length*Length+Width*Width);
		}
	}
}
```

- <font color = red >结构是值类型</font>，但在语法上常当做类来处理

  ```c#
  //结构在使用前，所有的元素都必须进行初始化
  Dimensions point = new Dimensions();
  point.Length = 3;
  point.Width = 6;
  ```

- 结构不支持继承，唯一的例外是对应的结构最终派生自类System.Object

- 结构的构造函数与类定义构造函数相同，**但是不允许定义无参的构造函数**

#### 弱引用

使用WeakReference类创建，在垃圾回收器(GC.Collection())运行时就会回收对象并释放内存

`WeakReference mathReference = new WeakReference(new MathTest())`;

#### 部分类

partial关键字，允许把类、结构、方法或接口放在多个文件中

```c#
//在嵌套类型中可以嵌套部分类
//BigClassPart1.cs
[CustomAttribute]
partial class TheBigClass:TheBigBaseClass,IBigClass
{
	public void MethodOne()
	{
	...
	}
}
//BigClassPart2.cs
[AnotherAttribute]
partial class TheBigClass:IOtherBigClass
{
	public void MethodTwo()
	{
	...
	}
}
//以上相当于
[CustomAttribute]
[AnotherAttribute]
partial class TheBigClass:TheBigBaseClass,IBigClass,IOtherBigClass
{
    public void MethodOne(){}
    public void MethodTwo(){}
}
```

如果声明类时使用public、private、protected、internal、abstract、sealed、new、一般约束 关键字，**这些关键字必须应用于同一个类的所有部分 **

#### 静态类

静态类只含静态方法和属性，它不能创建实例，使用static关键字

```c#
//定义静态类
static class StaticUtilities
{
	public static void HelperMethod()
	{
		...
	}
}
//调用静态类的方法,不需要该类的对象
StaticUtilities.HelperMethod();
```

#### Object类

每个.NET类都派生自System.Object类，结构总是派生自System.ValueType，而System.ValueType派生自System.Object类。因此它们可以访问Object定义的许多**公有的和受保护的成员方法**

##### System.Object()方法

- ToString()方法：获取数据字符串，但是数据格式化没有多种选择。它是一个虚方法

  > 重写举例：Chap3中的MainEntryPoint.cs

- GetHashCode()方法：用于确定对象放在结构（映射，也称散列表或者字典）的什么位置

- Equals()和ReferenceEquals()方法：比较对象相等性的不同方法

- Finalize()方法：在引用对象作为垃圾被回收以清理资源时调用它

- GetType()方法：返回从System.Type派生类的一个实例，这个对象可以提供对象成员所属类的更多信息，包括基本类型、方法、属性等

- MemberwiseClone()方法：该方法不是虚方法所以不能重写，它是复制对象并返回对副本的一个引用，得到的副本是一个浅表复制，即它复制了类中的所有值类型

#### 扩展方法

是一个静态方法，它允许改变一个类，但不需要该类的源代码，适用于不能直接修改源代码但是需要扩展方法的情况

```c#
public static class MoneyExtension
{
	public static void AddToAmount(this Money money,decimal amountToAdd)
	{
		money.Amount += amountToAdd;
	}
}
//调用
money.AddToAmount();
```

## 4  继承

#### 继承的类型

##### 实现继承和接口继承

实现继承：表示一个类型派生于一个基类型，它拥有该基类型的**所有成员字段和函数**

接口继承：表示一个类型只继承了函数的签名，没有继承任何实现代码

##### 多重继承

不支持多重实现继承，但支持<font color=red>多重接口继承</font>。即C#可以派生自另一个类和任意多个接口

##### 结构和类

- 结构总是派生自System.ValueType，它们还可以派生自任意多个接口
- 类总是派生自System.Object或用户选择的另一个类，它们还可以派生自任意多个接口

#### 实现继承

```c#
//类同时派生自一个类和多个接口
public class MyDerivedClass: MyBaseClass,IInterface1,IInterface2
{
	...
}
//结构派生自接口
public struct MyDerivedStruct:IInterface1,IInterface2
{
	...
}
```

如果要引用Object类，可以使用object关键字

##### 虚方法

将一个基类函数声明为virtual，就可以在任何派生类中重写该函数，属性也可声明为<font color=red>virtual</font>

在派生类的函数重写另一个函数是，使用<font color= red>override</font>

<font color = red>成员字段和静态函数都不能声明为virtual</font>

```C#
class MyBaseClass
{
    private string foreName;
    //虚方法
    public virtual string VirtualMethod()
    {
        return "This method is virtual and defined in MyBaseClass";
    }
    //虚属性
    public virtual string ForeName
    {
        get{ return foreName;}
        set{ foreName = value;}
    }
}
...
//重写虚方法
class MyDerivedClass:MyBaseClass
{
    public override string VirtualMethod()
    {
        return "This method is an override defined in MyDerivedClass."
    }
}
```

##### 隐藏方法

如果签名相同的方法在基类和派生类中都进行了声明，但该方法没有分别声明为virtual和override，派生类方法就会隐藏基类方法，此时使用<font color=red>new</font>关键字

```C#
class MyDerivedClass:HisBaseClass
{
	public new int MyGroovyMethod()
    {
        return 0;
    }
}
```

##### 调用函数的基类版本

语法：base.<MethodName>(),用于从派生类中调用方法的基类版本，可以用这个语法调用基类中的任何方法，不必从同一个方法的重载中调用它

```C#
class CustomerAccount
{
    public virtual decimal CalculatePrice()
    {
        return 0;
    }
}
class GoadAccount:CustomerAccount
{
    public override decimal CalculatePrice()
    {
        return base.CalculatePrice() * 0.9M;
    }
}
```

##### 抽象类和抽象函数

关键字<font color=red>abstract</font>。抽象类不能实例化，抽象函数不能直接实现，**必须在非抽象的派生类中重写**

抽象函数本身是虚拟的，<font color=red>不需要加virtual</font>

```C#
abstract class Building
{
	public abstract decimal CalculateHeatingCost();
}
```

##### 密封类和密封方法

关键字<font color=red>sealed</font>。**类不能被继承，方法不能被重写**

```C#
//密封类
sealed class FinalClass
{ ... }
//密封方法
//要在方法或属性上使用sealed关键字，必须先从基类上把它声明为要重写的方法或属性
class MyClass:MyClassBase
{
    public sealed override void FinalMethod()
    {
        ...
    }
}
```

##### 派生类的构造函数

构造函数的执行顺序，最先调用的总是基类的构造函数，即派生类的构造函数可以在执行过程中调用它可以访问的任何基类方法、属性和任何其他成员

- 在层次结构中添加无参数的构造函数

```C#
public abstract class GenericCustomer
{
	private string name;
    //base表示基类的构造函数而不是调用当前类的构造函数，（）内无参数表示必须调用无参数的构造函数
    public GenericCustomer():base()
    {
        name = "<no name>";
    }
}
```

- 在层次结构中添加带参数的构造函数

```C#
class Nervermore60Customer:GenericCustomer
{
    private uint highCostMinutesUsed;
    private string referrerName;
    //1.本身不能初始化name字段，而是把它传递给基类
    //2.假定还需传递别的信息(referrerName是一个需要声明的变量)
    //3.检查事件链后认为需要带一个字符串参数的构造函数，因此加上默认referrerName:"<none>"
    public Nervermore60Customer(string name,string referrerName)
        :base(name,"<none")
    {
        this.referrerName = referrerName;
    }
}
//实例化,用于检查事件链
GenericCustomer customer = new Nervermore60Customer("Arabel Jones");
```

#### 修饰符

##### 可见性修饰符

| 修饰符             | 应用于                                          | 说明                                               |
| ------------------ | ----------------------------------------------- | -------------------------------------------------- |
| public             | 所有类型或成员                                  | 任何代码均可以访问该项                             |
| protected          | 类型和内嵌类型的所有<font color=red>成员</font> | 只有<font color= red>派生</font>的类型能访问该项   |
| internal           | 所有类型或成员                                  | 只能在包含它的程序集中访问该项                     |
| private            | 类型和内嵌类型的所有<font color=red>成员</font> | 只能在它所属的类型中访问该项                       |
| protected internal | 类型和内嵌类型的所有<font color=red>成员</font> | 只能在包含它的程序集和派生类型的任何代码中访问该项 |

不能把类型定义为protected、private、protected internal，因为这些修饰符对于包含在名称空间中的类型没有任何意义，但是可以用这些修饰符定义嵌套的类型

```C#
public class OuterClass
{
    //因为内部的类型总是可以访问外部类型的所有成员
    protected class InnerClass
    {
        ...
    }
}
```

#####  其他修饰符

| 修饰符   | 应用于         | 说明                                                         |
| -------- | -------------- | ------------------------------------------------------------ |
| new      | 函数成员       | 成员用相同的签名隐藏继承的成员                               |
| static   | 所有成员       | 成员不作用于类的具体实例                                     |
| virtual  | 仅函数成员     | 成员可以由派生类重写                                         |
| abstract | 仅函数成员     | 虚拟成员定义了成员的签名，但没有提供实现代码                 |
| override | 仅函数成员     | 成员重写了继承的虚拟或抽象成员                               |
| sealed   | 类、方法和属性 | 对于类，不能继承自密封类；对于属性和方法，成员重写已继承的虚拟成员，但任何派生类中的任何成员都不能重写该成员。该成员必须与override一起使用 |
| extern   | 仅静态方法     | 成员在外部用另一种语言实现                                   |

#### 接口

接口只能包含方法、属性、索引器和事件的声明

不能实例化接口，接口既不能有构造函数也不能有字段

接口定义不允许声明关于成员的修饰符，接口成员总是公有的

##### 定义和实现接口

接口名称通常以 **I** 开头

> 接口定义：Chap4中的IBankAccount.cs

从接口中派生完全独立于从类中派生

派生类必须实现接口的所有方法

> 接口实现：Chap4中的GoldAccount.cs和SaverAccount.cs

接口引用完全可以看成类引用，但接口引用的强大之处：它可以引用任何实现该接口的类

```C#
IBankAccount[] accounts = new IBankAccount[2];
accounts[0] = new SaverAccount();
accounts[1] = new GoldAccount();
```

##### 派生的接口

接口可以彼此继承，其方式与类的继承方式相同

派生的接口拥有被派生接口的所有成员和自己的成员

> 接口派生：Chap4中的ITransferBankAccount.cs
>
> 定义派生自派生接口的类：Chap4中的CurrentAccount.cs

```C#
public interface ITransferBankAccount:IBankAccount
{
	bool TransferTo(IBankAccount destination,decimal amount);
}
```

## 5  泛型

#### 泛型概述

##### 特性1：性能

值类型使用非泛型集合类，在把值类型转换为引用类型和把引用类型转换为值类型时，需要进行装箱和拆箱操作，很耗性能，遍历时损耗较大

```C#
//使用int类型的泛型List<T>代替装箱拆箱的遍历操作
var list = new List<int>();
list.Add(44);
int i1 = list[0];//无需拆箱，若拆箱 int i1 = (int)list[0];
foreach(int i2 in list)
{
    ...
}
```

##### 特性2：类型安全

在泛型类List<T>中，泛型类型T定义了允许使用的类型。如有了List<int>的定义，就只能把整数类型添加到集合中。

```C#
var list = new List<int>();
list.Add(44);
list.Add("mystring");//编译错误，参数无效
list.Add(new MyClass());//编译错误，参数无效
```

##### 特性3：二进制代码的重用

泛型类可以定义一次，并且可以用许多不同的类型实例化

```C#
var list = new List<int>();
list.Add(44);
var stringList = new List<string>();
stringList.Add("myString");
var myClassList = new List<MyClass>();
myClassList.Add(new MyClass());
```

##### 特性4：代码的扩展

##### 特性5：命名约定

- 泛型类型的名称用字母T作为前缀
- 如果没有特殊的要求，泛型类型允许用任意类替代，且只使用了一个泛型类型，就可以用字符T作为泛型类型的名称

```C#
public class List<T>{};
public class LinkedList<T>{};
```

- 如果泛型类型有特定的要求(例如，它必须实现一个接口或派生自基类)，或者使用了两个或多个泛型类型，就应给泛型类型使用描述性的名称

```C#
public delegate void EventHandler<TEventArgs> (object sender,TEventArgs e);
public delegate TOutput Converter<TInput,TOutput> (TInput from) ;
public class SortedList<TKey, TValue> { };
```

#### 创建泛型类

泛型类的定义与一般类类似，只要使用泛型类型声明。之后泛型类型就可以在类中用作一个字段成员，或者方法的参数类型

> 泛型类定义：Chap5中的LinkedList.cs和LinkedListNode.cs

每个对象的类都可以由泛型实现方式。另外，如果类使用了层次结构，泛型有利于消除类型强制转换操作

#### 泛型类的功能

##### 默认值

不能把null赋予泛型类型，原因是泛型类型也可以实例化为值类型，而null只能用于引用类型。

通过**default**关键字，将null赋予引用类型，将0赋予值类型

`T doc = default(T);`

> Chap5.Document中的DocumentManager.cs中的GetDocument()方法

##### 约束

如果泛型类需要调用泛型类型中的方法，就必须添加约束

例子中**where**子句实现IDoucment接口的要求

> Chap5.Document中的DocumentManager.cs

泛型支持的几种约束类型

| 约束           | 说明                                                         |
| -------------- | ------------------------------------------------------------ |
| where T:struct | 对于结构约束，类型T必须是值类型                              |
| where T:class  | 类约束指定类型T必须是引用类型                                |
| where T:IFoo   | 指定类型T必须实现接口IFoo                                    |
| where T:Foo    | 指定类型T必须派生自基类Foo                                   |
| where T:new()  | 这是一个构造函数约束，指定类型T必须有一个默认构造函数        |
| where T1:T2    | 这个约束也可以指定，类型T1派生自泛型类型T2.该约束也称为裸类型约束 |

使用泛型类型可以合并多个约束。where T:IFoo,new()约束和MyClass<T>声明指定,where子句中只能定义**基类、接口和默认构造函数**

```c#
public class MyClass<T>
	where T:IFoo,new()
{
	...
}
```

##### 继承

泛型类型可以实现泛型接口，也可以派生自一个类。泛型类可以派生自泛型基类

```C#
public class Base<T>
{
}
//要求必须重复接口的泛型类型，或者必须指定基类的类型
public class Derived<T>:Base<T>//public class Derived：Base<string>
{
}
```

派生类可以是泛型类或非泛型类

```C#
public abstract class Calc<T>
{
    public abstract T Add(T x,T y);
    public abstract T Sub(T x,T y);
}
public class IntCalc:Calc<int>
{
    public override int Add(int x,int y)
    {
        return x+y;
    }
    public override int Sub(int x,int y)
    {
        return x-y;
    }
}
```

##### 静态成员

泛型类的静态成员只能在类的一个实例中共享

> Chap5.Document中的StaticDemo.cs

#### 泛型接口

泛型接口中定义的方法可以带**泛型参数**

##### 协变和抗变

协变和抗变指对参数和返回值的类型进行转换

1.在NET中，**参数类型是协变的**。假定有Shape和Rectangle类, Rectangle 派生自Shape基类。声明Display()方法是为了接受Shape类型的对象作为其参数:

`public void Display(Shape o){}`

2.现在可以传递派生自Shape基类的任意对象。因为Rectangle 派生自Shape,所以Rectangle满足Shape的所有要求，编译器接受这个方法调用:

```c#
var r=new Rectangle(Width = 5,Height = 2.5);
Display(r);
```

3.**方法的返回类型是抗变的。 **当方法返回一个Shape时，不能把它赋予Rectangle, 因为Shape不一定总是Rectangle。反过来是可行的:

```C#
//如果一个方法像GetRectangle0方法那样返回一个Rectangle 
public Rectangle GetRectangle();
//就可以把结果赋予某个Shape
Shape s = GetRectangle();
```

.NET4之后，扩展的语言支持泛型接口和泛型委托的协变

##### 泛型接口的协变

<font color = red>out</font>关键字标注，则泛型接口是协变的，这也意味着返回类型只能是T

> Chap5.Variance中的IIndex.cs,应用在Program.cs

##### 泛型接口的抗变

<font color = red>in</font>关键字标注，则泛型接口是抗变的

#### 泛型结构

泛型结构没有继承特性，<font color=red>Nullable<T></font>

可空类型使用<font color=red>?</font>关键字:`int? x;`

```C#
//结构Nullable<T>定义了一个约束，起泛型类型T必须是一个结构
public struct Nuallable<T>
    where T:struct
    {
        public Nuallable(T value)
        {
            this.hasValue=true;
            this,value=value;
        }
        //泛型结构定义的除了T类型之外唯一的系统开销
        //用于确定是设置对应的值还是使之为空
        private bool hasValue;
        //泛型结构定义的只读属性
        public bool HasValue
        {
            get{return hasValue;}
        }
        private T value;
        ...
        //泛型结构定义操作符重载
        private override string ToString(){...}
    }
```

- 非可空类型转换为可空类型(<font color=blue>成功的</font>)

  ```C#
  int y1=4;
  int? x1=y1;
  ```

- 可空类型转换为非可空类型(<font color=blue>失败的</font>)

  ```C#
  int x1=GetNullableType();
  int y1=(int)x1;//抛出异常InvalidOperationException
  ```

- 使用合并运算符从可空类型转换为费可空类型(<font color=blue>成功的</font>)<font color=red>??运算符</font>

  ```c#
  int? x1 = GetNullableType();
  int y1 = x1 ?? 0;
  ```


#### 泛型方法

- 泛型方法可以在非泛型类中定义

``` c#
//定义泛型方法
void Swap<T>(ref T x,ref T y)
{
	T temp;
	temp=x;
	x=y;
	y=temp;
}
//调用泛型方法
int i=4;
int j=5;
Swap<int>(ref x,ref y);
//可以像非泛型方法那样调用
Swap(ref i,ref j);
```

- 带约束的泛型方法

  > Chap5.GenericMethods的Algorithm.cs

- 带委托的泛型方法

  >  Chap5.GenericMethods的Algorithm.cs

- 泛型方法规范

## 6  数组

#### 同一类型和不同类型的多个对象

- 同一类型：集合和数组
- 不同类型：元组（Tuple）

#### 简单数组

##### 数组声明和初始化

```c#
// 类型[] 变量名
int[] myArray;
//初始化,引用类型必须使用new关键字，指定数组中元素的类型和数量
myArray = new int[4];
//一个语句中声明和初始化数组
int[] myrray = new int[4];
//数组初始化器只能在声明时使用
int[] myArray = new int[4]{4,7,111,2};
//自动计数声明
int[] myArray = new int[]{1,1,1};
//简化形式
int[] myArray = {1,2,3,4};
```

##### 访问数组元素

索引器以0开头

```C#
int[] myArray = new int[]{4,5,6,7};
int v1=myArray[0];
```

Length属性获取数组长度

```C#
for (int i=0;i<myArray.Length;i++)
{
 ...
}
//foreach 遍历
foreach(var i in myArray)
{
    ...
}
```

##### 使用引用类型

既能声明与定义类型的数组，也能声明自定义类型的数组

```C#
public class Person
{
	public string FirstName{get; set;}
	public string LastName{get;set;}
	public override string ToString()
	{
		return String.Format("{0} {1}",FristName,LastName);
	}
}
//声明自定义类型的数组
Person[] myPerson=new Person[3];
//自定义类型数组初始化与预定义类型初始化相同
```

#### 多维数组

```C#
//二维数组声明和初始化
int[,] twodim = new int[3,3];
two[0,0]=1;
.......
//使用数组索引器初始化
int[,] twodim1 = {{1,2,3},{1,2,3},{1,2,3}};
//三维数组声明和初始化
int[,,] threedim = {
		{{1,2},{1,2}},
		{{1,2},{1,2}},
		{{1,2},{1,2}}
		}
int v2=threedim[0,1,1];
```

#### 锯齿数组

各行可能有不同的大小，声明锯齿数组时<font color=red>要依次放置左右括号</font>

- 初始化锯齿数组时只在第一个方括号中设置该数组包含的行数，定义各行中元素个数的第2个方括号设置为空

```C#
//锯齿数组的声明和初始化
int[][] jagged = new int[3][];
jagged[0] = new int[2]{1,2};
jagged[1] = new int[6]{3,4,5,6,7,8};
jagged[2] = new int[3]{1,2,3};
//获取元素
for(int row=0;row<jagged.Length;row++)
{
    for(int element = 0;element<jagged[row].Length;element++)
    {
        ...
    }
}
```

#### Array类

Array类实现的属性有Length属性、LongLength属性（如果数组包含的元素个数超过了整数的取值范围则用LongLength属性来获取元素个数）和Rank属性（获取数组的维数）

##### 创建数组

Array类为一个抽象类，不能用构造函数创建数组，除了使用C#语法创建数组实例外，还可以使用<font color=red>静态方法CreateInstance()</font>创建数组，该方法第一个参数为元素的类型，第二个参数定义数组的大小，用SetValue()方法设置对应元素的值，用GetValue()方法读取对应元素的值

```c#
Array intArray1 = Array.CreateInstance(typeof(int),5);
for(int i=0;i<5;i++)
{
	intArray1.SetValue(33,i);
}
for(int i=0;i<5;i++)
{
	Console.WriteLine(intArray1.GetValue(i));
}
//强制转换成声明为int[]的数组
int[] intArray2 = (int[])intArray1;
```

- CreateInstance()方法的重载版本，可以创建<font color = red>多维数组和不基于0的数组</font>

​       尽管数组不基于0，但可以用一般的C#表示法将它赋予一个变量，但是不要超过边界

> \Chap6\Programs.cs

##### 复制数组

数组为引用类型

- Clone()方法实现浅表副本
- Copy()方法实现浅表副本

如果数组包含引用类型，则不复制元素，只复制引用

两种复制方法的区别：Clone()方法会创建一个新数组，而Copy()方法必须传递阶数相同且有足够元素的已有数据

<font color=red>如果需要包含引用类型的数组的深层副本，就必须迭代数组并创建新对象</font>

##### 排序

- Array类使用QuickSort算法对数组中的元素进行排序，Sort()方法需要数组中的元素实现IComparable接口，一般简单类型都已实现该接口，可以对包含这些类型的元素排序

  ```c#
  string[] names={"dd","dsfs","gss"};
  Array.Sort(names);
  foreach(var name in names)
  {
  	...
  }
  ```

- 如果对数组使用自定义类，则必须实现IComparable接口。该接口只有一个<font color=red>CompareTo()</font>方法。如果要比较的对象相等则返回0，如果该实例应排在参数对象的前面则该方法返回小于0的值，如果该实例应排在参数对象的后面该方法就返回大于0的值

  > 对\Chap6\Person.cs的Person类进行修改
  >
  > 使用：\Chap6\Program.cs

- 与上述不同的排序方式或者不能修改在数组中用作元素的类，则不需实现IComparer接口或者IComparer<T>接口，这两个接口定义了Compare()方法

  > 定义\Chap6\PersonComparer.cs对Person类实现IComparer接口
  >
  > 使用：\Chap6\Program.cs

- Array类提供的Sort方法需将一个委托作为参数传给方法以比较两个对象，而无需依赖IComparable或IComparer接口

#### 数组作为参数

数组可以作为参数传递给方法，也可以从方法中返回

```C#
//方法中返回
static Person[] GetPerson()
{
	return new Person[]{
		new Person{...},
		new Person{...},
		new Person{...}
	}
}
//作为参数在方法中传递
static void DisplayPersons(Person[] persons)
{
	...
}
```

- 数组协变（<font color=red>只能用于引用类型，不能用于值类型</font>）

  数组支持协变，表明数组可以声明为基类，其派生类型的元素可以赋予数组元素

  ```c#
  static void DisplayArray(object[] data)
  {
  	//
  }
  ```

- ArraySegment<T>

  表示数组的一段，<font color= blue>可用于需要使用不同的方法处理某个大型数组的不同部分</font>

  > Chap6\Program.cs中的SumOfSegments方法

   数组段不复制原数组的元素，但是原数组可以通过ArraySegment<T>访问，如果数组段中的元素改变了，这些变化就会反映到原数组中

#### 枚举

在foreach语言中使用枚举，可以迭代集合中的元素，且无需知道集合中的元素个数。

- IEnumerator接口

foreach语句使用IEnumerator接口的方法和属性，迭代集合中的所有元素。IEnumerator定义了Current属性以返回光标所在的元素，该接口的MoveNext()方法移动到集合的下一个元素上，如果有这个元素则返回true，如果集合中不再有更多的元素，则该方法返回false

- foreach语句

C#编译器会把foreach语句转换为IEnumerator接口的方法和属性

- yield语句

  用于便捷的创建枚举器，yield return语句返回集合的一个元素，并移动到下一个元素上，yield break可停止迭代

  包含yield语句的方法或属性也称为迭代块，迭代块必须返回声明为返回IEnumerator或IEnumerable接口，或者这些接口的泛型版本。这个块可以包含多条yield return语句或yield break语句，<font color =red>但不能包含return语句</font>

  yield语句会生成一个枚举器，而不仅仅生成一个包含的项的列表。这个枚举器通过foreach语句调用，从foreach中一次访问每一项时，就会访问枚举器，这样就可以迭代大量的数据，而无需一次把所有的数据都读入内存

  - 迭代集合的不同方式

    - 类支持的默认迭代是定义为返回IEnumerator()方法，命名的迭代返回IEnumerable

    - 迭代字符串数组的客户端代码先使用GetEnumerator0方法，该方法不必在代码中编写，因为这是foreach语句默认使用的方法。然后逆序迭代标题，最后将索引和要迭代的项数传递给Subset()方法来迭代子集

    > Chap6\MusicTitles.cs
    >
    > 使用：Chap6\Program.cs

  - 用yield return 返回枚举器

    > Chap6\GameMove.cs
    >
    > 使用：Chap6\Program.cs

#### 元组

数组合并了相同类型的对象，元组合并了不同类型的对象，.NET中定义了8个泛型Tuple类和一个静态Tuple类，不同的泛型Tuple类支持不同数量的元素

> Tuple<T1>包含一个元素，Tuple<T1,T2>包含两个元素，以此类推

> 使用：Chap6\Program.cs

如果元组包含的项超过8项，可以使用带8个参数的Tuple类定义，最后一个模板是TRest，表示必须给它传递一个元组，这样就可以创建带任意多项的元组

#### 结构比较

数组和元组都实现接口IStructuralEquatable和IStructuralComparable，这些接口都是显式实现的，所以在使用是需要把数组和元组强制转换为这个接口，IStructuralEquatable接口用于比较两个元组或者数组是否有相同的内容，IStructuralComparable接口用于给元组或数组排序

> 实现IStructuralEquatable接口：Chap6\Person2.cs
>
> Chap6\PersonComparer.cs
>
> 使用：Chap6\Program.cs

对于IStructuralEquatable接口定义的Equals()方法，它的第一个参数是object类型，第二个参数是IEqualityComparer类型

> 使用：Chap6\Program.cs

元组对比

Tuple<>类提供了两个Equals()方法：一个重写了Object积累中的Equals()方法，并把object作为参数

> 使用：Chap6\Program.cs

第二个是由IStructuralEqualityComparer接口定义，并把object和IEqualityComparer作为参数

>  类定义：Chap6\TupleComparer.cs

## 7  运算符和类型强制转换

#### 运算符

![](G:\zhl\GIS开发资料\CSharpLearn\CSharpLearn\image\7-1.png)

大多数与其他语言一样，不再赘述

- 运算符的简化操作

  ++，--+=，-=  等等，不再赘述

  ++和--的前置与后置与其他语言相通

  前置：先加减后运算；后置：先运算后加减

- 条件运算符（三元表达式）

  <font color=red>？：</font>    	`condition ? true_value : false_value`

  `x == 1 ? "man" : "men"`

- <font color=blue>checked和unchecked运算符</font>

  溢出异常控制运算符

  ```C#
  byte b=255;
  checked
  {
  	b++;
  }
  Console.WriteLine(b.ToString());//输出错误信息
  unchecked//禁止溢出检查
  {
  	b++;
  }
  Console.WriteLine(b.ToString());//不会抛出异常，但会丢失数据，b=0
  ```

- is运算符

  可以检查对象是否与特定的类型兼容

  兼容表示对象或者是该类型，或者是派生自该类型

  ```C#
  int i=10;
  if(i is object)   //true
  {
  	...
  }
  ```

- as运算符

  用于执行<font color=red>引用类型</font>显式类型转换。如果要转换的类型与指定的类型兼容，转换就会成功进行，如果类型不兼容，as运算符就会返回null值

  ```C#
  object o1="ssss";
  object o2=5;
  string s1=o1 as string; //s1="ssss";
  string s2=o2 as string; //s2=null;
  ```

- sizeof运算符

  该运算符可以确定栈中值类型需要的长度（单位是字节）

  ```C#
  Console.WriteLine(sizeof(int));  //4
  unsafe    //对复杂类型和非基本类型使用sizeof运算符需要将代码放到unsafe块中
  {
  	Console.WriteLine(sizeof(Customer));
  }
  ```

- typeof运算符

  返回一个表示特定类型的System.Type对象，例如typeof(string)返回表示System.String类型的Type对象。

- 可空类型和运算符<font color = red>?</font>

  ```c#
  int? a=null;
  int? b=a+4;//b=null
  int? c=a*5;//c=null
  ```

  null值的可能性表示，不能随意合并表达式中的可空类型和非可空类型。

- 空合并运算符<font color=red>??</font>

  这个运算符放在两个操作数之间，第一个操作数必须是一个可空类型或引用类型；<font color=purple>第二个操作数必须与第一个操作数的类型相同，或者可以隐含的转换为第一个操作数的类型</font>

  - 如果第一个操作数是null，整个表达式等于第二个操作数的值

  - 如果第一个操作数不是null，整个表达式等于第一个操作数的值

    ```C#
    int? a=null;
    int b;
    b=a??10;//b=10;
    a=3;
    b=a>>10;//b=3;
    ```

##### 运算符的优先级

![](G:\zhl\GIS开发资料\CSharpLearn\CSharpLearn\image\7-2.png)

#### 类型的安全性

##### 类型转换

- 隐式转换

  ![](G:\zhl\GIS开发资料\CSharpLearn\CSharpLearn\image\7-3.png)

  隐式转换值类型时，可空类型需要考虑其他因素

  - 可空类型隐式地转换为其他可空类型，应遵循表7-5非可空类型转换规则
  - 非可空类型隐式地转换为可空类型也应遵循表7-5转换规则
  - 可空类型不能隐式转换为其他非可空类型，此时必须进行显式转换

- 显式转换

  显式类型转换有一些限制：就值类型来说，只能在数字、char类型和enum类型之间转换，不能直接把布尔型强制转换为其他类型，也不能把其他类型转换为布尔型

  数字与字符串之间的转换

  ```C#
  int i=10;
  string s=i.ToString();
  string c="100";
  int j=int.Parse(c);
  ```

##### 装箱和拆箱

- 装箱：将值类型转换为引用类型

- 拆箱：将以前的装箱的引用类型转换为值类型

  ```C#
  int myIntNumber =20;
  object myObject = myIntNumber;    //装箱
  int mySecondNumber=(int)myObject; //拆箱
  ```

  只能对以前装箱的变量进行拆箱，且必须确保<font color=red>得到的值变量有足够的空间存储结构拆箱的值中的所有字节</font>(如long类型装箱之后拆箱为int类型)

#### 比较对象的相等性

##### 比较引用类型的相等性

- ReferenceEquals()方法

  属于静态方法，不能被重写，测试两个引用是否为类的同一个实例，特别是两个引用是否包含内存中的相同地址，如果提供的两个引用引用同一个对象实例，则ReferenceEquals()返回true，同时它认为null等于null
  
  ```C#
  SomeClass x,y;
  x=new SomeClass();
  y=new SomeClass();
  bool B1=ReferenceEquals(null,null);   //true
  bool B2=ReferenceEquals(null,x);      //false
  bool B3=ReferenceEquals(x,y);         //false
  ```

- 虚拟的Equals()方法

  这个方法是<font color=red>虚拟的</font>,可以在自己的类中重写它，从而按<font color =red>值</font>来比较对象

  注：重写的代码不会抛出异常

- 静态的Equals()方法

  与虚拟实例版本作用相同，其区别是静态版本带有两个参数，并对它们进行相等性比较

  该方法可以处理两个对象中<font color=red>有一个是null</font>的情况，有一个null则抛出异常

  两个null则true，一个null为false，如果两个引用实际上引用了某个独享，就调用Equals()的虚拟实例版本。

  <font color=blue>重写Equals()的实例版本就相当于重写了静态版本</font>

- 比较运算符(==)

  ```C#
  //在大多数情况下，以下情况表示正在比较引用
  bool b=(x==y);
  ```

##### 比较值类型的相等性

采用与引用类型相同的规则：<font color=red>ReferenceEquals()用于比较引用，Equals()用于比较值，比较运算符看做中间项</font>

最大的区别：<font color=blue>值类型需要装箱，才能转换为引用</font>

如果值类型包含作为字段的引用类型，就需要重写 Equals()

#### 运算符重载

运算符重载不仅局限于算术运算符，还要考虑<font color=red>比较运算符</font>(==、>=、<=、!=、<、>)

##### 运算符重载示例

<font color=blue>operator</font>关键字声明

C#要求所有的运算符重载都声明为<font color=blue>public 和 static</font>的，这表示它们与它们的类或结构相关联，而不与某个特定的实例相关联，所以运算符重载的代码体<font color=red>不能访问非静态成员，也不能访问this标识符</font>

- 重载更多的算术运算符

  > 定义： Chap7/Vector.cs
  >
  > 使用： Chap7/Program.cs

- 重载比较运算符

  - C#<font color=red>要求成对的重载运算符</font> 如重载了“==”就必须重载"!="

    注:重载了"===="和"!="时还必须重载从System.Object中继承的Equals()和GetHashCode()方法，因为Equals()应与=="=="有相同的逻辑

  - 比较运算符必须返回bool类型的值

- 可以重载的运算符

![](G:\zhl\GIS开发资料\CSharpLearn\CSharpLearn\image\7-4.png)

#### 用户定义的类型强制转换

C#允许用户定义自己的数据类型（结构和类），所以需要某些工具支持自定义的数据类型之间进行类型强制转换，可以把类型强制转换运算符定义为相关类的一个成员运算符，<font color =red>类型强制转换运算符必须标记为隐式或显式</font>.隐式适用于类型强制转换是安全的，显式适用于可能会出现数据丢失或者抛出异常的强制转换

类型强制转换<font color=blue>必须同时声明为public和static</font>

##### 实现用户定义的类型强制转换

> 定义： Chap7/Currency.cs
>
> 使用： Chap7/Program.cs

  有时候因为成员类型的问题，问题不出在调用而在方法中，可以将方法体写在<font color=red>checked</font>环境下以确保类型

- 类之间的类型强制转换

  定义不同结构或者类的实例之间的类型强制转换的限制：

  - 如果某个类派生自另一个类，就不能定义这两个类之间的类型强制转换（这些类型的强制转换已经存在
  - 类型强制转换必须在源数据类型或目标数据类型的内部定义，一旦在一个类的内部定义了类型强制转换，就不能在另一个类中定义相同的类型强制转换

- 基类和派生类之间的类型强制转换

  ```C#
  //MyDerived直接或间接派生自MyBase
  //以下为MyDerived隐式的转换为MyBase
  MyDerived derivedObject = newMyDerived();
  MyBase baseCopy = derivedObject;
  //另一种方式
  MyBase derivedObject = new MyDerived();
  MyBase baseObject = new MyBase();
  MyDerived deriveCopy1 = (MyDerived) derivedObject; //OK
  MyDerived deriveCopy2 = (MyDerived) baseObject;    //Throws exception
  
  //如果实际上要把MyBase实例转换为真实的MyDerived对象，该对象的值根据MyBase实例的内容来确定，就不能使用类型强制转换语法
  //最合适的选项通常是定义一个派生类的构造函数，以基类的实例作为参数完成初始化
  class DerivedClass:BaseClass
  {
      public DerivedClass(BaseClaass rhs)
      {
          //initialize
      }
      //...
  }
  ```

- 装箱和拆箱数据类型强制转换

  基本结构和派生结构之间的强制转换总是基元类型或结构与System.Object之间的转换

  从结构（或基本类型）到Object的强制转换总是一种隐式的强制转换，因为这种强制转换是从派生类型到基类型的转换

  ```C#
  Currency balance = new Currency(40.0);
  object baseCopy = balance;
  ```

- 多重类型强制转换

  如果没有直接的强制转换方式，C#编译器会自动将几种强制转换方式合并起来

  ```c#
  //隐式的转换，自动合并了几种转换方式
  Currency balance = new Currency(10,50);
  long amount = (long)balance;
  double amoountD = balance;
  //显式的转换
  Currency balance = new Currency(10,50);
  long amount = (long)(float)balance;
  double amountD = (double)(float)balance;
  ```

## 8  委托、lambda表达式和事件

#### 引用方法

lambda表达式与委托直接相关，当参数是委托类型时，就可以使用lambda表达式实现委托引用

#### 委托

把方法传递给其他方法时需要委托

如果要传递方法，就必须把方法的细节封装在一种新类型的对象中，即委托。委托只是一种特殊类型的对象，其特殊之处在于，我们以前定义的所有对象都包含数据，而<font color=red>委托包含的只是一个或多个方法的地址</font>。

##### 声明委托

语法类似于方法的定义但是<font color=red>没有方法体</font>，可以在定义类的任何相同地方定义委托，可以在委托的定义上应用任意常见的访问修饰符

```C#
//可以定义不同的返回类型
delegate void IntMethodInvoker(int x);
//是否带参数
degelate double TwoLongsOp(long first,long second);
degelate string GetAString();
//访问修饰符：public、private、protected等
public degelate string GetTwoString();
```

##### 使用委托

```c#
private delegate string GetAString();
static void Main()
{
   int x=40;
    //实例化类型为GetAString的委托并初始化
    //ToString方法不能带括号，只需把方法名传递即可
   GetAString firstStringMethod=new GetAString(x.ToString); 
    //GetAString firstStringMethod = x.ToString;   与上句作用相同
   Console.WriteLine("String is {0}",firstStringMethod());
}
```

委托推断：为了减少输入量，只要需要委托实例，就可以只传送<font color=red>地址的名称</font>。委托推断可以在需要委托实例的任何地方使用，也可用于事件

> 通过委托调用方法的简单例子说明：Chap8/Program.cs
>
> 该例子把委托作为参数

简单的委托示例

> Chap8/Program.cs

复杂的委托示例   ——Action<T> 和Func<T>委托

##### Action<T>和Func<T>委托

Action<T>委托表示<font color =red>引用一个void返回类型的方法</font>，至多传递16种不同参数类型

` Action<in T1,in T2,in T3,....>调用带多个参数的方法`

Func<T>委托允许调用<font color=red>带返回类型的方法</font>，至多传递16个参数类型和一个返回类型

` Func<in T1,in T2,in T3,out TResult> 调用带四个参数和一个返回类型的方法`

> 示例：Chap8/BubbleSorter.cs、Employee.cs、Program.cs

##### 多播委托

多播委托：包含多个方法的委托，调用多播委托可按照顺序连续调用多个方法，因此该委托签名必须返回<font color=red>void</font>，否则只能得到委托调用的最后一个方法的结果     

- 多播委托可以识别<font color=red>“+”和“+=”</font>运算符、<font color=red>“-”和“-=”</font>运算符

```c#
Action<double> operations = MathOperations.MultiplyByTwo;
operations += MathOperations.Square;
Action<double> operations2 = MathOperations.Square;
Action<double> operationsr = operations+operations2;
```

> 示例：Chap8/MathOperations.cs、Program.cs

- 多播委托对同一个委托调用方法链没有正式定义顺序，因此应避免编写依赖于以特定顺序调用方法的代码
- 如果多播委托中一个方法调用异常就会使整个迭代停止

> 以上两点解决方法：Delegate类定义GetInvocationList()方法，返回一个Degelate对象数组，使用遍历，异常抛出后继续迭代
>
> Chap8/Program.cs

##### 匿名方法

- 在匿名方法中不能使用跳转语句（break，goto或continue）跳到匿名方法的外部，匿名方法外部的跳转语句也不能跳到该匿名方法内部

- 匿名方法内部不能访问不安全的代码，也不能在匿名方法外部使用ref和out参数，但可以使用在匿名方法外部定义的其他变量

- <font color =red>可以使用lambda表达式代替匿名方法</font>

  ```c#
  string mid=",middle part,";
  Func<string,string> anonDel=delegate(string param)
  {
  	param+=mid;
  	param+=" and this was added to the string.";
  	return param;
  }
  Console.WritLine(annoDel("Start of string"));
  //结果：Start of string,middle part, and this was added to the string.
  ```

  

#### lambda表达式

只要有委托参数类型的地方就可以使用lambda表达式

lambda运算符<font color=red>=></font>左边列出需要的参数，右边定义赋予lambda变量的方法实现代码

##### 参数

- 一个参数

  ```C#
  Func<string,string> oneParam = s => String.Format("一个参数：{0}"s);
  Console.WriteLine(oneParam("test"));
  ```

- 多个参数

  ```c#
  //省略参数类型
  Func<double,double,double> twoParams = (x,y) => x*y;
  //不省略参数类型
  Func<double,double,double> twoParams = (double x,double y) => x*y;
  Console.WriteLine(twoParams(3,5));
  ```

##### 多行代码

如果lambda表达式的实现代码需要多条语句，<font color=blue>必须添加花括号和return语句</font>

##### 闭包

通过lambda表达式可以访问lambda表达式块外部的变量，称为闭包。<font color =red>使用不当会非常危险</font>

##### 使用foreach语句的闭包

C#5.0中不再需要将代码修改成局部变量

#### 事件

<font color =red>事件基于委托</font>

##### 事件发布程序

- EventHandler<TEventArgs>定义了一个处理程序，它返回void，接受两个参数。对于EventHandler<TEventArgs>，第一个参数必须是<font color=blue>object类型</font>，第二个参数是<font color=blue>T类型</font>。其中EventHandler<TEventArgs>定义了关于T的约束：它必须派生自基类EventArgs。

  > 示例Chap8/CarDealer.cs

- 使用<font color =red>add和remove</font>关键字添加和删除委托的处理程序

```C#
private delegate EventHandler<CarInfoEventArgs> new CarInfo;
public event EventHandler<CarInfoEventArgs> newCarInfo
{
	add
	{
		newCarInfo += value;
	}
	remove
	{
		newCarInfo -= value;
	}
}
```

##### 事件侦听器

> 示例Chap8/Consumer.cs

> 完整事件的绑定与退订:Chap8/CarDealer.cs、Consumer.cs、Program.cs

##### 弱事件

- 弱事件管理器

  使用弱事件需要创建一个派生自WeakEventManager类的类

  静态属性<font color=red>CurrentManager</font>用于访问类中的单态对象

  弱事件管理器类需要静态方法AddListener()和RemoveListener()，侦听器使用这些方法连接发布程序、断开与发布程序的连接。

  

