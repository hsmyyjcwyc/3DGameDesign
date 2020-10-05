using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.MyGame;

namespace Com.MyGame
{
    public enum State { LEFT = 0, LeaveLeft, RightLeft, RIGHT, WIN, LOSE };
    public interface Interfaces
    {
        void priestOn();//牧师上船
        void devilOn();//魔鬼上船
        void moveBoat();//启动船只
        void getOffBoat();//下船
    }

    public class Director : System.Object,Interfaces
    {

        private static Director _instance;
        private BaseCode _base;
        private Controller genGameobj;
        public State state = State.LEFT;

        public static Director getInstance()
        {
            if (_instance == null)
            {
                _instance = new Director();
            }
            return _instance;
        }
        internal void setBaseCode(BaseCode b)
        {
            if (_base == null)
            {
                _base = b;
            }
        }
        internal void setController(Controller obj)
        {
            if (genGameobj == null)
            {
                genGameobj = obj;
            }
        }
        public void priestOn()
        {
            genGameobj.priestOn();
        }
        public void devilOn()
        {
            genGameobj.devilOn();
        }
        public void moveBoat()
        {
            genGameobj.moveBoat();
        }
        public void getOffBoat()
        {
            genGameobj.getOffBoat();
        }
    }
}

public class BaseCode : MonoBehaviour
{
    void Awake()
    {
        Director peng = Director.getInstance();
        peng.setBaseCode(this);
    }
}