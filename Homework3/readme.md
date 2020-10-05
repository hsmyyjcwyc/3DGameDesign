### 第三次作业 · 空间与运动

### 一、简答题

**1.游戏对象运动的本质是什么？**

游戏对象的运动，实质上是游戏对象相对于原来位置或者相对于其他游戏对象位置的改变，对应transform组件中的position、rotation和scale等属性的变化。

**2.请用三种方法以上方法，实现物体的抛物线运动。**

直接修改 Transform.position

```c#
public float speed_x = 2.0f;
public float speed_y = 0;
public int time = 0；

void Update()
{
    time +=(float)Time.deltaTime;
    float distance_x, distance_y;
    distance_x = (float)(speed_x * time);  
    distance_y = (float)(0.5 * 10 * time *time);
    this.transform.position += Vector3.right * distance_x;
    this.transform.position += Vector3.down * distance_y;

}
```

利用Vector3的方法

```c#
//前面部分的参数设定同上面部分，我们只写一下Update的内容
void Update()
{
    time +=(float)Time.deltaTime;
    float distance_x, distance_y;
    distance_x = (float)(speed_x * time);  
    distance_y = (float)(0.5 * 10 * time *time);
  	this.transform.position += new Vector3(distance_x, distance_y, 0); 
}
```

利用物体的rigidbody组件，通过rigidbody组件的MovePosition方法实现物体的抛物线运动

```c#
//我们给予刚体一个初始速度，直接利用Rigidbody就可以模拟抛物线的运动。
public Rigidbody rb;
public Vector3 firstspeed;

void Start()
{
    rb = GetComponent<Rigidbody>();
    rb.isKinematic = true;
}

void FixedUpdate()
{
    firstspeed = new Vector3(0, 0, 0);
    rb.velocity = firstspeed;
}
```

**3.写一个程序，实现一个完整的太阳系， 其他星球围绕太阳的转速必须不一样，且不在一个法平面上。**



### 二、编程实践

阅读以下脚本：

> Priests and Devils
>
> Priests and Devils is a puzzle game in which you will help the Priests and Devils to cross the river within the time limit. There are 3 priests and 3 devils at one side of the river. They all want to get to the other side of this river, but there is only one boat and this boat can only carry two persons each time. And there must be one person steering the boat from one side to the other side. In the flash game, you can click on them to move them and click the go button to move the boat to the other direction. If the priests are out numbered by the devils on either side of the river, they get killed and the game is over. You can try it in many ways. Keep all priests alive! Good luck!

play the game ( http://www.flash-game.net/game/2535/priests-and-devils.html )

列出游戏中提及的事物（Objects）

- 用表格列出玩家动作表（规则表），注意，动作越少越好
- 请将游戏中对象做成预制
- 在场景控制器 `LoadResources` 方法中加载并初始化 长方形、正方形、球 及其色彩代表游戏中的对象。
- 使用 C# 集合类型 有效组织对象
- 整个游戏仅 主摄像机 和 一个 Empty 对象， **其他对象必须代码动态生成！！！** 。 整个游戏不许出现 Find 游戏对象， SendMessage 这类突破程序结构的 通讯耦合 语句。 **违背本条准则，不给分**
- 请使用课件架构图编程，**不接受非 MVC 结构程序**
- 注意细节，例如：船未靠岸，牧师与魔鬼上下船运动中，均不能接受用户事件！

游戏中提及的事物如下：

- 三个牧师、三个魔鬼
- 两个河岸
- 一艘小船

用表格列出玩家动作表（规则表），注意，动作越少越好

| 玩家动作                 | 动作条件                     |
| ------------------------ | ---------------------------- |
| 船从岸的一侧开往另外一侧 | 船上必须有一个牧师或者魔鬼   |
| 游戏结束                 | 岸的任意一侧魔鬼数量大于牧师 |
| 从左边上岸               | 船的左边有人（魔鬼或者牧师） |
| 从右边上岸               | 船的右边有人                 |

整个游戏仅 主摄像机 和 一个 Empty 对象， 其他对象必须代码动态生成 。整个游戏不许出现 Find 游戏对象， SendMessage 这类突破程序结构的通讯耦合语句，不接受非 MVC 结构程序。

所谓 MVC结构框架，就是 模型(model)－视图(view)－控制器(controller) ,用一种业务逻辑、数据、界面显示分离的方法组织代码，这样更改UI界面的时候就不需要更改其他方面了。

最后我们实现的游戏如下图：

![Snipaste_2020-10-05_22-45-01](Priests and Devils\Snipaste_2020-10-05_22-45-01.png)

