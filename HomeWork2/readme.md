井字棋作业

视频地址:https://www.bilibili.com/video/BV1hA411J74J/

作业比较简单，但是有很多细节只有在自己边做边玩中才能发现，

比如：no winner 情况下的不显示，或者鼠标的还可以继续操作等等

比如出现下图中搞笑的错误：一个赢了，另一个在点一次也赢了，很尴尬

![Snipaste_2019-09-16_13-21-52](imp\Snipaste_2019-09-16_13-21-52.png)

```
if(GUI.Button(new Rect(250+i*50,200+j*50,50,50),"")&&map[i,j] == 0&&test == 0)//注意只有在，没有下过的位置，且没有玩家胜出的时候可以构建。
```

所以对上面的代码进行修改，解决了问题，代码就和生活一样，一个这么小的游戏我都无法一次喜好，实在是感慨游戏设计程序员的不易，这是第二次提交了，second version，解决掉自己发现的一些bug。

```` 
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tictactoe : MonoBehaviour
{
    //游戏每一次按下按钮都会导致棋盘值的变动，再进而影响渲染的结果
    //引擎会对代码进行渲染，初始渲染的有：棋盘，按钮（reset）可以跟据个人喜好进行调整
    //我们希望在每一次点击后，在指定位置，出现相应玩家的棋子，所以需要变量：player（1，2），map[3,3]
    //map有三种状态：未点击（0），player1（1），player2（2）
    //我们需要检测游戏结果，test（），其中包含结果呈现
    
    //现在来逐步完成这个游戏

    public int player = 1;//默认玩家1
    public int[,] map = new int[3, 3];//默认未点击
    public Texture2D player1;
    public Texture2D player2;//提供player1，2的素材接口，也可以使用GUIContent
    int counter = 0;
    int testWin()//1代表player1，-1代表player2，0代表和棋
    {
        //胜利有三种，横纵斜；
        //Horizontal
        for(int i = 0;i < 3;i++)
        {
            if(map[i,0]==map[i,1]&&map[i,2]==map[i,1])
            {
                return map[i,1];
            }
        }
        //Vertical
        for(int i = 0;i < 3;i++)
        {
            if(map[1,i]==map[0,i]&&map[2,i]==map[1,i])
            {
                return map[1,i];
            }
        }
        //Diagonal
        if(map[1,1]==map[0,0]&&map[1,1]==map[2,2])
        {
            return map[1,1];
        }
        if(map[1,1]==map[0,2]&&map[1,1]==map[2,0])
        {
            return map[1,1];
        }
        return 0;
    }
    void OnGUI()
    {
GUIStyle fontStyle = new GUIStyle();  
fontStyle.normal.background = null;   
fontStyle.normal.textColor= new Color(1, 0, 0);    
fontStyle.fontSize = 20; 

    //显示玩家和其对应的头像；
    GUI.Button (new Rect (100,10, 75, 75), player1);
    GUI.Button (new Rect (100,85, 75, 50), "player1");
    GUI.Button (new Rect (475,10, 75, 75), player2);
    GUI.Button (new Rect (475,85, 75, 50), "player2");

    if(GUI.Button(new Rect(275,400,100,50),"New game"))
    {
        player = 1;
        for(int i = 0;i < 3;i++)
        for(int j = 0;j < 3;j++)
        {
            map[i,j] = 0;
        }
        counter = 0;
    }
    //检查是否结束
    int test;
    test = testWin();
    if(test == 1){GUI.Button(new Rect(275,50,100,50),"Player1 win!");
        }
    if(test == -1){GUI.Button(new Rect(275,50,100,50),"Player2 win!");
       }

    if(counter==9&&test==0){GUI.Button(new Rect(275,50,100,50),"No winner!");
    }
    //构建棋盘；
    for(int i = 0;i < 3;i++)
        for(int j = 0;j < 3;j++)
        {
            if(GUI.Button(new Rect(250+i*50,200+j*50,50,50),"")&&map[i,j] == 0&&test == 0)//注意只有在，没有下过的位置，且没有玩家胜出的时候可以构建。
            {
                map[i,j] = player;
                player *= -1;
                counter = counter + 1;
            }//这里可以有很多种实现方法，现在所示的这种属于比较简单的；
            else if(map[i,j] == 1)
            {
                GUI.Button(new Rect(250+i*50,200+j*50,50,50),player1);
            }
            else if(map[i,j] == -1)
            {
                GUI.Button(new Rect(250+i*50,200+j*50,50,50),player2);
            }
        }

    //在构建好期盼后，我们需要检验，当一方胜利后，弹出提示
    //检测函数可以写在ongui外，只在内部调用其结果，开始写
    }
}
````

