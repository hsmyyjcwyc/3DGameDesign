using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MyGame;

public class View : MonoBehaviour 
{
    Director dir;
    Interfaces userInterface;
    private float counter = 0f;
    private int flag = 0;//判断是否结束
    private float second = 0f;
    private float minute = 0f;
    private string str;

    void Awake()
    {
        dir = Director.getInstance();
        userInterface = Director.getInstance() as Interfaces;
    }
    void Update()
    {
        if(flag == 0)
        {
            counter += Time.deltaTime;
            if (counter >= 1f)
            {
                second++;
                counter = 0;
            }
            if (second >= 60)
            {
                minute++;
                second = 0;
            }
            if (minute >= 60)
            {
                minute = 0;
            }
        }
    }

    void OnGUI()
    {
        str = string.Format("{0:00}:{1:00}", minute, second); //设置时间格式
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        GUI.Label(new Rect(20, 0, 100, 200), str, style);

        GUIStyle pai = new GUIStyle();
        pai.normal.textColor = new Color(0, 0, 0); //设置字体颜色
        pai.fontSize = 35;
        GUI.TextField(new Rect(510, 20, 80, 40), "牧师过河", style);

        GUIStyle txt = new GUIStyle();
        txt.fontSize = 15;
        GUI.TextField(new Rect(20, 45, 50, 50), "温馨提示：", txt);
        GUI.TextField(new Rect(20, 60, 200, 50), "不管哪一个岸边，只要魔鬼数大于牧师数，游戏则失败。", txt);
        GUI.TextField(new Rect(20, 75, 200, 50), "记住哦，瘦白的是牧师，园黑的是魔鬼", txt);

        if (dir.state == State.WIN)
        {
            flag = 1;
            GUIStyle word = new GUIStyle();
            word.normal.textColor = new Color(0, 0, 0);
            word.fontSize = 35;//字体大小
            GUI.TextField(new Rect(510, 400, 80, 50), "你赢了！", word);
            Debug.Log("Win");
        }
        else if(dir.state == State.LOSE)
        {
            flag = 1;
            GUIStyle word = new GUIStyle();
            word.normal.textColor = new Color(0, 0, 0);
            word.fontSize = 35;
            GUI.TextField(new Rect(510, 400, 80, 50), "失败！", word);
            Debug.Log("Lose");
        }
        else if(dir.state == State.LEFT||dir.state == State.RIGHT) //这一步是为了设定其他状态的时候不可以点击
        {    
            if (GUI.Button(new Rect(470, 100, 80, 50), "牧师上船"))
            {
                userInterface.priestOn();
            }
            if (GUI.Button(new Rect(555, 100, 80, 50), "魔鬼上船"))
            {
                userInterface.devilOn();
            }
            if (GUI.Button(new Rect(470, 170, 80, 50), "下船"))
            {
                userInterface.getOffBoat();
            }
            if (GUI.Button(new Rect(555, 170, 80, 50), "开船"))
            {
                userInterface.moveBoat();
            }
        }
    }
}
